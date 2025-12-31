using SysBot.Base;
using System.Diagnostics;
using System.Text.Json;
using TouchNS.Core.Connection;

namespace TouchNS.WinForms;

public partial class MainWindow : Form
{
    private static CancellationTokenSource Source = new();
    private static readonly Lock _connectLock = new();

    public ClientConfig Config;
    private ConnectionWrapperAsync ConnectionWrapper = default!;
    private readonly SwitchConnectionConfig ConnectionConfig;

    private readonly BindingSource bs = [];

    private readonly Version CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;

    public MainWindow()
    {
        Config = new ClientConfig();
        var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        if (File.Exists(configPath))
        {
            var text = File.ReadAllText(configPath);
            Config = JsonSerializer.Deserialize<ClientConfig>(text)!;
        }
        else
        {
            Config = new();
        }

        ConnectionConfig = new()
        {
            IP = Config.IP,
            Port = Config.Protocol is SwitchProtocol.WiFi ? 6000 : Config.UsbPort,
            Protocol = Config.Protocol,
        };

        var v = CurrentVersion;
#if DEBUG
        var build = "";

        var asm = System.Reflection.Assembly.GetEntryAssembly();
        var gitVersionInformationType = asm?.GetType("GitVersionInformation");
        var sha = gitVersionInformationType?.GetField("ShortSha");

        if (sha is not null) build += $"#{sha.GetValue(null)}";

        var date = File.GetLastWriteTime(AppContext.BaseDirectory);
        build += $" (dev-{date:yyyyMMdd})";

#else
        var build = "";
#endif

        Text = $"TouchNS v{v.Major}.{v.Minor}.{v.Build}{build}";

        Application.SetColorMode(Config.Theme);

        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        CenterToScreen();

        if (Config.Protocol is SwitchProtocol.WiFi)
        {
            TB_SwitchIP.Text = Config.IP;
        }
        else
        {
            L_SwitchIP.Text = "USB Port:";
            TB_SwitchIP.Text = $"{Config.UsbPort}";
        }

        TB_Status.Text = "Not Connected.";

        CB_Theme.SelectedIndex = (int)Config.Theme;

        CB_ClickToSend.Checked = Config.ClickToSendTouch;

        TB_TouchDuration.Text = $"{Config.TouchHold}";

        ConnectionWrapper = new(ConnectionConfig, UpdateStatus);

        CheckForUpdates();
    }

