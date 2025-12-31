namespace TouchNS.WinForms;

    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        GB_Connection = new GroupBox();
        TB_Status = new TextBox();
        L_Status = new Label();
        B_Disconnect = new Button();
        B_Connect = new Button();
        L_SwitchIP = new Label();
        TB_SwitchIP = new TextBox();
        GB_SAVInfo = new GroupBox();
        L_Theme = new Label();
        CB_Theme = new ComboBox();
        PB_Touch = new PictureBox();
        B_GetImage = new Button();
        CB_ClickToSend = new CheckBox();
        TB_CurrX = new TextBox();
        TB_CurrY = new TextBox();
        label1 = new Label();
        label2 = new Label();
        B_SetCursor = new Button();
        L_TouchDuration = new Label();
        TB_TouchDuration = new TextBox();
        LB_Log = new ListBox();
        B_ClearSelected = new Button();
        L_Test = new Label();
        TB_Test = new TextBox();
        B_TouchType = new Button();
        GB_Connection.SuspendLayout();
        GB_SAVInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PB_Touch).BeginInit();
        SuspendLayout();
        // 
        // GB_Connection
        // 
        GB_Connection.Controls.Add(TB_Status);
        GB_Connection.Controls.Add(L_Status);
        GB_Connection.Controls.Add(B_Disconnect);
        GB_Connection.Controls.Add(B_Connect);
        GB_Connection.Controls.Add(L_SwitchIP);
        GB_Connection.Controls.Add(TB_SwitchIP);
        GB_Connection.Location = new Point(0, -8);
        GB_Connection.Margin = new Padding(3, 0, 3, 3);
        GB_Connection.Name = "GB_Connection";
        GB_Connection.RightToLeft = RightToLeft.No;
        GB_Connection.Size = new Size(212, 83);
        GB_Connection.TabIndex = 2;
        GB_Connection.TabStop = false;
        // 
        // TB_Status
        // 
        TB_Status.BackColor = SystemColors.Control;
        TB_Status.BorderStyle = BorderStyle.None;
        TB_Status.Location = new Point(74, 64);
        TB_Status.Name = "TB_Status";
        TB_Status.ReadOnly = true;
        TB_Status.RightToLeft = RightToLeft.No;
        TB_Status.Size = new Size(132, 16);
        TB_Status.TabIndex = 18;
        TB_Status.TabStop = false;
        TB_Status.Text = "wwwwwwwwwwwwww";
        TB_Status.TextAlign = HorizontalAlignment.Right;
        // 
        // L_Status
        // 
        L_Status.AutoSize = true;
        L_Status.Location = new Point(11, 64);
        L_Status.Name = "L_Status";
        L_Status.Size = new Size(42, 15);
        L_Status.TabIndex = 17;
        L_Status.Text = "Status:";
        // 
        // B_Disconnect
        // 
        B_Disconnect.Enabled = false;
        B_Disconnect.Location = new Point(109, 36);
        B_Disconnect.Name = "B_Disconnect";
        B_Disconnect.Size = new Size(97, 25);
        B_Disconnect.TabIndex = 2;
        B_Disconnect.Text = "Disconnect";
        B_Disconnect.UseVisualStyleBackColor = true;
        B_Disconnect.Click += B_Disconnect_Click;
        // 
        // B_Connect
        // 
        B_Connect.Location = new Point(11, 36);
        B_Connect.Name = "B_Connect";
        B_Connect.Size = new Size(97, 25);
        B_Connect.TabIndex = 1;
        B_Connect.Text = "Connect";
        B_Connect.UseVisualStyleBackColor = true;
        B_Connect.Click += B_Connect_Click;
        // 
        // L_SwitchIP
        // 
        L_SwitchIP.AutoSize = true;
        L_SwitchIP.Location = new Point(11, 14);
        L_SwitchIP.Name = "L_SwitchIP";
        L_SwitchIP.Size = new Size(58, 15);
        L_SwitchIP.TabIndex = 12;
        L_SwitchIP.Text = "Switch IP:";
        // 
        // TB_SwitchIP
        // 
        TB_SwitchIP.CharacterCasing = CharacterCasing.Lower;
        TB_SwitchIP.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SwitchIP.Location = new Point(95, 12);
        TB_SwitchIP.MaxLength = 15;
        TB_SwitchIP.Name = "TB_SwitchIP";
        TB_SwitchIP.Size = new Size(111, 22);
        TB_SwitchIP.TabIndex = 0;
        TB_SwitchIP.Text = "123.123.123.123";
        TB_SwitchIP.TextChanged += TB_SwitchIP_TextChanged;
        // 
        // GB_SAVInfo
        // 
        GB_SAVInfo.Controls.Add(L_Theme);
        GB_SAVInfo.Controls.Add(CB_Theme);
        GB_SAVInfo.Location = new Point(0, 65);
        GB_SAVInfo.Name = "GB_SAVInfo";
        GB_SAVInfo.Size = new Size(212, 48);
        GB_SAVInfo.TabIndex = 4;
        GB_SAVInfo.TabStop = false;
        // 
        // L_Theme
        // 
        L_Theme.AutoSize = true;
        L_Theme.Location = new Point(12, 19);
        L_Theme.Name = "L_Theme";
        L_Theme.Size = new Size(47, 15);
        L_Theme.TabIndex = 179;
        L_Theme.Text = "Theme:";
        // 
        // CB_Theme
        // 
        CB_Theme.FormattingEnabled = true;
        CB_Theme.Items.AddRange(new object[] { "Light", "System", "Dark" });
        CB_Theme.Location = new Point(95, 16);
        CB_Theme.Name = "CB_Theme";
        CB_Theme.Size = new Size(111, 23);
        CB_Theme.TabIndex = 178;
        CB_Theme.SelectedIndexChanged += CB_Theme_SelectedIndexChanged;
        // 
        // PB_Touch
        // 
        PB_Touch.Location = new Point(218, 6);
        PB_Touch.Name = "PB_Touch";
        PB_Touch.Size = new Size(1280, 720);
        PB_Touch.TabIndex = 5;
        PB_Touch.TabStop = false;
        PB_Touch.Click += PB_Touch_Click;
        PB_Touch.MouseMove += PB_Touch_MouseMove;
        // 
        // B_GetImage
        // 
        B_GetImage.Location = new Point(11, 115);
        B_GetImage.Name = "B_GetImage";
        B_GetImage.Size = new Size(195, 25);
        B_GetImage.TabIndex = 6;
        B_GetImage.Text = "Update Image";
        B_GetImage.UseVisualStyleBackColor = true;
        B_GetImage.Click += B_GetImage_Click;
        // 
        // CB_ClickToSend
        // 
        CB_ClickToSend.AutoSize = true;
        CB_ClickToSend.Location = new Point(12, 225);
        CB_ClickToSend.Name = "CB_ClickToSend";
        CB_ClickToSend.Size = new Size(167, 19);
        CB_ClickToSend.TabIndex = 7;
        CB_ClickToSend.Text = "Click Image to Send Touch";
        CB_ClickToSend.UseVisualStyleBackColor = true;
        CB_ClickToSend.CheckedChanged += CB_ClickToSend_CheckedChanged;
        // 
        // TB_CurrX
        // 
        TB_CurrX.CharacterCasing = CharacterCasing.Lower;
        TB_CurrX.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_CurrX.Location = new Point(172, 146);
        TB_CurrX.MaxLength = 15;
        TB_CurrX.Name = "TB_CurrX";
        TB_CurrX.Size = new Size(34, 22);
        TB_CurrX.TabIndex = 19;
        TB_CurrX.Text = "0000";
        TB_CurrX.TextAlign = HorizontalAlignment.Right;
        // 
        // TB_CurrY
        // 
        TB_CurrY.CharacterCasing = CharacterCasing.Lower;
        TB_CurrY.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_CurrY.Location = new Point(172, 170);
        TB_CurrY.MaxLength = 15;
        TB_CurrY.Name = "TB_CurrY";
        TB_CurrY.Size = new Size(34, 22);
        TB_CurrY.TabIndex = 20;
        TB_CurrY.Text = "0000";
        TB_CurrY.TextAlign = HorizontalAlignment.Right;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 148);
        label1.Name = "label1";
        label1.Size = new Size(60, 15);
        label1.TabIndex = 21;
        label1.Text = "Current X:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 172);
        label2.Name = "label2";
        label2.Size = new Size(60, 15);
        label2.TabIndex = 22;
        label2.Text = "Current Y:";
        // 
        // B_SetCursor
        // 
        B_SetCursor.Location = new Point(12, 194);
        B_SetCursor.Name = "B_SetCursor";
        B_SetCursor.Size = new Size(195, 25);
        B_SetCursor.TabIndex = 23;
        B_SetCursor.Text = "Set Cursor to Above";
        B_SetCursor.UseVisualStyleBackColor = true;
        B_SetCursor.Click += B_SetCursor_Click;
        // 
        // L_TouchDuration
        // 
        L_TouchDuration.AutoSize = true;
        L_TouchDuration.Location = new Point(12, 248);
        L_TouchDuration.Name = "L_TouchDuration";
        L_TouchDuration.Size = new Size(119, 15);
        L_TouchDuration.TabIndex = 25;
        L_TouchDuration.Text = "Touch Duration (ms):";
        // 
        // TB_TouchDuration
        // 
        TB_TouchDuration.CharacterCasing = CharacterCasing.Lower;
        TB_TouchDuration.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_TouchDuration.Location = new Point(172, 246);
        TB_TouchDuration.MaxLength = 15;
        TB_TouchDuration.Name = "TB_TouchDuration";
        TB_TouchDuration.Size = new Size(34, 22);
        TB_TouchDuration.TabIndex = 24;
        TB_TouchDuration.Text = "50";
        TB_TouchDuration.TextAlign = HorizontalAlignment.Right;
        TB_TouchDuration.TextChanged += TB_TouchDuration_TextChanged;
        // 
        // LB_Log
        // 
        LB_Log.FormattingEnabled = true;
        LB_Log.Location = new Point(12, 302);
        LB_Log.Name = "LB_Log";
        LB_Log.Size = new Size(194, 349);
        LB_Log.TabIndex = 26;
        // 
        // B_ClearSelected
        // 
        B_ClearSelected.Location = new Point(11, 274);
        B_ClearSelected.Name = "B_ClearSelected";
        B_ClearSelected.Size = new Size(195, 25);
        B_ClearSelected.TabIndex = 27;
        B_ClearSelected.Text = "Clear Selected from Log";
        B_ClearSelected.UseVisualStyleBackColor = true;
        B_ClearSelected.Click += B_ClearSelected_Click;
        // 
        // L_Test
        // 
        L_Test.AutoSize = true;
        L_Test.Location = new Point(12, 654);
        L_Test.Name = "L_Test";
        L_Test.Size = new Size(65, 15);
        L_Test.TabIndex = 29;
        L_Test.Text = "Test String:";
        // 
        // TB_Test
        // 
        TB_Test.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_Test.Location = new Point(12, 672);
        TB_Test.MaxLength = 15;
        TB_Test.Name = "TB_Test";
        TB_Test.Size = new Size(194, 22);
        TB_Test.TabIndex = 28;
        TB_Test.Text = "LegoFigure11";
        // 
        // B_TouchType
        // 
        B_TouchType.Location = new Point(11, 701);
        B_TouchType.Name = "B_TouchType";
        B_TouchType.Size = new Size(195, 25);
        B_TouchType.TabIndex = 30;
        B_TouchType.Text = "Touch Type!";
        B_TouchType.UseVisualStyleBackColor = true;
        B_TouchType.Click += B_TouchType_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1506, 733);
        Controls.Add(B_TouchType);
        Controls.Add(L_Test);
        Controls.Add(TB_Test);
        Controls.Add(B_ClearSelected);
        Controls.Add(LB_Log);
        Controls.Add(L_TouchDuration);
        Controls.Add(TB_TouchDuration);
        Controls.Add(B_SetCursor);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(TB_CurrY);
        Controls.Add(TB_CurrX);
        Controls.Add(CB_ClickToSend);
        Controls.Add(B_GetImage);
        Controls.Add(PB_Touch);
        Controls.Add(GB_Connection);
        Controls.Add(GB_SAVInfo);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "MainWindow";
        FormClosing += MainWindow_FormClosing;
        Load += MainWindow_Load;
        GB_Connection.ResumeLayout(false);
        GB_Connection.PerformLayout();
        GB_SAVInfo.ResumeLayout(false);
        GB_SAVInfo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PB_Touch).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox GB_Connection;
    private TextBox TB_Status;
    private Label L_Status;
    private Button B_Disconnect;
    private Button B_Connect;
    private Label L_SwitchIP;
    private TextBox TB_SwitchIP;
    private GroupBox GB_SAVInfo;
    private Label L_Theme;
    private ComboBox CB_Theme;
    private PictureBox PB_Touch;
    private Button B_GetImage;
    private CheckBox CB_ClickToSend;
    private TextBox TB_CurrX;
    private TextBox TB_CurrY;
    private Label label1;
    private Label label2;
    private Button B_SetCursor;
    private Label L_TouchDuration;
    private TextBox TB_TouchDuration;
    private ListBox LB_Log;
    private Button B_ClearSelected;
    private Label L_Test;
    private TextBox TB_Test;
    private Button B_TouchType;
}

