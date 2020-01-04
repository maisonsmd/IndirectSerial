namespace IndirectSerial {
    partial class FrmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ABaud = new System.Windows.Forms.ComboBox();
            this.APortList = new System.Windows.Forms.ComboBox();
            this.LinkSignal = new System.Windows.Forms.CheckBox();
            this.AutoReconnectA = new System.Windows.Forms.CheckBox();
            this.LinkData = new System.Windows.Forms.CheckBox();
            this.ClearDisplay = new System.Windows.Forms.Button();
            this.AClearHistory = new System.Windows.Forms.Button();
            this.ASend = new System.Windows.Forms.Button();
            this.ACts = new System.Windows.Forms.CheckBox();
            this.AInput = new System.Windows.Forms.ComboBox();
            this.DisplayAsHex = new System.Windows.Forms.RadioButton();
            this.ADsr = new System.Windows.Forms.CheckBox();
            this.DisplayAsText = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Prefix = new System.Windows.Forms.TextBox();
            this.TimeoutNewlineCount = new System.Windows.Forms.TextBox();
            this.BytesNewlineCount = new System.Windows.Forms.TextBox();
            this.TimeoutNewlineEnable = new System.Windows.Forms.CheckBox();
            this.BytesNewlineEnable = new System.Windows.Forms.CheckBox();
            this.AClose = new System.Windows.Forms.Button();
            this.AOpen = new System.Windows.Forms.Button();
            this.ARts = new System.Windows.Forms.CheckBox();
            this.Autoscroll = new System.Windows.Forms.CheckBox();
            this.Timestamp = new System.Windows.Forms.CheckBox();
            this.AppendNewlineEnable = new System.Windows.Forms.CheckBox();
            this.HexPrefixEnable = new System.Windows.Forms.CheckBox();
            this.ADtr = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BBaud = new System.Windows.Forms.ComboBox();
            this.BPortList = new System.Windows.Forms.ComboBox();
            this.BClearHistory = new System.Windows.Forms.Button();
            this.BSend = new System.Windows.Forms.Button();
            this.AutoReconnectB = new System.Windows.Forms.CheckBox();
            this.BInput = new System.Windows.Forms.ComboBox();
            this.BClose = new System.Windows.Forms.Button();
            this.BOpen = new System.Windows.Forms.Button();
            this.BCts = new System.Windows.Forms.CheckBox();
            this.BRts = new System.Windows.Forms.CheckBox();
            this.BDsr = new System.Windows.Forms.CheckBox();
            this.BDtr = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fctb);
            this.groupBox1.Controls.Add(this.ABaud);
            this.groupBox1.Controls.Add(this.APortList);
            this.groupBox1.Controls.Add(this.LinkSignal);
            this.groupBox1.Controls.Add(this.AutoReconnectA);
            this.groupBox1.Controls.Add(this.LinkData);
            this.groupBox1.Controls.Add(this.ClearDisplay);
            this.groupBox1.Controls.Add(this.AClearHistory);
            this.groupBox1.Controls.Add(this.ASend);
            this.groupBox1.Controls.Add(this.ACts);
            this.groupBox1.Controls.Add(this.AInput);
            this.groupBox1.Controls.Add(this.DisplayAsHex);
            this.groupBox1.Controls.Add(this.ADsr);
            this.groupBox1.Controls.Add(this.DisplayAsText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Prefix);
            this.groupBox1.Controls.Add(this.TimeoutNewlineCount);
            this.groupBox1.Controls.Add(this.BytesNewlineCount);
            this.groupBox1.Controls.Add(this.TimeoutNewlineEnable);
            this.groupBox1.Controls.Add(this.BytesNewlineEnable);
            this.groupBox1.Controls.Add(this.AClose);
            this.groupBox1.Controls.Add(this.AOpen);
            this.groupBox1.Controls.Add(this.ARts);
            this.groupBox1.Controls.Add(this.Autoscroll);
            this.groupBox1.Controls.Add(this.Timestamp);
            this.groupBox1.Controls.Add(this.AppendNewlineEnable);
            this.groupBox1.Controls.Add(this.HexPrefixEnable);
            this.groupBox1.Controls.Add(this.ADtr);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 570);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PORT A";
            // 
            // fctb
            // 
            this.fctb.AcceptsReturn = false;
            this.fctb.AcceptsTab = false;
            this.fctb.AllowMacroRecording = false;
            this.fctb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctb.AutoIndent = false;
            this.fctb.AutoIndentChars = false;
            this.fctb.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(29, 18);
            this.fctb.BackBrush = null;
            this.fctb.CaretBlinking = false;
            this.fctb.CharHeight = 18;
            this.fctb.CharWidth = 9;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Font = new System.Drawing.Font("Consolas", 12F);
            this.fctb.IndentBackColor = System.Drawing.Color.Beige;
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(7, 128);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(692, 366);
            this.fctb.TabIndex = 28;
            this.fctb.Zoom = 100;
            // 
            // ABaud
            // 
            this.ABaud.FormattingEnabled = true;
            this.ABaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.ABaud.Location = new System.Drawing.Point(7, 61);
            this.ABaud.Name = "ABaud";
            this.ABaud.Size = new System.Drawing.Size(116, 24);
            this.ABaud.TabIndex = 2;
            this.ABaud.DropDown += new System.EventHandler(this.APortList_DropDown);
            this.ABaud.SelectedIndexChanged += new System.EventHandler(this.ABaud_SelectedIndexChanged);
            // 
            // APortList
            // 
            this.APortList.FormattingEnabled = true;
            this.APortList.Location = new System.Drawing.Point(7, 27);
            this.APortList.Name = "APortList";
            this.APortList.Size = new System.Drawing.Size(116, 24);
            this.APortList.Sorted = true;
            this.APortList.TabIndex = 1;
            this.APortList.DropDown += new System.EventHandler(this.APortList_DropDown);
            // 
            // LinkSignal
            // 
            this.LinkSignal.AutoSize = true;
            this.LinkSignal.Location = new System.Drawing.Point(315, 104);
            this.LinkSignal.Name = "LinkSignal";
            this.LinkSignal.Size = new System.Drawing.Size(103, 20);
            this.LinkSignal.TabIndex = 13;
            this.LinkSignal.Text = "Link Signals";
            this.LinkSignal.UseVisualStyleBackColor = true;
            this.LinkSignal.CheckedChanged += new System.EventHandler(this.LinkSignal_CheckedChanged);
            // 
            // AutoReconnectA
            // 
            this.AutoReconnectA.AutoSize = true;
            this.AutoReconnectA.Location = new System.Drawing.Point(131, 65);
            this.AutoReconnectA.Name = "AutoReconnectA";
            this.AutoReconnectA.Size = new System.Drawing.Size(123, 20);
            this.AutoReconnectA.TabIndex = 13;
            this.AutoReconnectA.Text = "Auto reconnect";
            this.AutoReconnectA.UseVisualStyleBackColor = true;
            // 
            // LinkData
            // 
            this.LinkData.AutoSize = true;
            this.LinkData.Location = new System.Drawing.Point(315, 78);
            this.LinkData.Name = "LinkData";
            this.LinkData.Size = new System.Drawing.Size(87, 20);
            this.LinkData.TabIndex = 13;
            this.LinkData.Text = "Link Data";
            this.LinkData.UseVisualStyleBackColor = true;
            this.LinkData.CheckedChanged += new System.EventHandler(this.LinkData_CheckedChanged);
            // 
            // ClearDisplay
            // 
            this.ClearDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearDisplay.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClearDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearDisplay.Location = new System.Drawing.Point(384, 535);
            this.ClearDisplay.Name = "ClearDisplay";
            this.ClearDisplay.Size = new System.Drawing.Size(111, 29);
            this.ClearDisplay.TabIndex = 21;
            this.ClearDisplay.Text = "clear display";
            this.ClearDisplay.UseVisualStyleBackColor = false;
            this.ClearDisplay.Click += new System.EventHandler(this.ClearDisplay_Click);
            // 
            // AClearHistory
            // 
            this.AClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AClearHistory.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.AClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AClearHistory.Location = new System.Drawing.Point(501, 535);
            this.AClearHistory.Name = "AClearHistory";
            this.AClearHistory.Size = new System.Drawing.Size(99, 29);
            this.AClearHistory.TabIndex = 22;
            this.AClearHistory.Text = "clear history";
            this.AClearHistory.UseVisualStyleBackColor = false;
            this.AClearHistory.Click += new System.EventHandler(this.AClearHistory_Click);
            // 
            // ASend
            // 
            this.ASend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ASend.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ASend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ASend.Location = new System.Drawing.Point(606, 535);
            this.ASend.Name = "ASend";
            this.ASend.Size = new System.Drawing.Size(92, 29);
            this.ASend.TabIndex = 23;
            this.ASend.Text = "send";
            this.ASend.UseVisualStyleBackColor = false;
            this.ASend.Click += new System.EventHandler(this.ASend_Click);
            // 
            // ACts
            // 
            this.ACts.AutoSize = true;
            this.ACts.Enabled = false;
            this.ACts.Location = new System.Drawing.Point(191, 102);
            this.ACts.Name = "ACts";
            this.ACts.Size = new System.Drawing.Size(55, 20);
            this.ACts.TabIndex = 27;
            this.ACts.Text = "CTS";
            this.ACts.UseVisualStyleBackColor = true;
            // 
            // AInput
            // 
            this.AInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AInput.Font = new System.Drawing.Font("Consolas", 12F);
            this.AInput.FormattingEnabled = true;
            this.AInput.Location = new System.Drawing.Point(8, 500);
            this.AInput.Name = "AInput";
            this.AInput.Size = new System.Drawing.Size(689, 27);
            this.AInput.TabIndex = 17;
            this.AInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AInput_KeyDown);
            // 
            // DisplayAsHex
            // 
            this.DisplayAsHex.AutoSize = true;
            this.DisplayAsHex.Location = new System.Drawing.Point(561, 104);
            this.DisplayAsHex.Name = "DisplayAsHex";
            this.DisplayAsHex.Size = new System.Drawing.Size(121, 20);
            this.DisplayAsHex.TabIndex = 20;
            this.DisplayAsHex.TabStop = true;
            this.DisplayAsHex.Text = "Display as HEX";
            this.DisplayAsHex.UseVisualStyleBackColor = true;
            // 
            // ADsr
            // 
            this.ADsr.AutoSize = true;
            this.ADsr.Enabled = false;
            this.ADsr.Location = new System.Drawing.Point(130, 102);
            this.ADsr.Name = "ADsr";
            this.ADsr.Size = new System.Drawing.Size(56, 20);
            this.ADsr.TabIndex = 26;
            this.ADsr.Text = "DSR";
            this.ADsr.UseVisualStyleBackColor = true;
            // 
            // DisplayAsText
            // 
            this.DisplayAsText.AutoSize = true;
            this.DisplayAsText.Checked = true;
            this.DisplayAsText.Location = new System.Drawing.Point(427, 104);
            this.DisplayAsText.Name = "DisplayAsText";
            this.DisplayAsText.Size = new System.Drawing.Size(120, 20);
            this.DisplayAsText.TabIndex = 19;
            this.DisplayAsText.TabStop = true;
            this.DisplayAsText.Text = "Display as Text";
            this.DisplayAsText.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "ms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "bytes";
            // 
            // Prefix
            // 
            this.Prefix.Location = new System.Drawing.Point(649, 25);
            this.Prefix.Name = "Prefix";
            this.Prefix.Size = new System.Drawing.Size(36, 23);
            this.Prefix.TabIndex = 12;
            this.Prefix.Text = "h";
            // 
            // TimeoutNewlineCount
            // 
            this.TimeoutNewlineCount.Location = new System.Drawing.Point(427, 51);
            this.TimeoutNewlineCount.Name = "TimeoutNewlineCount";
            this.TimeoutNewlineCount.Size = new System.Drawing.Size(61, 23);
            this.TimeoutNewlineCount.TabIndex = 10;
            this.TimeoutNewlineCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeoutNewlineCount_KeyDown);
            // 
            // BytesNewlineCount
            // 
            this.BytesNewlineCount.Location = new System.Drawing.Point(427, 25);
            this.BytesNewlineCount.Name = "BytesNewlineCount";
            this.BytesNewlineCount.Size = new System.Drawing.Size(61, 23);
            this.BytesNewlineCount.TabIndex = 8;
            this.BytesNewlineCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BytesNewlineCount_KeyDown);
            // 
            // TimeoutNewlineEnable
            // 
            this.TimeoutNewlineEnable.AutoSize = true;
            this.TimeoutNewlineEnable.Checked = true;
            this.TimeoutNewlineEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TimeoutNewlineEnable.Location = new System.Drawing.Point(315, 52);
            this.TimeoutNewlineEnable.Name = "TimeoutNewlineEnable";
            this.TimeoutNewlineEnable.Size = new System.Drawing.Size(108, 20);
            this.TimeoutNewlineEnable.TabIndex = 9;
            this.TimeoutNewlineEnable.Text = "Newline after";
            this.TimeoutNewlineEnable.UseVisualStyleBackColor = true;
            // 
            // BytesNewlineEnable
            // 
            this.BytesNewlineEnable.AutoSize = true;
            this.BytesNewlineEnable.Location = new System.Drawing.Point(315, 26);
            this.BytesNewlineEnable.Name = "BytesNewlineEnable";
            this.BytesNewlineEnable.Size = new System.Drawing.Size(108, 20);
            this.BytesNewlineEnable.TabIndex = 7;
            this.BytesNewlineEnable.Text = "Newline after";
            this.BytesNewlineEnable.UseVisualStyleBackColor = true;
            // 
            // AClose
            // 
            this.AClose.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.AClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AClose.Location = new System.Drawing.Point(223, 25);
            this.AClose.Name = "AClose";
            this.AClose.Size = new System.Drawing.Size(85, 28);
            this.AClose.TabIndex = 6;
            this.AClose.Text = "close";
            this.AClose.UseVisualStyleBackColor = false;
            this.AClose.Click += new System.EventHandler(this.AClose_Click);
            // 
            // AOpen
            // 
            this.AOpen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.AOpen.Location = new System.Drawing.Point(131, 25);
            this.AOpen.Name = "AOpen";
            this.AOpen.Size = new System.Drawing.Size(85, 28);
            this.AOpen.TabIndex = 5;
            this.AOpen.Text = "open";
            this.AOpen.UseVisualStyleBackColor = false;
            this.AOpen.Click += new System.EventHandler(this.AOpen_Click);
            // 
            // ARts
            // 
            this.ARts.AutoSize = true;
            this.ARts.Location = new System.Drawing.Point(68, 102);
            this.ARts.Name = "ARts";
            this.ARts.Size = new System.Drawing.Size(55, 20);
            this.ARts.TabIndex = 4;
            this.ARts.Text = "RTS";
            this.ARts.UseVisualStyleBackColor = true;
            this.ARts.CheckedChanged += new System.EventHandler(this.ARts_CheckedChanged);
            // 
            // Autoscroll
            // 
            this.Autoscroll.AutoSize = true;
            this.Autoscroll.Checked = true;
            this.Autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Autoscroll.Location = new System.Drawing.Point(561, 52);
            this.Autoscroll.Name = "Autoscroll";
            this.Autoscroll.Size = new System.Drawing.Size(89, 20);
            this.Autoscroll.TabIndex = 18;
            this.Autoscroll.Text = "Autoscroll";
            this.Autoscroll.UseVisualStyleBackColor = true;
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSize = true;
            this.Timestamp.Location = new System.Drawing.Point(561, 78);
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.Size = new System.Drawing.Size(95, 20);
            this.Timestamp.TabIndex = 15;
            this.Timestamp.Text = "Timestamp";
            this.Timestamp.UseVisualStyleBackColor = true;
            // 
            // AppendNewlineEnable
            // 
            this.AppendNewlineEnable.AutoSize = true;
            this.AppendNewlineEnable.Location = new System.Drawing.Point(427, 78);
            this.AppendNewlineEnable.Name = "AppendNewlineEnable";
            this.AppendNewlineEnable.Size = new System.Drawing.Size(128, 20);
            this.AppendNewlineEnable.TabIndex = 14;
            this.AppendNewlineEnable.Text = "Append Newline";
            this.AppendNewlineEnable.UseVisualStyleBackColor = true;
            // 
            // HexPrefixEnable
            // 
            this.HexPrefixEnable.AutoSize = true;
            this.HexPrefixEnable.Location = new System.Drawing.Point(561, 26);
            this.HexPrefixEnable.Name = "HexPrefixEnable";
            this.HexPrefixEnable.Size = new System.Drawing.Size(91, 20);
            this.HexPrefixEnable.TabIndex = 11;
            this.HexPrefixEnable.Text = "HEX prefix";
            this.HexPrefixEnable.UseVisualStyleBackColor = true;
            // 
            // ADtr
            // 
            this.ADtr.AutoSize = true;
            this.ADtr.Location = new System.Drawing.Point(7, 102);
            this.ADtr.Name = "ADtr";
            this.ADtr.Size = new System.Drawing.Size(56, 20);
            this.ADtr.TabIndex = 3;
            this.ADtr.Text = "DTR";
            this.ADtr.UseVisualStyleBackColor = true;
            this.ADtr.CheckedChanged += new System.EventHandler(this.ADtr_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BBaud);
            this.groupBox2.Controls.Add(this.BPortList);
            this.groupBox2.Controls.Add(this.BClearHistory);
            this.groupBox2.Controls.Add(this.BSend);
            this.groupBox2.Controls.Add(this.AutoReconnectB);
            this.groupBox2.Controls.Add(this.BInput);
            this.groupBox2.Controls.Add(this.BClose);
            this.groupBox2.Controls.Add(this.BOpen);
            this.groupBox2.Controls.Add(this.BCts);
            this.groupBox2.Controls.Add(this.BRts);
            this.groupBox2.Controls.Add(this.BDsr);
            this.groupBox2.Controls.Add(this.BDtr);
            this.groupBox2.Location = new System.Drawing.Point(6, 588);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 194);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PORT B";
            // 
            // BBaud
            // 
            this.BBaud.FormattingEnabled = true;
            this.BBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.BBaud.Location = new System.Drawing.Point(7, 61);
            this.BBaud.Name = "BBaud";
            this.BBaud.Size = new System.Drawing.Size(116, 24);
            this.BBaud.TabIndex = 25;
            this.BBaud.DropDown += new System.EventHandler(this.APortList_DropDown);
            this.BBaud.SelectedIndexChanged += new System.EventHandler(this.BBaud_SelectedIndexChanged);
            // 
            // BPortList
            // 
            this.BPortList.FormattingEnabled = true;
            this.BPortList.Location = new System.Drawing.Point(7, 27);
            this.BPortList.Name = "BPortList";
            this.BPortList.Size = new System.Drawing.Size(116, 24);
            this.BPortList.Sorted = true;
            this.BPortList.TabIndex = 24;
            this.BPortList.DropDown += new System.EventHandler(this.BPortList_DropDown);
            // 
            // BClearHistory
            // 
            this.BClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BClearHistory.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClearHistory.Location = new System.Drawing.Point(498, 159);
            this.BClearHistory.Name = "BClearHistory";
            this.BClearHistory.Size = new System.Drawing.Size(102, 29);
            this.BClearHistory.TabIndex = 31;
            this.BClearHistory.Text = "clear history";
            this.BClearHistory.UseVisualStyleBackColor = false;
            this.BClearHistory.Click += new System.EventHandler(this.BClearHistory_Click);
            // 
            // BSend
            // 
            this.BSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSend.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSend.Location = new System.Drawing.Point(606, 159);
            this.BSend.Name = "BSend";
            this.BSend.Size = new System.Drawing.Size(87, 29);
            this.BSend.TabIndex = 32;
            this.BSend.Text = "send";
            this.BSend.UseVisualStyleBackColor = false;
            this.BSend.Click += new System.EventHandler(this.BSend_Click);
            // 
            // AutoReconnectB
            // 
            this.AutoReconnectB.AutoSize = true;
            this.AutoReconnectB.Location = new System.Drawing.Point(131, 63);
            this.AutoReconnectB.Name = "AutoReconnectB";
            this.AutoReconnectB.Size = new System.Drawing.Size(123, 20);
            this.AutoReconnectB.TabIndex = 13;
            this.AutoReconnectB.Text = "Auto reconnect";
            this.AutoReconnectB.UseVisualStyleBackColor = true;
            // 
            // BInput
            // 
            this.BInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BInput.Font = new System.Drawing.Font("Consolas", 12F);
            this.BInput.FormattingEnabled = true;
            this.BInput.Location = new System.Drawing.Point(6, 126);
            this.BInput.Name = "BInput";
            this.BInput.Size = new System.Drawing.Size(687, 27);
            this.BInput.TabIndex = 30;
            this.BInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BInput_KeyDown);
            // 
            // BClose
            // 
            this.BClose.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BClose.Location = new System.Drawing.Point(223, 25);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(85, 28);
            this.BClose.TabIndex = 29;
            this.BClose.Text = "close";
            this.BClose.UseVisualStyleBackColor = false;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // BOpen
            // 
            this.BOpen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BOpen.Location = new System.Drawing.Point(131, 25);
            this.BOpen.Name = "BOpen";
            this.BOpen.Size = new System.Drawing.Size(85, 28);
            this.BOpen.TabIndex = 28;
            this.BOpen.Text = "open";
            this.BOpen.UseVisualStyleBackColor = false;
            this.BOpen.Click += new System.EventHandler(this.BOpen_Click);
            // 
            // BCts
            // 
            this.BCts.AutoSize = true;
            this.BCts.Enabled = false;
            this.BCts.Location = new System.Drawing.Point(191, 100);
            this.BCts.Name = "BCts";
            this.BCts.Size = new System.Drawing.Size(55, 20);
            this.BCts.TabIndex = 27;
            this.BCts.Text = "CTS";
            this.BCts.UseVisualStyleBackColor = true;
            // 
            // BRts
            // 
            this.BRts.AutoSize = true;
            this.BRts.Location = new System.Drawing.Point(69, 100);
            this.BRts.Name = "BRts";
            this.BRts.Size = new System.Drawing.Size(55, 20);
            this.BRts.TabIndex = 27;
            this.BRts.Text = "RTS";
            this.BRts.UseVisualStyleBackColor = true;
            this.BRts.CheckedChanged += new System.EventHandler(this.BRts_CheckedChanged);
            // 
            // BDsr
            // 
            this.BDsr.AutoSize = true;
            this.BDsr.Enabled = false;
            this.BDsr.Location = new System.Drawing.Point(130, 100);
            this.BDsr.Name = "BDsr";
            this.BDsr.Size = new System.Drawing.Size(56, 20);
            this.BDsr.TabIndex = 26;
            this.BDsr.Text = "DSR";
            this.BDsr.UseVisualStyleBackColor = true;
            // 
            // BDtr
            // 
            this.BDtr.AutoSize = true;
            this.BDtr.Location = new System.Drawing.Point(8, 100);
            this.BDtr.Name = "BDtr";
            this.BDtr.Size = new System.Drawing.Size(56, 20);
            this.BDtr.TabIndex = 26;
            this.BDtr.Text = "DTR";
            this.BDtr.UseVisualStyleBackColor = true;
            this.BDtr.CheckedChanged += new System.EventHandler(this.BDtr_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 794);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(739, 660);
            this.Name = "FrmMain";
            this.Text = "Indirect Serial";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AClose;
        private System.Windows.Forms.Button AOpen;
        private System.Windows.Forms.CheckBox ARts;
        private System.Windows.Forms.CheckBox ADtr;
        private System.Windows.Forms.ComboBox APortList;
        private System.Windows.Forms.Button ClearDisplay;
        private System.Windows.Forms.Button AClearHistory;
        private System.Windows.Forms.Button ASend;
        private System.Windows.Forms.ComboBox AInput;
        private System.Windows.Forms.RadioButton DisplayAsHex;
        private System.Windows.Forms.RadioButton DisplayAsText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TimeoutNewlineCount;
        private System.Windows.Forms.TextBox BytesNewlineCount;
        private System.Windows.Forms.CheckBox TimeoutNewlineEnable;
        private System.Windows.Forms.CheckBox BytesNewlineEnable;
        private System.Windows.Forms.CheckBox HexPrefixEnable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox BPortList;
        private System.Windows.Forms.Button BClearHistory;
        private System.Windows.Forms.Button BSend;
        private System.Windows.Forms.ComboBox BInput;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.Button BOpen;
        private System.Windows.Forms.CheckBox BRts;
        private System.Windows.Forms.CheckBox BDtr;
        private System.Windows.Forms.ComboBox ABaud;
        private System.Windows.Forms.ComboBox BBaud;
        private System.Windows.Forms.CheckBox AppendNewlineEnable;
        private System.Windows.Forms.CheckBox Autoscroll;
        private System.Windows.Forms.TextBox Prefix;
        private System.Windows.Forms.CheckBox LinkData;
        private System.Windows.Forms.CheckBox Timestamp;
        private System.Windows.Forms.CheckBox LinkSignal;
        private System.Windows.Forms.CheckBox BCts;
        private System.Windows.Forms.CheckBox BDsr;
        private System.Windows.Forms.CheckBox ACts;
        private System.Windows.Forms.CheckBox ADsr;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.CheckBox AutoReconnectA;
        private System.Windows.Forms.CheckBox AutoReconnectB;
    }
}

