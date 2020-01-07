using FastColoredTextBoxNS;
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
        private SerialPort portA = new SerialPort { BaudRate = 115200, PortName = "unknown" }, portB = new SerialPort { BaudRate = 115200, PortName = "unknown" };
        private FastColoredTextBoxNS.AutocompleteMenu a_inputPopup, b_inputPopup;
        private List<FastColoredTextBoxNS.AutocompleteItem> autoCompleteList = new List<FastColoredTextBoxNS.AutocompleteItem>();
        private StringTextSource outputTextSource;
        private String outputText = "Nothing";
        private TextStyle timestampStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        private TextStyle directionStyle = new TextStyle(Brushes.LightGray, null, FontStyle.Regular);
        private TextStyle aSourceStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        private TextStyle bSourceStyle = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        private TextStyle pcSourceStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        private TextStyle spaceStyle = new TextStyle(Brushes.LightGray, null, FontStyle.Regular);
        private Style invisibleCharsStyle = new InvisibleCharsRenderer(Pens.LightGray);

        private UInt64 timeout = 100;
        private UInt32 newlineBytes = 16;

        private Timer dataTimer = new Timer { Interval = 5 };
        private Timer signalTimer = new Timer { Interval = 5 };
        private Timer portSearchTimer = new Timer { Interval = 1000 };

        private List<String> oldPortList = new List<String>();
        private UInt64 lastPrint_ms;
        private Boolean endedWithNewline = true;
        private volatile List<Byte> AReceivedBytes = new List<Byte>(), BReceivedBytes = new List<Byte>();
        private Stopwatch millisSw = new Stopwatch();
        private volatile Boolean lastADsr, lastACts, lastBDsr, lastBCts;
        private Boolean linkedSignal = false, linkedData = false;

        public FrmMain() {
            InitializeComponent();

            a_inputPopup = new FastColoredTextBoxNS.AutocompleteMenu(a_tbInput) {
                MinFragmentLength = 1,
                SearchPattern = ".+"
            };

            //set words as autocomplete source
            a_inputPopup.Items.SetAutocompleteItems(autoCompleteList);
            a_inputPopup.Items.MaximumSize = new Size(800, 300);
            a_inputPopup.Items.Width = 500;
            a_inputPopup.SelectedColor = Color.SkyBlue;
            a_inputPopup.Items.Font = new Font("Consolas", 12);
            a_inputPopup.AppearInterval = 50;

            a_cbBaudList.Text = portA.BaudRate.ToString();
            a_cbDtr.Checked = portA.DtrEnable;
            a_cbRts.Checked = portA.RtsEnable;
            b_cbBaudList.Text = portB.BaudRate.ToString();
            b_cbDtr.Checked = portA.DtrEnable;
            b_cbRts.Checked = portA.RtsEnable;

            a_portList_DropDown(null, null);
            b_cbPortList_DropDown(null, null);
            if (a_cbPortList.Items.Count > 0)
                a_cbPortList.SelectedIndex = 0;
            if (b_cbPortList.Items.Count > 0)
                b_cbPortList.SelectedIndex = 0;

            //outputTextSource = new StringTextSource(tbOutput);
            //outputTextSource.OpenString(outputText);
            //tbOutput.TextSource = outputTextSource;

            tbTimeoutNewline.Text = timeout.ToString();
            tbBytesNewline.Text = newlineBytes.ToString();

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
                        b_cbDtr.Checked = aDsr;
                    }

                    lastADsr = aDsr;
                    a_cbDsr.Checked = aDsr;
                }
                if (aCts != lastACts) {
                    if (portB.IsOpen && linkedSignal) {
                        portB.RtsEnable = aCts;
                        b_cbRts.Checked = aCts;
                    }

                    lastACts = aCts;
                    a_cbCts.Checked = aCts;
                }
                if (bDsr != lastBDsr) {
                    if (portA.IsOpen && linkedSignal) {
                        portA.DtrEnable = bDsr;
                        a_cbDtr.Checked = bDsr;
                    }

                    lastBDsr = bDsr;
                    b_cbDsr.Checked = bDsr;
                }
                if (bCts != lastBCts) {
                    if (portA.IsOpen && linkedSignal) {
                        portA.RtsEnable = bCts;
                        a_cbRts.Checked = bCts;
                    }

                    lastBCts = bCts;
                    b_cbCts.Checked = bCts;
                }
            };

            portSearchTimer.Tick += (Object sender, EventArgs e) => {
                portSearchTimer.Stop();

                List<String> currentPortsList = SerialPort.GetPortNames().ToList();
                List<String> newPluggedPorts = oldPortList != null ? currentPortsList.Except(oldPortList).ToList() : new List<String>();
                List<String> newRemovedPorts = currentPortsList != null ? oldPortList.Except(currentPortsList).ToList() : new List<String>();

                if (newPluggedPorts.Any()) {
                    portsPlugged(newPluggedPorts);
                    //Invoke((MethodInvoker)delegate {
                    //});
                }
                if (newRemovedPorts.Any()) {
                    portsUnplugged(newRemovedPorts);
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

        private void concatMessage(String message) {
            //message = message.Replace(" ", "•");
            //some stuffs for best performance
            tbOutput.BeginUpdate();
            tbOutput.Selection.BeginUpdate();
            //remember user selection
            Range userSelection = tbOutput.Selection.Clone();
            //add text with predefined style
            tbOutput.TextSource.CurrentTB = tbOutput;
            tbOutput.AppendText(message + "\n");
            //restore user selection
            if (!userSelection.IsEmpty || userSelection.Start.iLine < tbOutput.LinesCount - 2) {
                tbOutput.Selection.Start = userSelection.Start;
                tbOutput.Selection.End = userSelection.End;
            }
            else
                tbOutput.GoEnd();//scroll to end of the
            tbOutput.Selection.EndUpdate();

            tbOutput.GoEnd();//scroll to end of the text
            tbOutput.EndUpdate();

            //tbOutput.BeginUpdate();
            //tbOutput.TextSource.CurrentTB = tbOutput;
            //tbOutput.AppendText(message + "\n");
            //tbOutput.GoEnd();
            //tbOutput.EndUpdate();

            //outputText += message + "\n";
            ////outputTextSource.Clear();
            ////outputTextSource.OpenString(outputText);
            //tbOutput.Text = outputText;
            //tbOutput.Invalidate();
        }

        private void portsPlugged(List<String> names) {
            Console.WriteLine("Plugged: " + String.Join(",", names));

            String aName = portA.PortName;
            String bName = portB.PortName;

            if (aName != String.Empty
                && names.Contains(aName)
                && a_cbAutoReconnect.Checked) {
                try {
                    try {
                        concatMessage(String.Format("opening {0}...", aName));
                        a_cbPortList.Text = aName;
                        tbOutput.Refresh();

                        portA.Open();
                        a_btOpen.Enabled = false;
                        a_cbBaudList.Enabled = false;
                        //AClose.Enabled = true;

                        concatMessage(String.Format("{0} opened", aName));
                    }
                    catch (Exception exc) {
                        concatMessage(String.Format("cannot open {0}, trace: {1}", portA.PortName, exc.ToString()));
                    }
                }
                catch (Exception e) {
                    concatMessage(String.Format("cannot open {0}, trace: {1}", aName, e.ToString()));
                }
            }
            if (bName != String.Empty
                && names.Contains(bName)
                && b_cbAutoReconnect.Checked) {
                try {
                    concatMessage(String.Format("opening {0}...", bName));
                    b_cbPortList.Text = bName;
                    tbOutput.Refresh();

                    portB.Open();
                    b_btConnect.Enabled = false;
                    b_cbBaudList.Enabled = false;
                    //BClose.Enabled = true;
                    concatMessage(String.Format("{0} opened", bName));
                }
                catch (Exception e) {
                    concatMessage(String.Format("cannot open {0}, trace: {1}", bName, e.ToString()));
                }
            }
        }

        private void portsUnplugged(List<String> names) => Console.WriteLine("Removed: " + String.Join(",", names));//if (names.Contains(portA.PortName) && AClose.Enabled) {//    AOpen.Enabled = true;//    ABaud.Enabled = true;//    AClose.Enabled = false;//    portA.Close();//    ConcatMessage(String.Format("{0} closed", portA.PortName));//}//if (names.Contains(portB.PortName) && BClose.Enabled) {//    BOpen.Enabled = true;//    BBaud.Enabled = true;//    BClose.Enabled = false;//    portB.Close();//    ConcatMessage(String.Format("{0} closed", portB.PortName));//}

        private String getTimeString() => DateTime.Now.ToString("HH:mm:ss.fff");

        private Byte[] hexStringToArray(String text) {
            List<Byte> args = new List<Byte>();
            List<Byte> output = new List<Byte>();

            String prefix = tbHexPrefix.Text;

            //MatchCollection match = Regex.Matches(text, "h[0-9A-F]{1,2}\\s?"); // include space
            MatchCollection matches = Regex.Matches(text, $"{prefix}[0-9A-F]{{1,2}}");

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

        private String stringToHexString(String text) {
            String output = String.Empty;
            for (Int32 i = 0; i < text.Length; ++i) {
                output += String.Format("{0:X2}", (Byte)text[i]);
                if (i + 1 < text.Length) output += " ";
            }
            return output;
        }

        private String hexArrayToHexString(Byte[] array) {
            String output = String.Empty;
            for (Int32 i = 0; i < array.Length; ++i) {
                output += String.Format("{0:X2}", array[i]);
                if (i + 1 < array.Length) output += " ";
            }
            return output;
        }

        private String hexArrayToComplexString(Byte[] array) {
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

        private void tbTimeoutNewline_KeyDown(Object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;
            if (UInt64.TryParse(tbTimeoutNewline.Text, out UInt64 value)) {
                if (value < 10) value = 10;
                timeout = value;
                tbTimeoutNewline.Text = timeout.ToString();
            }
        }

        private void tbBytesNewline_KeyDown(Object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;
            if (UInt32.TryParse(tbBytesNewline.Text, out UInt32 value)) {
                if (value < 2) value = 2;
                newlineBytes = value;
                tbBytesNewline.Text = newlineBytes.ToString();
            }
        }

        private void a_parseAndSend(String text) {
            //if (!AInput.Items.Contains(text))
            //    AInput.Items.Add(AInput.Text);

            concatMessage(text);
            lastPrint_ms = (UInt64)millisSw.ElapsedMilliseconds;// Content.AppendText("\n");//if (!Content.Text.EndsWith("\n"))//    Content.AppendText("\n");//if (Timestamp.Checked)//    Content.AppendText($"{GetTimeString()} ", Color.Gray);//Content.AppendText("PC->A ", Color.DarkGray);//if (AppendNewlineEnable.Checked && !text.EndsWith("\n"))//    text += "\n";//Byte[] array = HexStringToArray(text);//String hexStr = HexArrayToHexString(array);//String complexStr = HexArrayToComplexString(array);//if (HexPrefixEnable.Checked) {//    if (DisplayAsHex.Checked)//        Content.AppendText(hexStr, Color.Green);//    else//        Content.AppendText(complexStr, Color.Green);//}//else {//    if (DisplayAsHex.Checked)//        Content.AppendText(StringToHexString(text), Color.Green);//    else {//        Content.AppendText(text, Color.Green);//    }//}//if (portA.IsOpen)//    portA.BaseStream.Write(array, 0, array.Length);
        }

        private void b_parseAndSend(String text) {
        }

        private void a_portList_DropDown(Object sender, EventArgs e) {
            String[] ports = SerialPort.GetPortNames();
            a_cbPortList.Items.Clear();
            a_cbPortList.Items.AddRange(ports);
        }

        private void a_cbBaudList_SelectedIndexChanged(Object sender, EventArgs e) => portA.BaudRate = Int32.Parse(a_cbBaudList.Text);

        private void a_cbDtr_CheckedChanged(Object sender, EventArgs e) => portA.DtrEnable = a_cbDtr.Checked;

        private void a_cbRts_CheckedChanged(Object sender, EventArgs e) => portA.RtsEnable = a_cbRts.Checked;

        private void a_btConnect_Click(Object sender, EventArgs e) {
            concatMessage(String.Format("opening {0}...", a_cbPortList.Text));
            tbOutput.Refresh();

            try {
                if (portA.IsOpen) portA.Close();
                portA.PortName = a_cbPortList.Text;
                portA.Open();
                a_btOpen.Enabled = false;
                a_cbBaudList.Enabled = false;
                concatMessage(String.Format("{0} opened", portA.PortName));
            }
            catch (Exception exc) {
                concatMessage(String.Format("cannot open {0}, trace: {1}", portA.PortName, exc.ToString()));
            }
        }

        private void clearHistoryToolStripMenuItem_Click(Object sender, EventArgs e) {
            ToolStripItem item = (sender as ToolStripItem);
            //if (item.GetParrentControl().Equals(inputA)) {
            //    inputA.AutoCompleteCustomSource.Clear();
            //}
            //if (item.GetParrentControl().Equals(inputB)) {
            //    inputB.AutoCompleteCustomSource.Clear();
            //}
        }

        private void clearToolStripMenuItem_Click(Object sender, EventArgs e) {
            ToolStripItem item = (sender as ToolStripItem);
            //if (item.GetParrentControl().Equals(inputA)) {
            //    inputA.Clear();
            //}
            //if (item.GetParrentControl().Equals(inputB)) {
            //    inputB.Clear();
            //}
        }

        private void b_cbPortList_DropDown(Object sender, EventArgs e) {
            String[] ports = SerialPort.GetPortNames();
            b_cbPortList.Items.Clear();
            b_cbPortList.Items.AddRange(ports);
        }

        private void tbOutput_VisibleRangeChanged(Object sender, EventArgs e) {
            Range range = tbOutput.VisibleRange;
            range.ClearStyle(StyleIndex.All);
            tbOutput.VisibleRange.SetStyle(timestampStyle, @"[0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{3} ", RegexOptions.Singleline);
            tbOutput.VisibleRange.SetStyle(directionStyle, @"(A |B |PC)->(A  |B  |PC )", RegexOptions.Singleline);
            tbOutput.VisibleRange.SetStyle(pcSourceStyle, @"(?<=PC->A  |PC->B  ).+?(?=([0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{3} )|(A |B |PC)->(A  |B  |PC )|$)", RegexOptions.Singleline);
            tbOutput.VisibleRange.SetStyle(aSourceStyle, @"(?<=A ->B  |A ->PC ).+?(?=([0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{3} )|(A |B |PC)->(A  |B  |PC )|$)", RegexOptions.Singleline);
            tbOutput.VisibleRange.SetStyle(bSourceStyle, @"(?<=B ->A  |B ->PC ).+?(?=([0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{3} )|(A |B |PC)->(A  |B  |PC )|$)", RegexOptions.Singleline);

            tbOutput.Range.ClearStyle(invisibleCharsStyle);
            tbOutput.Range.SetStyle(invisibleCharsStyle, @".$|.\r\n|\s");
        }

        private void tbOutput_AutoIndentNeeded(Object sender, AutoIndentEventArgs e) {
            /*Boolean hasHeader = Regex.IsMatch(e.LineText, @"^\s*(([0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{3})|((A |B |PC)->(A  |B  |PC ))).+");
            if (!hasHeader)
                e.AbsoluteIndentation = 20;
            else
                e.AbsoluteIndentation = 0;*/
        }

        private void b_btConnect_Click(Object sender, EventArgs e) {
            concatMessage(String.Format("opening {0}...", b_cbPortList.Text));
            tbOutput.Refresh();

            try {
                if (portB.IsOpen) portB.Close();
                portB.PortName = b_cbPortList.Text;
                portB.Open();
                b_btConnect.Enabled = false;
                b_cbBaudList.Enabled = false;
                concatMessage(String.Format("{0} opened", portB.PortName));
            }
            catch (Exception exc) {
                concatMessage(String.Format("cannot open {0}, trace: {1}", portB.PortName, exc.ToString()));
            }
        }

        private void a_tbInput_KeyDown(Object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Return) {
                String text = a_tbInput.Text;

                a_parseAndSend(text);
                FastColoredTextBoxNS.AutocompleteItem item = new FastColoredTextBoxNS.AutocompleteItem(text);
                if (!autoCompleteList.ToStringList().Contains(text)) {
                    if (text.Length > 30) {
                        String textLimited = text.Length > 1024 ? text.Substring(0, 1024) : text;
                        item.ToolTipText = textLimited;
                        item.ToolTipTitle = "Full text";

                        text = text.Substring(0, 30);
                    }

                    text = text.Replace("\r\n", " ");
                    text = text.Replace("\n", " ");

                    autoCompleteList.Add(item);

                    a_inputPopup.Items.SetAutocompleteItems(autoCompleteList);
                }

                a_tbInput.Text = String.Empty;
                e.Handled = true;
            }
        }

        private void btLinkSignal_CheckedChanged(Object sender, EventArgs e) {
            //linkedSignal = btLink.Checked;

            Boolean aCts = portA.IsOpen ? portA.CtsHolding : false,
            aDsr = portA.IsOpen ? portA.DsrHolding : false,
            bCts = portB.IsOpen ? portB.CtsHolding : false,
            bDsr = portB.IsOpen ? portB.DsrHolding : false;

            if (portB.IsOpen && linkedSignal) {
                portB.DtrEnable = aDsr;
                b_cbDtr.Checked = aDsr;
            }

            lastADsr = aDsr;
            a_cbDsr.Checked = aDsr;

            if (portB.IsOpen && linkedSignal) {
                portB.RtsEnable = aCts;
                b_cbRts.Checked = aCts;
            }

            lastACts = aCts;
            a_cbCts.Checked = aCts;

            if (portA.IsOpen && linkedSignal) {
                portA.DtrEnable = bDsr;
                a_cbDtr.Checked = bDsr;
            }

            lastBDsr = bDsr;
            b_cbDsr.Checked = bDsr;

            if (portA.IsOpen && linkedSignal) {
                portA.RtsEnable = bCts;
                a_cbRts.Checked = bCts;
            }

            lastBCts = bCts;
            b_cbCts.Checked = bCts;
        }

        private void btLinkData_CheckedChanged(Object sender, EventArgs e) => tbOutput.DoAutoIndent();

        private void b_cbDtr_CheckedChanged(Object sender, EventArgs e) => portB.DtrEnable = b_cbDtr.Checked;

        private void b_cbRts_CheckedChanged(Object sender, EventArgs e) => portB.RtsEnable = b_cbRts.Checked;

        private void b_cbBaudList_SelectedIndexChanged(Object sender, EventArgs e) => portB.BaudRate = Int32.Parse(b_cbBaudList.Text);
    }
}