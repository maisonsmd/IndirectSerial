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

        private Timer dataTimer = new Timer { Interval = 5 };
        private Timer signalTimer = new Timer { Interval = 5 };
        private Timer portSearchTimer = new Timer { Interval = 1000 };

        private List<String> oldPortList = new List<String>();

        private UInt32 aLineBytes = 0, bLineBytes;
        private Boolean aPrintedHeader = false, bPrintedHeader = false;
        private UInt64 lastPrint_ms;
        private Boolean printingA = true;
        private Boolean printingB = false;

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
            if (APortList.Items.Count > 0)
                APortList.SelectedIndex = 0;
            if (BPortList.Items.Count > 0)
                BPortList.SelectedIndex = 0;

            LinkSignal.Checked = linkedSignal;
            LinkData.Checked = linkedData;

            TimeoutNewlineCount.Text = timeout.ToString();
            BytesNewlineCount.Text = newlineBytes.ToString();

            millisSw.Start();

            dataTimer.Tick += (Object sender, EventArgs e) => {
                dataTimer.Stop();

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

            portSearchTimer.Tick += (Object sender, EventArgs e) => {
                portSearchTimer.Stop();

                List<String> currentPortsList = SerialPort.GetPortNames().ToList();
                List<String> newPluggedPorts = oldPortList != null ? currentPortsList.Except(oldPortList).ToList() : new List<String>();
                List<String> newRemovedPorts = currentPortsList != null ? oldPortList.Except(currentPortsList).ToList() : new List<String>();

                if (newPluggedPorts.Any()) {
                    PortsPlugged(newPluggedPorts);
                    //Invoke((MethodInvoker)delegate {
                    //});
                }
                if (newRemovedPorts.Any()) {
                    PortsUnplugged(newRemovedPorts);
                    //Invoke((MethodInvoker)delegate {
                    //});
                }

                oldPortList = currentPortsList;

                portSearchTimer.Start();
            };

            signalTimer.Start();
            dataTimer.Start();
            portSearchTimer.Start();
        }

        private void ConcatMessage(String message) {
            fctb.BeginUpdate();
            fctb.TextSource.CurrentTB = fctb;
            fctb.AppendText(message + "\n");
            fctb.GoEnd();
            fctb.EndUpdate();
        }

        private void PortsPlugged(List<String> names) {
            Console.WriteLine("Plugged: " + String.Join(",", names));

            String aName = portA.PortName;
            String bName = portB.PortName;

            if (aName != String.Empty
                && names.Contains(aName)
                && AutoReconnectA.Checked) {
                try {
                    try {
                        ConcatMessage(String.Format("opening {0}...", aName));
                        APortList.Text = aName;
                        fctb.Refresh();

                        portA.Open();
                        AOpen.Enabled = false;
                        ABaud.Enabled = false;
                        AClose.Enabled = true;

                        ConcatMessage(String.Format("{0} opened", aName));
                    }
                    catch (Exception exc) {
                        ConcatMessage(String.Format("cannot open {0}, trace: {1}", portA.PortName, exc.ToString()));
                    }
                }
                catch (Exception e) {
                    ConcatMessage(String.Format("cannot open {0}, trace: {1}", aName, e.ToString()));
                }
            }
            if (bName != String.Empty
                && names.Contains(bName)
                && AutoReconnectB.Checked) {
                try {
                    ConcatMessage(String.Format("opening {0}...", bName));
                    BPortList.Text = bName;
                    fctb.Refresh();

                    portB.Open();
                    BOpen.Enabled = false;
                    BBaud.Enabled = false;
                    BClose.Enabled = true;
                    ConcatMessage(String.Format("{0} opened", bName));
                }
                catch (Exception e) {
                    ConcatMessage(String.Format("cannot open {0}, trace: {1}", bName, e.ToString()));
                }
            }
        }

        private void PortsUnplugged(List<String> names) {
            Console.WriteLine("Removed: " + String.Join(",", names));

            if (names.Contains(portA.PortName) && AClose.Enabled) {
                AOpen.Enabled = true;
                ABaud.Enabled = true;
                AClose.Enabled = false;

                portA.Close();
                ConcatMessage(String.Format("{0} closed", portA.PortName));
            }
            if (names.Contains(portB.PortName) && BClose.Enabled) {
                BOpen.Enabled = true;
                BBaud.Enabled = true;
                BClose.Enabled = false;

                portB.Close();
                ConcatMessage(String.Format("{0} closed", portB.PortName));
            }
        }

        private void ScrollToLast() {
            if (Autoscroll.Checked) {
            }
        }

        private String GetTimeString() => DateTime.Now.ToString("HH:mm:ss.fff");

        private Byte[] HexStringToArray(String text) {
            List<Byte> args = new List<Byte>();
            List<Byte> output = new List<Byte>();

            String prefix = Prefix.Text;

            String rgx = $"{prefix}[0-9A-F]{{1,2}}";
            //MatchCollection match = Regex.Matches(text, "h[0-9A-F]{1,2}\\s?"); // include space
            MatchCollection matches = Regex.Matches(text, rgx);

            for (Int32 i = 0; i < matches.Count; ++i) {
                Byte c = Byte.Parse(Regex.Match(matches[i].ToString(), "[0-9A-F]{1,2}").Value, System.Globalization.NumberStyles.HexNumber);
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
            printingA = false;
            printingB = false;

            if (!AInput.Items.Contains(text))
                AInput.Items.Add(AInput.Text);

            lastPrint_ms = (UInt64)millisSw.ElapsedMilliseconds;

            // Content.AppendText("\n");
            aLineBytes = 0;
            bLineBytes = 0;
            aPrintedHeader = false;
            bPrintedHeader = false;

            //if (!Content.Text.EndsWith("\n"))
            //    Content.AppendText("\n");

            //if (Timestamp.Checked)
            //    Content.AppendText($"{GetTimeString()} ", Color.Gray);
            //Content.AppendText("PC->A ", Color.DarkGray);

            //if (AppendNewlineEnable.Checked && !text.EndsWith("\n"))
            //    text += "\n";

            //Byte[] array = HexStringToArray(text);
            //String hexStr = HexArrayToHexString(array);
            //String complexStr = HexArrayToComplexString(array);

            //if (HexPrefixEnable.Checked) {
            //    if (DisplayAsHex.Checked)
            //        Content.AppendText(hexStr, Color.Green);
            //    else
            //        Content.AppendText(complexStr, Color.Green);
            //}
            //else {
            //    if (DisplayAsHex.Checked)
            //        Content.AppendText(StringToHexString(text), Color.Green);
            //    else {
            //        Content.AppendText(text, Color.Green);
            //    }
            //}

            //if (portA.IsOpen)
            //    portA.BaseStream.Write(array, 0, array.Length);

            ScrollToLast();
        }

        private void BParseAndSend(String text) {
            printingA = false;
            printingB = false;

            if (!BInput.Items.Contains(text))
                BInput.Items.Add(BInput.Text);

            //if (portB.IsOpen)
            //    portB.BaseStream.Write(array, 0, array.Length);

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
            AutoReconnectA.Checked = false;

            if (portA.IsOpen) {
                portA.Close();
                ConcatMessage(String.Format("{0} closed", portA.PortName));
            }
        }

        private void ABaud_SelectedIndexChanged(Object sender, EventArgs e) => portA.BaudRate = Int32.Parse(ABaud.Text);

        private void ADtr_CheckedChanged(Object sender, EventArgs e) => portA.DtrEnable = ADtr.Checked;

        private void ARts_CheckedChanged(Object sender, EventArgs e) => portA.RtsEnable = ARts.Checked;

        private void AOpen_Click(Object sender, EventArgs e) {
            ConcatMessage(String.Format("opening {0}...", APortList.Text));
            fctb.Refresh();

            try {
                if (portA.IsOpen) portA.Close();
                portA.PortName = APortList.Text;
                portA.Open();
                AOpen.Enabled = false;
                ABaud.Enabled = false;
                AClose.Enabled = true;
                ConcatMessage(String.Format("{0} opened", portA.PortName));
            }
            catch (Exception exc) {
                ConcatMessage(String.Format("cannot open {0}, trace: {1}", portA.PortName, exc.ToString()));
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
            ConcatMessage(String.Format("opening {0}...", BPortList.Text));
            fctb.Refresh();

            try {
                if (portB.IsOpen) portB.Close();
                portB.PortName = BPortList.Text;
                portB.Open();
                BOpen.Enabled = false;
                BBaud.Enabled = false;
                BClose.Enabled = true;
                ConcatMessage(String.Format("{0} opened", portB.PortName));
            }
            catch (Exception exc) {
                ConcatMessage(String.Format("cannot open {0}, trace: {1}", portB.PortName, exc.ToString()));
            }
        }

        private void BClose_Click(Object sender, EventArgs e) {
            BOpen.Enabled = true;
            BBaud.Enabled = true;
            BClose.Enabled = false;
            AutoReconnectB.Checked = false;

            if (portB.IsOpen) {
                portB.Close();
                ConcatMessage(String.Format("{0} closed", portB.PortName));
            }
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

        private void ClearDisplay_Click(Object sender, EventArgs e) => fctb.Clear();

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