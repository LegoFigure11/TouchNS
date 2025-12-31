using SysBot.Base;
using System.Net.Sockets;
using System.Text;
using static SysBot.Base.SwitchCommand;

namespace TouchNS.Core.Connection;

public class ConnectionWrapperAsync(SwitchConnectionConfig Config, Action<string> StatusUpdate)
{
    public readonly ISwitchConnectionAsync Connection = Config.Protocol switch
    {
        SwitchProtocol.USB => new SwitchUSBAsync(Config.Port),
        _ => new SwitchSocketAsync(Config),
    };

    public bool Connected => IsConnected;
    private bool IsConnected { get; set; }
    private readonly bool CRLF = Config.Protocol is SwitchProtocol.WiFi;

    public async Task<(bool, string)> Connect(CancellationToken token)
    {
        if (Connected) return (true, "");

        try
        {
            StatusUpdate("Connecting...");
            Connection.Connect();
            IsConnected = true;

            StatusUpdate("Connected!");
            return (true, "");
        }
        catch (SocketException e)
        {
            IsConnected = false;
            return (false, e.Message);
        }
    }

    public async Task<(bool, string)> DisconnectAsync(CancellationToken token)
    {
        if (!Connected) return (true, "");

        try
        {
            StatusUpdate("Disconnecting controller");
            await Connection.SendAsync(DetachController(CRLF), token).ConfigureAwait(false);

            StatusUpdate("Disconnecting...");
            Connection.Disconnect();
            IsConnected = false;
            StatusUpdate("Disconnected!");
            return (true, "");
        }
        catch (SocketException e)
        {
            IsConnected = false;
            return (false, e.Message);
        }
    }
    public async Task Touch(int x, int y, int hold, int delay, CancellationToken token)
    {
        var command = Encoding.ASCII.GetBytes(
            $"touchHold {x} {y} {hold}{(CRLF ? "\r\n" : "")}"
        );
        await Connection.SendAsync(command, token).ConfigureAwait(false);
        await Task.Delay(delay, token).ConfigureAwait(false);
    }
}
