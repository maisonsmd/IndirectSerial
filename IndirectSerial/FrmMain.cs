using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndirectSerial {

    public partial class FrmMain : Form {
        private SerialPort portA = new SerialPort { BaudRate = 115200 }, portB = new SerialPort { BaudRate = 115200 };

        private UInt64 timeout = 100;

        private Timer dataTimer = new Timer { Interval = 10 };
        private Timer signalTimer = new Timer { Interval = 5 };

        private UInt32 aLineBytes = 0, bLineBytes;
        private UInt64 lastPrint_ms;
        private Boolean printingA = true;

        private volatile List<Byte> AReceivedBytes = new List<Byte>(), BReceivedBytes = new List<Byte>();
        private UInt32 newlineBytes = 16;

        private Stopwatch millisSw = new Stopwatch();

        private volatile Boolean lastADsr, lastACts, lastBDsr, lastBCts;
        private Boolean linkedSignal = false, linkedData = false;
        public FrmMain() {
            InitializeComponent();
            ABaud.Text = portA.BaudRate.ToString();
            ADtr.Checked = portA.DtrEnable;
            ARts.Checked = portA.RtsEnable;
            BBaud.Text = portB.BaudRate.ToString();
            BDtr.Checked = portA.DtrEnable;
            BRts.Checked = portA.RtsEnable;

            APortList_DropDown(null, null);
            BPortList_DropDown(null, null);
            APortList.SelectedIndex = 0;
            BPortList.SelectedIndex = 0;

            LinkSignal.Checked = linkedSignal;
            LinkData.Checked = linkedData;

            TimeoutNewlineCount.Text = timeout.ToString();
            BytesNewlineCount.Text = newlineBytes.ToString();

            millisSw.Start();

            dataTimer.Tick += (Object sender, EventArgs e) => {
                dataTimer.Stop();

                UInt64 current_ms = (UInt64)millisSw.ElapsedMilliseconds;
                StringBuilder newContent = new StringBuilder(String.Empty);

                if (TimeoutNewlineEnable.Checked
                && (current_ms >= lastPrint_ms + timeout)) {
                    if (!Content.Text.EndsWith("\n")
                    || (DisplayAsHex.Checked && Content.Text.EndsWith("0A"))) {
                        Content.AppendText("\n");
                        aLineBytes = 0;
                        bLineBytes = 0;

                        ScrollToLast();
                    }
                }

                if (portA.IsOpen && portA.BytesToRead > 0) {
                    if (!printingA &&
                    (!Content.Text.EndsWith("\n") || (DisplayAsHex.Checked && Content.Text.EndsWith("0A")))) {
                        Content.AppendText("\n");

                        aLineBytes = 0;
                        bLineBytes = 0;

                        ScrollToLast();
                    }

                    printingA = true;
                    while (portA.BytesToRead > 0) {
                        Byte c = (Byte)portA.ReadByte();

                        if (BytesNewlineEnable.Checked
                        && aLineBytes >= newlineBytes) {
                            if (!Content.Text.EndsWith("\n") && !newContent.ToString().EndsWith("\n"))
                                Content.AppendText("\n");
                            aLineBytes = 0;
                            bLineBytes = 0;
                        }

                        if (aLineBytes == 0) {
                            if (Timestamp.Checked)
                                Content.AppendText($"{GetTimeString()} ", Color.Gray);
                            Content.AppendText(linkedData ? "A->B " : "A->PC ", Color.DarkGray);
                            aLineBytes = 0;
                            bLineBytes = 0;
                        }

                        AReceivedBytes.Add(c);
                        aLineBytes++;
                        lastPrint_ms = current_ms;

                        if (DisplayAsHex.Checked)
                            //Content.AppendText(String.Format("{0:X2} ", c), Color.Red);
                            newContent.AppendFormat("{0:X2} ", c);
                        else {
                            if ((c >= 0x20 && c <= 0x7E) || c == '\n')
                                //Content.AppendText(((Char)c).ToString(), Color.Red);
                                newContent.Append(((Char)c).ToString());
                            else
                                //Content.AppendText(String.Format("[{0:X2}]", c), Color.Red);
                                newContent.AppendFormat("[{0:X2}]", c);
                        }

                        if ((c == '\n') && DisplayAsText.Checked) {
                            aLineBytes = 0;
                            bLineBytes = 0;
                        }
                    }
                    if (DisplayAsHex.Checked) {
                        //Content.AppendText("\n");
                        newContent.Append("\n");
                        aLineBytes = 0;
                        bLineBytes = 0;
                    }

                    if (portB.IsOpen && linkedData) {
                        Byte[] array = AReceivedBytes.ToArray();
                        portB.BaseStream.Write(array, 0, array.Length);
                    }
                    AReceivedBytes.Clear();
                    Content.AppendText(newContent.ToString(), Color.Red);
                    ScrollToLast();

                    dataTimer.Start();
                    return;
                }

                if (portB.IsOpen && portB.BytesToRead > 0) {
                    if (printingA && (!Content.Text.EndsWith("\n") || (DisplayAsHex.Checked && Content.Text.EndsWith("0A")))) {
                        Content.AppendText("\n");

                        aLineBytes = 0;
                        bLineBytes = 0;

                        ScrollToLast();
                    }

                    printingA = false;
                    while (portB.BytesToRead > 0) {
                        Byte c = (Byte)portB.ReadByte();

                        if (BytesNewlineEnable.Checked
                        && bLineBytes >= newlineBytes) {
                            if (!Content.Text.EndsWith("\n") && !newContent.ToString().EndsWith("\n"))
                                Content.AppendText("\n");
                            bLineBytes = 0;
                            aLineBytes = 0;
                        }

                        if (bLineBytes == 0) {
                            if (Timestamp.Checked)
                                Content.AppendText($"{GetTimeString()} ", Color.Gray);
                            Content.AppendText(linkedData ? "B->A " : "B->PC ", Color.DarkGray);
                            bLineBytes = 0;
                            aLineBytes = 0;
                        }

                        BReceivedBytes.Add(c);
                        bLineBytes++;
                        lastPrint_ms = current_ms;

                        if (DisplayAsHex.Checked)
                            newContent.AppendFormat("{0:X2} ", c);
                        else {
                            if ((c >= 0x20 && c <= 0x7E) || c == '\n')
                                newContent.Append(((Char)c).ToString());
                            else
                                newContent.AppendFormat("[{0:X2}]", c);
                        }

                        if ((c == '\n') && DisplayAsText.Checked) {
                            aLineBytes = 0;
                            bLineBytes = 0;
                        }
                    }
                    if (DisplayAsHex.Checked) {
                        newContent.Append("\n");
                        aLineBytes = 0;
                        bLineBytes = 0;
                    }


                    if (portA.IsOpen && linkedData) {
                        Byte[] array = BReceivedBytes.ToArray();
                        portA.BaseStream.Write(array, 0, array.Length);
                    }
                    BReceivedBytes.Clear();
                    Content.AppendText(newContent.ToString(), Color.Blue);
                    ScrollToLast();

                    dataTimer.Start();
                    return;
                }

                dataTimer.Start();
            };

            signalTimer.Tick += (Object sender, EventArgs e) => {
                Boolean aCts = portA.IsOpen ? portA.CtsHolding : false,
                aDsr = portA.IsOpen ? portA.DsrHolding : false,
                bCts = portB.IsOpen ? portB.CtsHolding : false,
                bDsr = portB.IsOpen ? portB.DsrHolding : false;

                if (aDsr != lastADsr) {
                    if (portB.IsOpen && linkedSignal) {
                        portB.DtrEnable = aDsr;
                        BDtr.Checked = aDsr;
                    }

                    lastADsr = aDsr;
                    ADsr.Checked = aDsr;
                }
                if (aCts != lastACts) {
                    if (portB.IsOpen && linkedSignal) {
                        portB.RtsEnable = aCts;
                        BRts.Checked = aCts;
                    }

                    lastACts = aCts;
                    ACts.Checked = aCts;
                }
                if (bDsr != lastBDsr) {
                    if (portA.IsOpen && linkedSignal) {
                        portA.DtrEnable = bDsr;
                        ADtr.Checked = bDsr;
                    }

                    lastBDsr = bDsr;
                    BDsr.Checked = bDsr;
                }
                if (bCts != lastBCts) {
                    if (portA.IsOpen && linkedSignal) {
                        portA.RtsEnable = bCts;
                        ARts.Checked = bCts;
                    }

                    lastBCts = bCts;
                    BCts.Checked = bCts;
                }
            };

            signalTimer.Start();
            dataTimer.Start();
        }

        private void ScrollToLast() {
            if (Autoscroll.Checked) {
                Content.SelectionStart = Content.Text.Length;
                Content.ScrollToCaret();
            }
        }

        private String GetTimeString() => DateTime.Now.ToString("HH:mm:ss.fff");

        private Byte[] HexStringToArray(String text) {
            List<Byte> args = new List<Byte>();
            List<Byte> output = new List<Byte>();

            String prefix = Prefix.Text;

            String rgx = String.Format("{0}[0-9A-F]{{1,2}}", prefix);
            //MatchCollection match = Regex.Matches(text, "h[0-9A-F]{1,2}\\s?"); // include space
            MatchCollection matches = Regex.Matches(text, rgx);

            for (Int32 i = 0; i < matches.Count; ++i) {
                Byte c = Byte.Parse(Regex.Match(matches[i].ToString(), @"\d+").Value, System.Globalization.NumberStyles.HexNumber);
                args.Add(c);
                text = text.ReplaceFirst(matches[i].ToString(), ((Char)0).ToString());
            }

            Int32 argsCount = 0;
            for (Int32 i = 0; i < text.Length; ++i)
                output.Add((text[i] != 0) ? (Byte)text[i] : args[argsCount++]);

            return output.ToArray();
        }

        private String StringToHexString(String text) {
            String output = String.Empty;
            for (Int32 i = 0; i < text.Length; ++i) {
                output += String.Format("{0:X2}", (Byte)text[i]);
                if (i + 1 < text.Length) output += " ";
            }
            return output;
        }

        private String HexArrayToHexString(Byte[] array) {
            String output = String.Empty;
            for (Int32 i = 0; i < array.Length; ++i) {
                output += String.Format("{0:X2}", array[i]);
                if (i + 1 < array.Length) output += " ";
            }
            return output;
        }

        private String HexArrayToComplexString(Byte[] array) {
            String output = String.Empty;
            for (Int32 i = 0; i < array.Length; ++i) {
                if (array[i] >= 0x20 && array[i] < 0x7E)
                    output += ((Char)array[i]).ToString();
                else
                    output += String.Format("[{0:X2}]", array[i]);
                //if (i + 1 < array.Length) output += " ";
            }
            return output;
        }

        private void TimeoutNewlineCount_KeyDown(Object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;
            if (UInt64.TryParse(TimeoutNewlineCount.Text, out UInt64 value)) {
                if (value < 10) value = 10;
                timeout = value;
                TimeoutNewlineCount.Text = timeout.ToString();
            }
        }

        private void BytesNewlineCount_KeyDown(Object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;
            if (UInt32.TryParse(BytesNewlineCount.Text, out UInt32 value)) {
                if (value < 2) value = 2;
                newlineBytes = value;
                BytesNewlineCount.Text = newlineBytes.ToString();
            }
        }

        #region Port A methods

        private void AInput_KeyDown(Object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;
            String text = AInput.Text;
            AParseAndSend(text);
        }

        private void ASend_Click(Object sender, EventArgs e) => AParseAndSend(AInput.Text);

        private void AParseAndSend(String text) {
            if (!AInput.Items.Contains(text))
                AInput.Items.Add(AInput.Text);

            lastPrint_ms = (UInt64)millisSw.ElapsedMilliseconds;

            // Content.AppendText("\n");
            aLineBytes = 0;
            bLineBytes = 0;

            if (Timestamp.Checked)
                Content.AppendText($"{GetTimeString()} ", Color.Gray);
            Content.AppendText("PC->A ", Color.DarkGray);

            if (AppendNewlineEnable.Checked && !text.EndsWith("\n"))
                text += "\n";

            Byte[] array = HexStringToArray(text);
            String hexStr = HexArrayToHexString(array);
            String complexStr = HexArrayToComplexString(array);

            if (HexPrefixEnable.Checked) {
                if (DisplayAsHex.Checked)
                    Content.AppendText(hexStr + "\n", Color.Red);
                else
                    Content.AppendText(complexStr + "\n", Color.Red);
            }
            else {
                if (DisplayAsHex.Checked)
                    Content.AppendText(StringToHexString(text) + "\n", Color.Red);
                else {
                    Content.AppendText(text, Color.Red);
                    if (!AppendNewlineEnable.Checked && !text.EndsWith("\n"))
                        Content.AppendText("\n");
                }
            }

            if (portA.IsOpen)
                portA.BaseStream.Write(array, 0, array.Length);

            ScrollToLast();
        }

        private void BParseAndSend(String text) {
            if (!BInput.Items.Contains(text))
                BInput.Items.Add(BInput.Text);

            lastPrint_ms = (UInt64)millisSw.ElapsedMilliseconds;

            aLineBytes = 0;
            bLineBytes = 0;

            if (Timestamp.Checked)
                Content.AppendText($"{GetTimeString()} ", Color.Gray);
            Content.AppendText("PC->B ", Color.DarkGray);

            if (AppendNewlineEnable.Checked && !text.EndsWith("\n"))
                text += "\n";

            Byte[] array = HexStringToArray(text);
            String hexStr = HexArrayToHexString(array);
            String complexStr = HexArrayToComplexString(array);

            if (HexPrefixEnable.Checked) {
                if (DisplayAsHex.Checked)
                    Content.AppendText(hexStr + "\n", Color.Blue);
                else
                    Content.AppendText(complexStr + "\n", Color.Blue);
            }
            else {
                if (DisplayAsHex.Checked)
                    Content.AppendText(StringToHexString(text) + "\n", Color.Blue);
                else {
                    Content.AppendText(text, Color.Blue);
                    if (!AppendNewlineEnable.Checked && !text.EndsWith("\n"))
                        Content.AppendText("\n");
                }
            }

            if (portB.IsOpen)
                portB.BaseStream.Write(array, 0, array.Length);

            ScrollToLast();
        }

        private void AClearHistory_Click(Object sender, EventArgs e) => AInput.Items.Clear();

        private void APortList_DropDown(Object sender, EventArgs e) {
            String[] ports = SerialPort.GetPortNames();
            APortList.Items.Clear();
            APortList.Items.AddRange(ports);
        }

        private void AClose_Click(Object sender, EventArgs e) {
            AOpen.Enabled = true;
            ABaud.Enabled = true;
            AClose.Enabled = false;

            if (portA.IsOpen) portA.Close();
        }

        private void ABaud_SelectedIndexChanged(Object sender, EventArgs e) => portA.BaudRate = Int32.Parse(ABaud.Text);

        private void ADtr_CheckedChanged(Object sender, EventArgs e) => portA.DtrEnable = ADtr.Checked;

        private void ARts_CheckedChanged(Object sender, EventArgs e) => portA.RtsEnable = ARts.Checked;

        private void AOpen_Click(Object sender, EventArgs e) {
            try {
                if (portA.IsOpen) portA.Close();
                portA.PortName = APortList.Text;
                portA.Open();
                AOpen.Enabled = false;
                ABaud.Enabled = false;
                AClose.Enabled = true;
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Port A methods

        #region Port B methods

        private void BPortList_DropDown(Object sender, EventArgs e) {
            String[] ports = SerialPort.GetPortNames();
            BPortList.Items.Clear();
            BPortList.Items.AddRange(ports);
        }

        private void BOpen_Click(Object sender, EventArgs e) {
            try {
                if (portB.IsOpen) portB.Close();
                portB.PortName = BPortList.Text;
                portB.Open();
                BOpen.Enabled = false;
                BBaud.Enabled = false;
                BClose.Enabled = true;
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BClose_Click(Object sender, EventArgs e) {
            BOpen.Enabled = true;
            BBaud.Enabled = true;
            BClose.Enabled = false;

            if (portB.IsOpen) portB.Close();
        }

        private void LinkSignal_CheckedChanged(Object sender, EventArgs e) {
            linkedSignal = LinkSignal.Checked;

            Boolean aCts = portA.IsOpen ? portA.CtsHolding : false,
            aDsr = portA.IsOpen ? portA.DsrHolding : false,
            bCts = portB.IsOpen ? portB.CtsHolding : false,
            bDsr = portB.IsOpen ? portB.DsrHolding : false;

            if (portB.IsOpen && linkedSignal) {
                portB.DtrEnable = aDsr;
                BDtr.Checked = aDsr;
            }

            lastADsr = aDsr;
            ADsr.Checked = aDsr;

            if (portB.IsOpen && linkedSignal) {
                portB.RtsEnable = aCts;
                BRts.Checked = aCts;
            }

            lastACts = aCts;
            ACts.Checked = aCts;

            if (portA.IsOpen && linkedSignal) {
                portA.DtrEnable = bDsr;
                ADtr.Checked = bDsr;
            }

            lastBDsr = bDsr;
            BDsr.Checked = bDsr;

            if (portA.IsOpen && linkedSignal) {
                portA.RtsEnable = bCts;
                ARts.Checked = bCts;
            }

            lastBCts = bCts;
            BCts.Checked = bCts;
        }

        private void LinkData_CheckedChanged(Object sender, EventArgs e) => linkedData = LinkData.Checked;

        private void ClearDisplay_Click(Object sender, EventArgs e) => Content.Clear();

        private void BSend_Click(Object sender, EventArgs e) => BParseAndSend(BInput.Text);

        private void BClearHistory_Click(Object sender, EventArgs e) => BInput.Items.Clear();

        private void BDtr_CheckedChanged(Object sender, EventArgs e) => portB.DtrEnable = BDtr.Checked;

        private void BInput_KeyDown(Object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;

            String text = BInput.Text;
            BParseAndSend(text);
        }

        private void BRts_CheckedChanged(Object sender, EventArgs e) => portB.RtsEnable = BRts.Checked;

        private void BBaud_SelectedIndexChanged(Object sender, EventArgs e) => portB.BaudRate = Int32.Parse(BBaud.Text);

        #endregion Port B methods
    }
}