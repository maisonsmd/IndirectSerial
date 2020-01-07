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
            this.a_cbDtr = new System.Windows.Forms.CheckBox();
            this.cbHexPrefix = new System.Windows.Forms.CheckBox();
            this.Timestamp = new System.Windows.Forms.CheckBox();
            this.cbAutoscroll = new System.Windows.Forms.CheckBox();
            this.a_cbRts = new System.Windows.Forms.CheckBox();
            this.a_btOpen = new System.Windows.Forms.Button();
            this.cbBytesNewline = new System.Windows.Forms.CheckBox();
            this.cbTimeoutNewline = new System.Windows.Forms.CheckBox();
            this.tbBytesNewline = new System.Windows.Forms.TextBox();
            this.tbTimeoutNewline = new System.Windows.Forms.TextBox();
            this.tbHexPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.a_cbDsr = new System.Windows.Forms.CheckBox();
            this.a_cbCts = new System.Windows.Forms.CheckBox();
            this.b_btConnect = new System.Windows.Forms.Button();
            this.a_cbAutoReconnect = new System.Windows.Forms.CheckBox();
            this.b_cbDtr = new System.Windows.Forms.CheckBox();
            this.b_cbAutoReconnect = new System.Windows.Forms.CheckBox();
            this.b_cbDsr = new System.Windows.Forms.CheckBox();
            this.a_cbPortList = new System.Windows.Forms.ComboBox();
            this.b_cbRts = new System.Windows.Forms.CheckBox();
            this.a_cbBaudList = new System.Windows.Forms.ComboBox();
            this.b_cbCts = new System.Windows.Forms.CheckBox();
            this.b_cbPortList = new System.Windows.Forms.ComboBox();
            this.tbOutput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.b_cbBaudList = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.a_tbInput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.inputContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btLinkData = new System.Windows.Forms.Button();
            this.btLinkSignal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.a_tbInput)).BeginInit();
            this.inputContextMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // a_cbDtr
            // 
            this.a_cbDtr.AutoSize = true;
            this.a_cbDtr.Location = new System.Drawing.Point(6, 82);
            this.a_cbDtr.Name = "a_cbDtr";
            this.a_cbDtr.Size = new System.Drawing.Size(56, 20);
            this.a_cbDtr.TabIndex = 3;
            this.a_cbDtr.Text = "DTR";
            this.a_cbDtr.UseVisualStyleBackColor = true;
            this.a_cbDtr.CheckedChanged += new System.EventHandler(this.a_cbDtr_CheckedChanged);
            // 
            // cbHexPrefix
            // 
            this.cbHexPrefix.AutoSize = true;
            this.cbHexPrefix.Location = new System.Drawing.Point(256, 221);
            this.cbHexPrefix.Name = "cbHexPrefix";
            this.cbHexPrefix.Size = new System.Drawing.Size(91, 20);
            this.cbHexPrefix.TabIndex = 11;
            this.cbHexPrefix.Text = "HEX prefix";
            this.cbHexPrefix.UseVisualStyleBackColor = true;
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSize = true;
            this.Timestamp.Location = new System.Drawing.Point(508, 430);
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.Size = new System.Drawing.Size(95, 20);
            this.Timestamp.TabIndex = 15;
            this.Timestamp.Text = "Timestamp";
            this.Timestamp.UseVisualStyleBackColor = true;
            // 
            // cbAutoscroll
            // 
            this.cbAutoscroll.AutoSize = true;
            this.cbAutoscroll.Checked = true;
            this.cbAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoscroll.Location = new System.Drawing.Point(256, 247);
            this.cbAutoscroll.Name = "cbAutoscroll";
            this.cbAutoscroll.Size = new System.Drawing.Size(89, 20);
            this.cbAutoscroll.TabIndex = 18;
            this.cbAutoscroll.Text = "Autoscroll";
            this.cbAutoscroll.UseVisualStyleBackColor = true;
            // 
            // a_cbRts
            // 
            this.a_cbRts.AutoSize = true;
            this.a_cbRts.Location = new System.Drawing.Point(67, 82);
            this.a_cbRts.Name = "a_cbRts";
            this.a_cbRts.Size = new System.Drawing.Size(55, 20);
            this.a_cbRts.TabIndex = 4;
            this.a_cbRts.Text = "RTS";
            this.a_cbRts.UseVisualStyleBackColor = true;
            this.a_cbRts.CheckedChanged += new System.EventHandler(this.a_cbRts_CheckedChanged);
            // 
            // a_btOpen
            // 
            this.a_btOpen.BackColor = System.Drawing.Color.Transparent;
            this.a_btOpen.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.a_btOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_btOpen.Location = new System.Drawing.Point(130, 22);
            this.a_btOpen.Name = "a_btOpen";
            this.a_btOpen.Size = new System.Drawing.Size(115, 24);
            this.a_btOpen.TabIndex = 5;
            this.a_btOpen.Text = "open";
            this.a_btOpen.UseVisualStyleBackColor = false;
            this.a_btOpen.Click += new System.EventHandler(this.a_btConnect_Click);
            // 
            // cbBytesNewline
            // 
            this.cbBytesNewline.AutoSize = true;
            this.cbBytesNewline.Location = new System.Drawing.Point(12, 221);
            this.cbBytesNewline.Name = "cbBytesNewline";
            this.cbBytesNewline.Size = new System.Drawing.Size(108, 20);
            this.cbBytesNewline.TabIndex = 7;
            this.cbBytesNewline.Text = "Newline after";
            this.cbBytesNewline.UseVisualStyleBackColor = true;
            // 
            // cbTimeoutNewline
            // 
            this.cbTimeoutNewline.AutoSize = true;
            this.cbTimeoutNewline.Checked = true;
            this.cbTimeoutNewline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTimeoutNewline.Location = new System.Drawing.Point(12, 247);
            this.cbTimeoutNewline.Name = "cbTimeoutNewline";
            this.cbTimeoutNewline.Size = new System.Drawing.Size(108, 20);
            this.cbTimeoutNewline.TabIndex = 9;
            this.cbTimeoutNewline.Text = "Newline after";
            this.cbTimeoutNewline.UseVisualStyleBackColor = true;
            // 
            // tbBytesNewline
            // 
            this.tbBytesNewline.Location = new System.Drawing.Point(124, 220);
            this.tbBytesNewline.Name = "tbBytesNewline";
            this.tbBytesNewline.Size = new System.Drawing.Size(61, 23);
            this.tbBytesNewline.TabIndex = 8;
            this.tbBytesNewline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBytesNewline_KeyDown);
            // 
            // tbTimeoutNewline
            // 
            this.tbTimeoutNewline.Location = new System.Drawing.Point(124, 246);
            this.tbTimeoutNewline.Name = "tbTimeoutNewline";
            this.tbTimeoutNewline.Size = new System.Drawing.Size(61, 23);
            this.tbTimeoutNewline.TabIndex = 10;
            this.tbTimeoutNewline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTimeoutNewline_KeyDown);
            // 
            // tbHexPrefix
            // 
            this.tbHexPrefix.Location = new System.Drawing.Point(346, 220);
            this.tbHexPrefix.Name = "tbHexPrefix";
            this.tbHexPrefix.Size = new System.Drawing.Size(36, 23);
            this.tbHexPrefix.TabIndex = 12;
            this.tbHexPrefix.Text = "h";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "bytes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "ms";
            // 
            // a_cbDsr
            // 
            this.a_cbDsr.AutoSize = true;
            this.a_cbDsr.Enabled = false;
            this.a_cbDsr.Location = new System.Drawing.Point(129, 82);
            this.a_cbDsr.Name = "a_cbDsr";
            this.a_cbDsr.Size = new System.Drawing.Size(56, 20);
            this.a_cbDsr.TabIndex = 26;
            this.a_cbDsr.Text = "DSR";
            this.a_cbDsr.UseVisualStyleBackColor = true;
            // 
            // a_cbCts
            // 
            this.a_cbCts.AutoSize = true;
            this.a_cbCts.Enabled = false;
            this.a_cbCts.Location = new System.Drawing.Point(190, 82);
            this.a_cbCts.Name = "a_cbCts";
            this.a_cbCts.Size = new System.Drawing.Size(55, 20);
            this.a_cbCts.TabIndex = 27;
            this.a_cbCts.Text = "CTS";
            this.a_cbCts.UseVisualStyleBackColor = true;
            // 
            // b_btConnect
            // 
            this.b_btConnect.BackColor = System.Drawing.Color.Transparent;
            this.b_btConnect.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.b_btConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_btConnect.Location = new System.Drawing.Point(212, 20);
            this.b_btConnect.Name = "b_btConnect";
            this.b_btConnect.Size = new System.Drawing.Size(114, 24);
            this.b_btConnect.TabIndex = 28;
            this.b_btConnect.Text = "open";
            this.b_btConnect.UseVisualStyleBackColor = false;
            this.b_btConnect.Click += new System.EventHandler(this.b_btConnect_Click);
            // 
            // a_cbAutoReconnect
            // 
            this.a_cbAutoReconnect.AutoSize = true;
            this.a_cbAutoReconnect.Location = new System.Drawing.Point(130, 55);
            this.a_cbAutoReconnect.Name = "a_cbAutoReconnect";
            this.a_cbAutoReconnect.Size = new System.Drawing.Size(123, 20);
            this.a_cbAutoReconnect.TabIndex = 13;
            this.a_cbAutoReconnect.Text = "Auto reconnect";
            this.a_cbAutoReconnect.UseVisualStyleBackColor = true;
            // 
            // b_cbDtr
            // 
            this.b_cbDtr.AutoSize = true;
            this.b_cbDtr.Location = new System.Drawing.Point(88, 84);
            this.b_cbDtr.Name = "b_cbDtr";
            this.b_cbDtr.Size = new System.Drawing.Size(56, 20);
            this.b_cbDtr.TabIndex = 26;
            this.b_cbDtr.Text = "DTR";
            this.b_cbDtr.UseVisualStyleBackColor = true;
            this.b_cbDtr.CheckedChanged += new System.EventHandler(this.b_cbDtr_CheckedChanged);
            // 
            // b_cbAutoReconnect
            // 
            this.b_cbAutoReconnect.AutoSize = true;
            this.b_cbAutoReconnect.Location = new System.Drawing.Point(212, 54);
            this.b_cbAutoReconnect.Name = "b_cbAutoReconnect";
            this.b_cbAutoReconnect.Size = new System.Drawing.Size(123, 20);
            this.b_cbAutoReconnect.TabIndex = 13;
            this.b_cbAutoReconnect.Text = "Auto reconnect";
            this.b_cbAutoReconnect.UseVisualStyleBackColor = true;
            // 
            // b_cbDsr
            // 
            this.b_cbDsr.AutoSize = true;
            this.b_cbDsr.Enabled = false;
            this.b_cbDsr.Location = new System.Drawing.Point(210, 84);
            this.b_cbDsr.Name = "b_cbDsr";
            this.b_cbDsr.Size = new System.Drawing.Size(56, 20);
            this.b_cbDsr.TabIndex = 26;
            this.b_cbDsr.Text = "DSR";
            this.b_cbDsr.UseVisualStyleBackColor = true;
            // 
            // a_cbPortList
            // 
            this.a_cbPortList.FormattingEnabled = true;
            this.a_cbPortList.Location = new System.Drawing.Point(6, 22);
            this.a_cbPortList.Name = "a_cbPortList";
            this.a_cbPortList.Size = new System.Drawing.Size(116, 24);
            this.a_cbPortList.Sorted = true;
            this.a_cbPortList.TabIndex = 1;
            this.a_cbPortList.DropDown += new System.EventHandler(this.a_portList_DropDown);
            // 
            // b_cbRts
            // 
            this.b_cbRts.AutoSize = true;
            this.b_cbRts.Location = new System.Drawing.Point(149, 84);
            this.b_cbRts.Name = "b_cbRts";
            this.b_cbRts.Size = new System.Drawing.Size(55, 20);
            this.b_cbRts.TabIndex = 27;
            this.b_cbRts.Text = "RTS";
            this.b_cbRts.UseVisualStyleBackColor = true;
            this.b_cbRts.CheckedChanged += new System.EventHandler(this.b_cbRts_CheckedChanged);
            // 
            // a_cbBaudList
            // 
            this.a_cbBaudList.FormattingEnabled = true;
            this.a_cbBaudList.Items.AddRange(new object[] {
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
            this.a_cbBaudList.Location = new System.Drawing.Point(6, 52);
            this.a_cbBaudList.Name = "a_cbBaudList";
            this.a_cbBaudList.Size = new System.Drawing.Size(116, 24);
            this.a_cbBaudList.TabIndex = 2;
            this.a_cbBaudList.SelectedIndexChanged += new System.EventHandler(this.a_cbBaudList_SelectedIndexChanged);
            // 
            // b_cbCts
            // 
            this.b_cbCts.AutoSize = true;
            this.b_cbCts.Enabled = false;
            this.b_cbCts.Location = new System.Drawing.Point(271, 84);
            this.b_cbCts.Name = "b_cbCts";
            this.b_cbCts.Size = new System.Drawing.Size(55, 20);
            this.b_cbCts.TabIndex = 27;
            this.b_cbCts.Text = "CTS";
            this.b_cbCts.UseVisualStyleBackColor = true;
            // 
            // b_cbPortList
            // 
            this.b_cbPortList.FormattingEnabled = true;
            this.b_cbPortList.Location = new System.Drawing.Point(88, 20);
            this.b_cbPortList.Name = "b_cbPortList";
            this.b_cbPortList.Size = new System.Drawing.Size(116, 24);
            this.b_cbPortList.Sorted = true;
            this.b_cbPortList.TabIndex = 24;
            this.b_cbPortList.DropDown += new System.EventHandler(this.b_cbPortList_DropDown);
            // 
            // tbOutput
            // 
            this.tbOutput.AllowMacroRecording = false;
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.AutoCompleteBracketsList = new char[] {
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
            this.tbOutput.AutoIndent = false;
            this.tbOutput.AutoIndentChars = false;
            this.tbOutput.AutoIndentCharsPatterns = "";
            this.tbOutput.AutoIndentExistingLines = false;
            this.tbOutput.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.tbOutput.BackBrush = null;
            this.tbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOutput.CaretBlinking = false;
            this.tbOutput.CharHeight = 18;
            this.tbOutput.CharWidth = 9;
            this.tbOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOutput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbOutput.Font = new System.Drawing.Font("Consolas", 12F);
            this.tbOutput.IndentBackColor = System.Drawing.Color.Teal;
            this.tbOutput.IsReplaceMode = false;
            this.tbOutput.LineNumberColor = System.Drawing.Color.White;
            this.tbOutput.Location = new System.Drawing.Point(12, 306);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Paddings = new System.Windows.Forms.Padding(0);
            this.tbOutput.ReservedCountOfLineNumberChars = 4;
            this.tbOutput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbOutput.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbOutput.ServiceColors")));
            this.tbOutput.Size = new System.Drawing.Size(699, 476);
            this.tbOutput.TabIndex = 28;
            this.tbOutput.TabStop = false;
            this.tbOutput.WordWrap = true;
            this.tbOutput.WordWrapAutoIndent = false;
            this.tbOutput.Zoom = 100;
            this.tbOutput.VisibleRangeChanged += new System.EventHandler(this.tbOutput_VisibleRangeChanged);
            this.tbOutput.AutoIndentNeeded += new System.EventHandler<FastColoredTextBoxNS.AutoIndentEventArgs>(this.tbOutput_AutoIndentNeeded);
            // 
            // b_cbBaudList
            // 
            this.b_cbBaudList.FormattingEnabled = true;
            this.b_cbBaudList.Items.AddRange(new object[] {
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
            this.b_cbBaudList.Location = new System.Drawing.Point(88, 54);
            this.b_cbBaudList.Name = "b_cbBaudList";
            this.b_cbBaudList.Size = new System.Drawing.Size(116, 24);
            this.b_cbBaudList.TabIndex = 25;
            this.b_cbBaudList.SelectedIndexChanged += new System.EventHandler(this.b_cbBaudList_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(420, 221);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 24);
            this.comboBox1.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.a_tbInput);
            this.groupBox1.Controls.Add(this.a_cbPortList);
            this.groupBox1.Controls.Add(this.a_cbDsr);
            this.groupBox1.Controls.Add(this.a_cbCts);
            this.groupBox1.Controls.Add(this.a_btOpen);
            this.groupBox1.Controls.Add(this.a_cbAutoReconnect);
            this.groupBox1.Controls.Add(this.a_cbRts);
            this.groupBox1.Controls.Add(this.a_cbDtr);
            this.groupBox1.Controls.Add(this.a_cbBaudList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 203);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // a_tbInput
            // 
            this.a_tbInput.AcceptsTab = false;
            this.a_tbInput.AllowMacroRecording = false;
            this.a_tbInput.AutoCompleteBracketsList = new char[] {
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
            this.a_tbInput.AutoIndent = false;
            this.a_tbInput.AutoIndentChars = false;
            this.a_tbInput.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.a_tbInput.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.a_tbInput.BackBrush = null;
            this.a_tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.a_tbInput.CharHeight = 15;
            this.a_tbInput.CharWidth = 8;
            this.a_tbInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.a_tbInput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.a_tbInput.Font = new System.Drawing.Font("Consolas", 10F);
            this.a_tbInput.IsReplaceMode = false;
            this.a_tbInput.Location = new System.Drawing.Point(7, 109);
            this.a_tbInput.Name = "a_tbInput";
            this.a_tbInput.Paddings = new System.Windows.Forms.Padding(0);
            this.a_tbInput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.a_tbInput.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("a_tbInput.ServiceColors")));
            this.a_tbInput.ShowLineNumbers = false;
            this.a_tbInput.Size = new System.Drawing.Size(337, 88);
            this.a_tbInput.TabIndex = 28;
            this.a_tbInput.ToolTipDelay = 100;
            this.a_tbInput.WordWrap = true;
            this.a_tbInput.WordWrapAutoIndent = false;
            this.a_tbInput.Zoom = 100;
            this.a_tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.a_tbInput_KeyDown);
            // 
            // inputContextMenu
            // 
            this.inputContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.clearHistoryToolStripMenuItem});
            this.inputContextMenu.Name = "InputAContextMenu";
            this.inputContextMenu.Size = new System.Drawing.Size(141, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear history";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_cbPortList);
            this.groupBox2.Controls.Add(this.b_btConnect);
            this.groupBox2.Controls.Add(this.b_cbDtr);
            this.groupBox2.Controls.Add(this.b_cbBaudList);
            this.groupBox2.Controls.Add(this.b_cbAutoReconnect);
            this.groupBox2.Controls.Add(this.b_cbDsr);
            this.groupBox2.Controls.Add(this.b_cbRts);
            this.groupBox2.Controls.Add(this.b_cbCts);
            this.groupBox2.Location = new System.Drawing.Point(366, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 203);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // btLinkData
            // 
            this.btLinkData.BackColor = System.Drawing.Color.Transparent;
            this.btLinkData.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btLinkData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLinkData.Image = ((System.Drawing.Image)(resources.GetObject("btLinkData.Image")));
            this.btLinkData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLinkData.Location = new System.Drawing.Point(320, 36);
            this.btLinkData.Name = "btLinkData";
            this.btLinkData.Size = new System.Drawing.Size(90, 30);
            this.btLinkData.TabIndex = 99;
            this.btLinkData.Text = "DATA";
            this.btLinkData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLinkData.UseCompatibleTextRendering = true;
            this.btLinkData.UseVisualStyleBackColor = false;
            this.btLinkData.Click += new System.EventHandler(this.btLinkData_CheckedChanged);
            // 
            // btLinkSignal
            // 
            this.btLinkSignal.BackColor = System.Drawing.Color.Transparent;
            this.btLinkSignal.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btLinkSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLinkSignal.Image = ((System.Drawing.Image)(resources.GetObject("btLinkSignal.Image")));
            this.btLinkSignal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLinkSignal.Location = new System.Drawing.Point(320, 72);
            this.btLinkSignal.Name = "btLinkSignal";
            this.btLinkSignal.Size = new System.Drawing.Size(90, 30);
            this.btLinkSignal.TabIndex = 1;
            this.btLinkSignal.Text = "SIGNAL";
            this.btLinkSignal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLinkSignal.UseCompatibleTextRendering = true;
            this.btLinkSignal.UseVisualStyleBackColor = false;
            this.btLinkSignal.Click += new System.EventHandler(this.btLinkSignal_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 794);
            this.Controls.Add(this.btLinkSignal);
            this.Controls.Add(this.btLinkData);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tbHexPrefix);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.cbHexPrefix);
            this.Controls.Add(this.Timestamp);
            this.Controls.Add(this.cbAutoscroll);
            this.Controls.Add(this.cbBytesNewline);
            this.Controls.Add(this.cbTimeoutNewline);
            this.Controls.Add(this.tbBytesNewline);
            this.Controls.Add(this.tbTimeoutNewline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(739, 660);
            this.Name = "FrmMain";
            this.Text = "Indirect Serial";
            ((System.ComponentModel.ISupportInitialize)(this.tbOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.a_tbInput)).EndInit();
            this.inputContextMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox a_cbDtr;
        private System.Windows.Forms.CheckBox cbHexPrefix;
        private System.Windows.Forms.CheckBox Timestamp;
        private System.Windows.Forms.CheckBox cbAutoscroll;
        private System.Windows.Forms.CheckBox a_cbRts;
        private System.Windows.Forms.Button a_btOpen;
        private System.Windows.Forms.CheckBox cbBytesNewline;
        private System.Windows.Forms.CheckBox cbTimeoutNewline;
        private System.Windows.Forms.TextBox tbBytesNewline;
        private System.Windows.Forms.TextBox tbTimeoutNewline;
        private System.Windows.Forms.TextBox tbHexPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox a_cbDsr;
        private System.Windows.Forms.CheckBox a_cbCts;
        private System.Windows.Forms.Button b_btConnect;
        private System.Windows.Forms.CheckBox a_cbAutoReconnect;
        private System.Windows.Forms.CheckBox b_cbDtr;
        private System.Windows.Forms.CheckBox b_cbAutoReconnect;
        private System.Windows.Forms.CheckBox b_cbDsr;
        private System.Windows.Forms.ComboBox a_cbPortList;
        private System.Windows.Forms.CheckBox b_cbRts;
        private System.Windows.Forms.ComboBox a_cbBaudList;
        private System.Windows.Forms.CheckBox b_cbCts;
        private System.Windows.Forms.ComboBox b_cbPortList;
        private FastColoredTextBoxNS.FastColoredTextBox tbOutput;
        private System.Windows.Forms.ComboBox b_cbBaudList;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btLinkData;
        private System.Windows.Forms.Button btLinkSignal;
        private System.Windows.Forms.ContextMenuStrip inputContextMenu;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private FastColoredTextBoxNS.FastColoredTextBox a_tbInput;
    }
}

