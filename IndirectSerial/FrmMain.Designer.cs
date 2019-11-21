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
            this.Content = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ABaud = new System.Windows.Forms.ComboBox();
            this.APortList = new System.Windows.Forms.ComboBox();
            this.LinkAB = new System.Windows.Forms.CheckBox();
            this.ClearDisplay = new System.Windows.Forms.Button();
            this.AClearHistory = new System.Windows.Forms.Button();
            this.ASend = new System.Windows.Forms.Button();
            this.AInput = new System.Windows.Forms.ComboBox();
            this.DisplayAsHex = new System.Windows.Forms.RadioButton();
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BBaud = new System.Windows.Forms.ComboBox();
            this.BPortList = new System.Windows.Forms.ComboBox();
            this.BClearHistory = new System.Windows.Forms.Button();
            this.BSend = new System.Windows.Forms.Button();
            this.BInput = new System.Windows.Forms.ComboBox();
            this.BClose = new System.Windows.Forms.Button();
            this.BOpen = new System.Windows.Forms.Button();
            this.BRts = new System.Windows.Forms.CheckBox();
            this.BDtr = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Content.Font = new System.Drawing.Font("Consolas", 12F);
            this.Content.Location = new System.Drawing.Point(7, 122);
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Size = new System.Drawing.Size(679, 315);
            this.Content.TabIndex = 16;
            this.Content.TabStop = false;
            this.Content.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ABaud);
            this.groupBox1.Controls.Add(this.APortList);
            this.groupBox1.Controls.Add(this.LinkAB);
            this.groupBox1.Controls.Add(this.ClearDisplay);
            this.groupBox1.Controls.Add(this.AClearHistory);
            this.groupBox1.Controls.Add(this.ASend);
            this.groupBox1.Controls.Add(this.AInput);
            this.groupBox1.Controls.Add(this.DisplayAsHex);
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
            this.groupBox1.Controls.Add(this.Content);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 514);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PORT A";
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
            // LinkAB
            // 
            this.LinkAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LinkAB.AutoSize = true;
            this.LinkAB.Location = new System.Drawing.Point(315, 86);
            this.LinkAB.Name = "LinkAB";
            this.LinkAB.Size = new System.Drawing.Size(102, 20);
            this.LinkAB.TabIndex = 13;
            this.LinkAB.Text = "Link A <-> B";
            this.LinkAB.UseVisualStyleBackColor = true;
            // 
            // ClearDisplay
            // 
            this.ClearDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearDisplay.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClearDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearDisplay.Location = new System.Drawing.Point(373, 479);
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
            this.AClearHistory.Location = new System.Drawing.Point(490, 479);
            this.AClearHistory.Name = "AClearHistory";
            this.AClearHistory.Size = new System.Drawing.Size(102, 29);
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
            this.ASend.Location = new System.Drawing.Point(600, 479);
            this.ASend.Name = "ASend";
            this.ASend.Size = new System.Drawing.Size(87, 29);
            this.ASend.TabIndex = 23;
            this.ASend.Text = "send";
            this.ASend.UseVisualStyleBackColor = false;
            this.ASend.Click += new System.EventHandler(this.ASend_Click);
            // 
            // AInput
            // 
            this.AInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AInput.Font = new System.Drawing.Font("Consolas", 12F);
            this.AInput.FormattingEnabled = true;
            this.AInput.Location = new System.Drawing.Point(8, 444);
            this.AInput.Name = "AInput";
            this.AInput.Size = new System.Drawing.Size(678, 27);
            this.AInput.TabIndex = 17;
            this.AInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AInput_KeyDown);
            // 
            // DisplayAsHex
            // 
            this.DisplayAsHex.AutoSize = true;
            this.DisplayAsHex.Location = new System.Drawing.Point(224, 483);
            this.DisplayAsHex.Name = "DisplayAsHex";
            this.DisplayAsHex.Size = new System.Drawing.Size(121, 20);
            this.DisplayAsHex.TabIndex = 20;
            this.DisplayAsHex.TabStop = true;
            this.DisplayAsHex.Text = "Display as HEX";
            this.DisplayAsHex.UseVisualStyleBackColor = true;
            // 
            // DisplayAsText
            // 
            this.DisplayAsText.AutoSize = true;
            this.DisplayAsText.Checked = true;
            this.DisplayAsText.Location = new System.Drawing.Point(104, 483);
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
            this.label2.Location = new System.Drawing.Point(496, 58);
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
            this.Prefix.Location = new System.Drawing.Point(612, 51);
            this.Prefix.Name = "Prefix";
            this.Prefix.Size = new System.Drawing.Size(36, 23);
            this.Prefix.TabIndex = 12;
            this.Prefix.Text = "h";
            // 
            // TimeoutNewlineCount
            // 
            this.TimeoutNewlineCount.Location = new System.Drawing.Point(427, 55);
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
            this.TimeoutNewlineEnable.Location = new System.Drawing.Point(315, 56);
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
            this.AClose.Location = new System.Drawing.Point(223, 23);
            this.AClose.Name = "AClose";
            this.AClose.Size = new System.Drawing.Size(85, 91);
            this.AClose.TabIndex = 6;
            this.AClose.Text = "close";
            this.AClose.UseVisualStyleBackColor = false;
            this.AClose.Click += new System.EventHandler(this.AClose_Click);
            // 
            // AOpen
            // 
            this.AOpen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.AOpen.Location = new System.Drawing.Point(131, 23);
            this.AOpen.Name = "AOpen";
            this.AOpen.Size = new System.Drawing.Size(85, 91);
            this.AOpen.TabIndex = 5;
            this.AOpen.Text = "open";
            this.AOpen.UseVisualStyleBackColor = false;
            this.AOpen.Click += new System.EventHandler(this.AOpen_Click);
            // 
            // ARts
            // 
            this.ARts.AutoSize = true;
            this.ARts.Location = new System.Drawing.Point(72, 94);
            this.ARts.Name = "ARts";
            this.ARts.Size = new System.Drawing.Size(55, 20);
            this.ARts.TabIndex = 4;
            this.ARts.Text = "RTS";
            this.ARts.UseVisualStyleBackColor = true;
            this.ARts.CheckedChanged += new System.EventHandler(this.ARts_CheckedChanged);
            // 
            // Autoscroll
            // 
            this.Autoscroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Autoscroll.AutoSize = true;
            this.Autoscroll.Checked = true;
            this.Autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Autoscroll.Location = new System.Drawing.Point(9, 483);
            this.Autoscroll.Name = "Autoscroll";
            this.Autoscroll.Size = new System.Drawing.Size(89, 20);
            this.Autoscroll.TabIndex = 18;
            this.Autoscroll.Text = "Autoscroll";
            this.Autoscroll.UseVisualStyleBackColor = true;
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSize = true;
            this.Timestamp.Location = new System.Drawing.Point(561, 86);
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.Size = new System.Drawing.Size(95, 20);
            this.Timestamp.TabIndex = 15;
            this.Timestamp.Text = "Timestamp";
            this.Timestamp.UseVisualStyleBackColor = true;
            // 
            // AppendNewlineEnable
            // 
            this.AppendNewlineEnable.AutoSize = true;
            this.AppendNewlineEnable.Location = new System.Drawing.Point(427, 85);
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
            this.ADtr.Location = new System.Drawing.Point(8, 94);
            this.ADtr.Name = "ADtr";
            this.ADtr.Size = new System.Drawing.Size(56, 20);
            this.ADtr.TabIndex = 3;
            this.ADtr.Text = "DTR";
            this.ADtr.UseVisualStyleBackColor = true;
            this.ADtr.CheckedChanged += new System.EventHandler(this.ADtr_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "suffix:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BBaud);
            this.groupBox2.Controls.Add(this.BPortList);
            this.groupBox2.Controls.Add(this.BClearHistory);
            this.groupBox2.Controls.Add(this.BSend);
            this.groupBox2.Controls.Add(this.BInput);
            this.groupBox2.Controls.Add(this.BClose);
            this.groupBox2.Controls.Add(this.BOpen);
            this.groupBox2.Controls.Add(this.BRts);
            this.groupBox2.Controls.Add(this.BDtr);
            this.groupBox2.Location = new System.Drawing.Point(15, 536);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 193);
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
            this.BClearHistory.Location = new System.Drawing.Point(489, 160);
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
            this.BSend.Location = new System.Drawing.Point(598, 160);
            this.BSend.Name = "BSend";
            this.BSend.Size = new System.Drawing.Size(87, 29);
            this.BSend.TabIndex = 32;
            this.BSend.Text = "send";
            this.BSend.UseVisualStyleBackColor = false;
            this.BSend.Click += new System.EventHandler(this.BSend_Click);
            // 
            // BInput
            // 
            this.BInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BInput.Font = new System.Drawing.Font("Consolas", 12F);
            this.BInput.FormattingEnabled = true;
            this.BInput.Location = new System.Drawing.Point(7, 127);
            this.BInput.Name = "BInput";
            this.BInput.Size = new System.Drawing.Size(678, 27);
            this.BInput.TabIndex = 30;
            this.BInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BInput_KeyDown);
            // 
            // BClose
            // 
            this.BClose.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BClose.Location = new System.Drawing.Point(223, 23);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(85, 91);
            this.BClose.TabIndex = 29;
            this.BClose.Text = "close";
            this.BClose.UseVisualStyleBackColor = false;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // BOpen
            // 
            this.BOpen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BOpen.Location = new System.Drawing.Point(131, 23);
            this.BOpen.Name = "BOpen";
            this.BOpen.Size = new System.Drawing.Size(85, 91);
            this.BOpen.TabIndex = 28;
            this.BOpen.Text = "open";
            this.BOpen.UseVisualStyleBackColor = false;
            this.BOpen.Click += new System.EventHandler(this.BOpen_Click);
            // 
            // BRts
            // 
            this.BRts.AutoSize = true;
            this.BRts.Location = new System.Drawing.Point(70, 94);
            this.BRts.Name = "BRts";
            this.BRts.Size = new System.Drawing.Size(55, 20);
            this.BRts.TabIndex = 27;
            this.BRts.Text = "RTS";
            this.BRts.UseVisualStyleBackColor = true;
            this.BRts.CheckedChanged += new System.EventHandler(this.BRts_CheckedChanged);
            // 
            // BDtr
            // 
            this.BDtr.AutoSize = true;
            this.BDtr.Location = new System.Drawing.Point(8, 94);
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
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(723, 742);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(739, 660);
            this.Name = "FrmMain";
            this.Text = "Indirect Serial";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox Content;
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
        private System.Windows.Forms.CheckBox LinkAB;
        private System.Windows.Forms.CheckBox Timestamp;
        private System.Windows.Forms.Label label3;
    }
}