    private void Connect(CancellationToken token)
    {
        Task.Run(
            async () =>
            {
                SetControlEnabledState(false, B_Connect);
                try
                {
                    ConnectionConfig.IP = TB_SwitchIP.Text;
                    (bool success, string err) = await ConnectionWrapper
                        .Connect(token)
                        .ConfigureAwait(false);
                    if (!success)
                    {
                        SetControlEnabledState(true, B_Connect);
                        this.DisplayMessageBox(err);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    SetControlEnabledState(true, B_Connect);
                    this.DisplayMessageBox(ex.Message);
                    return;
                }

                SetControlEnabledState(true, B_Disconnect);
                UpdateStatus("Connected!");

                var img = await GetPixelPeek().ConfigureAwait(false);
                SetPictureBoxImage(img, PB_Touch);
            },
            token
        );
    }

    private void Disconnect(CancellationToken token)
    {
        Task.Run(
            async () =>
            {
                SetControlEnabledState(false, B_Disconnect);
                try
                {
                    (bool success, string err) = await ConnectionWrapper.DisconnectAsync(token).ConfigureAwait(false);
                    if (!success) this.DisplayMessageBox(err);
                }
                catch (Exception ex)
                {
                    this.DisplayMessageBox(ex.Message);
                }

                await Source.CancelAsync().ConfigureAwait(false);
                Source = new();
                SetControlEnabledState(true, B_Connect);
            },
            token
        );
    }

    private void UpdateStatus(string status)
    {
        SetTextBoxText(status, TB_Status);
    }

    public void SetTextBoxText(string text, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is not TextBox tb)
                continue;

            if (InvokeRequired)
                Invoke(() => tb.Text = text);
            else
                tb.Text = text;
        }
    }

    public void SetPictureBoxImage(Image img, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is not PictureBox pb)
                continue;

            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    if (pb.Image != null)
                    {
                        var old = pb.Image;
                        pb.Image = null;
                        old.Dispose();
                    }
                    pb.Image = img;
                }
                );
            }
            else
            {
                if (pb.Image != null)
                {
                    var old = pb.Image;
                    pb.Image = null;
                    old.Dispose();
                }
                pb.Image = img;
            }
        }
    }

    public void SetControlEnabledState(bool state, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is not Control c)
                continue;

            if (InvokeRequired)
                Invoke(() => c.Enabled = state);
            else
                c.Enabled = state;
        }
    }

    public bool GetCheckBoxCheckedState(CheckBox c)
    {
        return (InvokeRequired ? Invoke(() => c.Checked) : c.Checked);
    }

    private void B_Connect_Click(object sender, EventArgs e)
    {
        lock (_connectLock)
        {
            if (ConnectionWrapper is { Connected: true })
                return;

            ConnectionWrapper = new(ConnectionConfig, UpdateStatus);
            Connect(Source.Token);
        }
    }

    private void B_Disconnect_Click(object sender, EventArgs e)
    {
        lock (_connectLock)
        {
            if (ConnectionWrapper is not { Connected: true })
                return;

            Disconnect(Source.Token);
        }
    }

    private void B_GetImage_Click(object sender, EventArgs e)
    {
        Task.Run(async () =>
        {
            try
            {
                if (ConnectionWrapper.Connected)
                {
                    var img = await GetPixelPeek().ConfigureAwait(false);
                    SetPictureBoxImage(img, PB_Touch);
                }
            }
            catch (Exception ex)
            {
                this.DisplayMessageBox(ex.Message);
                return;
            }
        });
    }

    public string GetControlText(Control c)
    {
        return (InvokeRequired ? Invoke(() => c.Text) : c.Text);
    }

    private void TB_SwitchIP_TextChanged(object sender, EventArgs e)
    {
        if (Config.Protocol is SwitchProtocol.WiFi)
        {
            Config.IP = TB_SwitchIP.Text;
            ConnectionConfig.IP = TB_SwitchIP.Text;
        }
        else
        {
            if (int.TryParse(TB_SwitchIP.Text, out int port) && port >= 0)
            {
                Config.UsbPort = port;
                ConnectionConfig.Port = port;
                return;
            }

            MessageBox.Show("Please enter a valid numerical USB port.");
        }
    }

    private readonly JsonSerializerOptions options = new() { WriteIndented = true };
    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        var configpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        string output = JsonSerializer.Serialize(Config, options);
        using StreamWriter sw = new(configpath);
        sw.Write(output);

        if (ConnectionWrapper is { Connected: true })
        {
            try
            {
                _ = ConnectionWrapper.DisconnectAsync(Source.Token).ConfigureAwait(false);
            }
            catch
            {
                // ignored
            }
        }

        Source.Cancel();
        Source = new();
    }

    private bool first = true;
    private bool hasShownThemePopup = false;
    private void CB_Theme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!first)
        {
            Config.Theme = (SystemColorMode)CB_Theme.SelectedIndex;
            if (!hasShownThemePopup) MessageBox.Show("Theme selection will be applied next time the program is launched.");
            hasShownThemePopup = true;
        }
        first = false;
    }


    private void CheckForUpdates()
    {
        Task.Run(async () =>
        {
            Version? latestVersion;
            try { latestVersion = GetLatestVersion(); }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception while checking for latest version: {ex}");
                return;
            }

            if (latestVersion is null || latestVersion <= CurrentVersion)
                return;

            while (!IsHandleCreated) // Wait for form to be ready
                await Task.Delay(2_000).ConfigureAwait(false);
            await InvokeAsync(() => NotifyNewVersionAvailable(latestVersion));
        });
    }

    private void NotifyNewVersionAvailable(Version version)
    {
        Text += $" - Update v{version.Major}.{version.Minor}.{version.Build} available!";

#if !DEBUG
        using UpdateNotifPopup nup = new(CurrentVersion, version, Config.TopMost);
        if (nup.ShowDialog() == DialogResult.OK)
        {
            Process.Start(new ProcessStartInfo("https://github.com/LegoFigure11/TouchNS/releases/")
            {
                UseShellExecute = true
            });
        }
#endif
    }


    public static Version? GetLatestVersion()
    {
        const string endpoint = "https://api.github.com/repos/LegoFigure11/TouchNS/releases/latest";
        var response = GetStringFromURL(new Uri(endpoint));
        if (response is null) return null;

        const string tag = "tag_name";
        var index = response.IndexOf(tag, StringComparison.Ordinal);
        if (index == -1) return null;

        var first = response.IndexOf('"', index + tag.Length + 1) + 1;
        if (first == 0) return null;

        var second = response.IndexOf('"', first);
        if (second == -1) return null;

        var tagString = response.AsSpan()[first..second].TrimStart('v');

        var patchIndex = tagString.IndexOf('-');
        if (patchIndex != -1) tagString = tagString.ToString().Remove(patchIndex).AsSpan();

        return !Version.TryParse(tagString, out var latestVersion) ? null : latestVersion;
    }

    private void PB_Touch_MouseMove(object sender, MouseEventArgs e)
    {
        var pos = PB_Touch.PointToClient(Cursor.Position);
        SetTextBoxText($"{pos.X}", TB_CurrX);
        SetTextBoxText($"{pos.Y}", TB_CurrY);
    }

    private void B_SetCursor_Click(object sender, EventArgs e)
    {
        var xText = GetControlText(TB_CurrX);
        var yText = GetControlText(TB_CurrY);

        if (!int.TryParse(xText, out var x)) x = 0;
        if (!int.TryParse(yText, out var y)) y = 0;

        var loc = PB_Touch.PointToScreen(new Point(x, y));

        Cursor.Position = loc;
    }

    private Point GetPointSafe(Control control)
    {
        return (InvokeRequired ? Invoke(() => control.PointToClient(Cursor.Position)) : control.PointToClient(Cursor.Position));
    }

    private void PB_Touch_Click(object sender, EventArgs e)
    {
        var pos = GetPointSafe(PB_Touch);
        log.Add($"{pos.X}, {pos.Y}");
        ReloadList();
        LB_Log.SelectedIndex = log.Count - 1;
        Task.Run(async () =>
        {
            try
            {
                if (ConnectionWrapper.Connected && GetCheckBoxCheckedState(CB_ClickToSend))
                {

                    var durText = GetControlText(TB_TouchDuration);
                    if (!int.TryParse(durText, out var duration)) duration = 50;

                    await ConnectionWrapper.Touch(pos.X, pos.Y, duration, 0, Source.Token).ConfigureAwait(false);

                    await Task.Delay(1_000, Source.Token).ConfigureAwait(false);

                    var img = await GetPixelPeek().ConfigureAwait(false);
                    SetPictureBoxImage(img, PB_Touch);
                }
            }
            catch (Exception ex)
            {
                this.DisplayMessageBox(ex.Message);
                return;
            }
        });
    }

    private async Task<Bitmap> GetPixelPeek()
    {
        var imgBuf = await ConnectionWrapper.Connection.PixelPeek(Source.Token).ConfigureAwait(false);
        var ms = new MemoryStream(imgBuf);
        var bmp = new Bitmap(ms);
        var clone = (Bitmap)bmp.Clone();
        bmp.Dispose();
        ms.Dispose();
        return clone;
    }

    private List<string> log = [];
    private void ReloadList()
    {
        if (bs.DataSource is null)
        {
            bs.DataSource = log;
            LB_Log.DataSource = bs;
        }
        else
        {
            bs.DataSource = log;
            bs.ResetBindings(false);
        }
    }

    private void B_ClearSelected_Click(object sender, EventArgs e)
    {
        var i = LB_Log.SelectedIndex;
        if (log.Count > 0)
        {
            log.RemoveAt(i);
        }
        else
        {
            System.Media.SystemSounds.Asterisk.Play();
        }
        ReloadList();
    }

    private void CB_ClickToSend_CheckedChanged(object sender, EventArgs e)
    {
        Config.ClickToSendTouch = CB_ClickToSend.Checked;
    }

    private void TB_TouchDuration_TextChanged(object sender, EventArgs e)
    {
        var durText = GetControlText(TB_TouchDuration);
        if (!int.TryParse(durText, out var duration)) duration = 50;
        Config.TouchHold = duration;
    }


    // https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/NetUtil.cs
    private static string? GetStringFromURL(Uri url)
    {
        try
        {
            var stream = GetStreamFromURL(url);
            if (stream is null)
                return null;

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        // No internet?
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return null;
        }
    }
    // https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/NetUtil.cs
    // The GitHub API will fail if no user agent is provided. Use a hardcoded one to avoid issues.
    private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
    // https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/NetUtil.cs
    private static Stream? GetStreamFromURL(Uri url)
    {
        using var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(3);
        client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        var response = client.GetAsync(url).Result;
        return response.IsSuccessStatusCode ? response.Content.ReadAsStream() : null;
    }
}
