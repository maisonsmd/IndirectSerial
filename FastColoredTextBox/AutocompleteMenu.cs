﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastColoredTextBoxNS {

    /// <summary>
    /// Popup menu for autocomplete
    /// </summary>
    [Browsable(false)]
    public class AutocompleteMenu : ToolStripDropDown, IDisposable {
        private AutocompleteListView listView;
        public ToolStripControlHost host;
        public Range Fragment { get; internal set; }

        /// <summary>
        /// Regex pattern for serach fragment around caret
        /// </summary>
        public String SearchPattern { get; set; }

        /// <summary>
        /// Minimum fragment length for popup
        /// </summary>
        public Int32 MinFragmentLength { get; set; }

        /// <summary>
        /// User selects item
        /// </summary>
        public event EventHandler<SelectingEventArgs> Selecting;
        /// <summary>
        /// It fires after item inserting
        /// </summary>
        public event EventHandler<SelectedEventArgs> Selected;
        /// <summary>
        /// Occurs when popup menu is opening
        /// </summary>
        public new event EventHandler<CancelEventArgs> Opening;
        /// <summary>
        /// Allow TAB for select menu item
        /// </summary>
        public Boolean AllowTabKey { get => listView.AllowTabKey; set => listView.AllowTabKey = value; }

        /// <summary>
        /// Interval of menu appear (ms)
        /// </summary>
        public Int32 AppearInterval { get => listView.AppearInterval; set => listView.AppearInterval = value; }

        /// <summary>
        /// Sets the max tooltip window size
        /// </summary>
        public Size MaxTooltipSize { get => listView.MaxToolTipSize; set => listView.MaxToolTipSize = value; }

        /// <summary>
        /// Tooltip will perm show and duration will be ignored
        /// </summary>
        public Boolean AlwaysShowTooltip { get => listView.AlwaysShowTooltip; set => listView.AlwaysShowTooltip = value; }

        /// <summary>
        /// Back color of selected item
        /// </summary>
        [DefaultValue(typeof(Color), "Orange")]
        public Color SelectedColor {
            get => listView.SelectedColor;
            set => listView.SelectedColor = value;
        }

        /// <summary>
        /// Border color of hovered item
        /// </summary>
        [DefaultValue(typeof(Color), "Red")]
        public Color HoveredColor {
            get => listView.HoveredColor;
            set => listView.HoveredColor = value;
        }

        public AutocompleteMenu(FastColoredTextBox tb) {
            // create a new popup and add the list view to it
            AutoClose = false;
            AutoSize = false;
            Margin = Padding.Empty;
            Padding = Padding.Empty;
            BackColor = Color.White;
            listView = new AutocompleteListView(tb);
            host = new ToolStripControlHost(listView) {
                Margin = new Padding(2, 2, 2, 2),
                Padding = Padding.Empty,
                AutoSize = false,
                AutoToolTip = false
            };
            CalcSize();
            base.Items.Add(host);
            listView.Parent = this;
            SearchPattern = @"[\w\.]";
            MinFragmentLength = 2;
        }

        public new Font Font {
            get => listView.Font;
            set => listView.Font = value;
        }

        internal new void OnOpening(CancelEventArgs args) {
            if (Opening != null)
                Opening(this, args);
        }

        public new void Close() {
            listView.toolTip.Hide(listView);
            base.Close();
        }

        internal void CalcSize() {
            host.Size = listView.Size;
            Size = new System.Drawing.Size(listView.Size.Width + 4, listView.Size.Height + 4);
        }

        public virtual void OnSelecting() => listView.OnSelecting();

        public void SelectNext(Int32 shift) => listView.SelectNext(shift);

        internal void OnSelecting(SelectingEventArgs args) {
            if (Selecting != null)
                Selecting(this, args);
        }

        public void OnSelected(SelectedEventArgs args) {
            if (Selected != null)
                Selected(this, args);
        }

        public new AutocompleteListView Items => listView;

        /// <summary>
        /// Shows popup menu immediately
        /// </summary>
        /// <param name="forced">If True - MinFragmentLength will be ignored</param>
        public void Show(Boolean forced) => Items.DoAutocomplete(forced);

        /// <summary>
        /// Minimal size of menu
        /// </summary>
        public new Size MinimumSize {
            get => Items.MinimumSize;
            set => Items.MinimumSize = value;
        }

        /// <summary>
        /// Image list of menu
        /// </summary>
        public new ImageList ImageList {
            get => Items.ImageList;
            set => Items.ImageList = value;
        }

        /// <summary>
        /// Tooltip duration (ms)
        /// </summary>
        public Int32 ToolTipDuration {
            get => Items.ToolTipDuration;
            set => Items.ToolTipDuration = value;
        }

        /// <summary>
        /// Tooltip
        /// </summary>
        public ToolTip ToolTip {
            get => Items.toolTip;
            set => Items.toolTip = value;
        }

        protected override void Dispose(Boolean disposing) {
            base.Dispose(disposing);
            if (listView != null && !listView.IsDisposed)
                listView.Dispose();
        }
    }

    [System.ComponentModel.ToolboxItem(false)]
    public class AutocompleteListView : UserControl, IDisposable {
        public event EventHandler FocussedItemIndexChanged;

        internal List<AutocompleteItem> visibleItems;
        private IEnumerable<AutocompleteItem> sourceItems = new List<AutocompleteItem>();
        private Int32 focussedItemIndex = 0;
        private Int32 hoveredItemIndex = -1;

        private Int32 ItemHeight => Font.Height + 2;

        private AutocompleteMenu Menu => Parent as AutocompleteMenu;

        private Int32 oldItemCount = 0;
        private FastColoredTextBox tb;
        internal ToolTip toolTip = new ToolTip();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        internal Boolean AllowTabKey { get; set; }
        public ImageList ImageList { get; set; }
        internal Int32 AppearInterval { get => timer.Interval; set => timer.Interval = value; }
        internal Int32 ToolTipDuration { get; set; }
        internal Size MaxToolTipSize { get; set; }
        internal Boolean AlwaysShowTooltip {
            get => toolTip.ShowAlways;
            set => toolTip.ShowAlways = value;
        }

        public Color SelectedColor { get; set; }
        public Color HoveredColor { get; set; }
        public Int32 FocussedItemIndex {
            get => focussedItemIndex;
            set {
                if (focussedItemIndex != value) {
                    focussedItemIndex = value;
                    if (FocussedItemIndexChanged != null)
                        FocussedItemIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public AutocompleteItem FocussedItem {
            get {
                if (FocussedItemIndex >= 0 && focussedItemIndex < visibleItems.Count)
                    return visibleItems[focussedItemIndex];
                return null;
            }
            set => FocussedItemIndex = visibleItems.IndexOf(value);
        }

        internal AutocompleteListView(FastColoredTextBox tb) {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            base.Font = new Font(FontFamily.GenericSansSerif, 9);
            visibleItems = new List<AutocompleteItem>();
            VerticalScroll.SmallChange = ItemHeight;
            MaximumSize = new Size(Size.Width, 180);
            toolTip.ShowAlways = false;
            AppearInterval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            SelectedColor = Color.Orange;
            HoveredColor = Color.Red;
            ToolTipDuration = 3000;
            toolTip.Popup += ToolTip_Popup;

            this.tb = tb;

            tb.KeyDown += new KeyEventHandler(tb_KeyDown);
            tb.SelectionChanged += new EventHandler(tb_SelectionChanged);
            tb.KeyPressed += new KeyPressEventHandler(tb_KeyPressed);

            Form form = tb.FindForm();
            if (form != null) {
                form.LocationChanged += delegate { SafetyClose(); };
                form.ResizeBegin += delegate { SafetyClose(); };
                form.FormClosing += delegate { SafetyClose(); };
                form.LostFocus += delegate { SafetyClose(); };
            }

            tb.LostFocus += (o, e) => {
                if (Menu != null && !Menu.IsDisposed)
                    if (!Menu.Focused)
                        SafetyClose();
            };

            tb.Scroll += delegate { SafetyClose(); };

            VisibleChanged += (o, e) => {
                if (Visible)
                    DoSelectedVisible();
            };
        }

        private void ToolTip_Popup(Object sender, PopupEventArgs e) {
            if (MaxToolTipSize.Height > 0 && MaxToolTipSize.Width > 0)
                e.ToolTipSize = MaxToolTipSize;
        }

        protected override void Dispose(Boolean disposing) {
            if (toolTip != null) {
                toolTip.Popup -= ToolTip_Popup;
                toolTip.Dispose();
            }
            if (tb != null) {
                tb.KeyDown -= tb_KeyDown;
                tb.KeyPressed -= tb_KeyPressed;
                tb.SelectionChanged -= tb_SelectionChanged;
            }

            if (timer != null) {
                timer.Stop();
                timer.Tick -= timer_Tick;
                timer.Dispose();
            }

            base.Dispose(disposing);
        }

        private void SafetyClose() {
            if (Menu != null && !Menu.IsDisposed)
                Menu.Close();
        }

        private void tb_KeyPressed(Object sender, KeyPressEventArgs e) {
            Boolean backspaceORdel = e.KeyChar == '\b' || e.KeyChar == 0xff;

            /*
            if (backspaceORdel)
                prevSelection = tb.Selection.Start;*/

            if (Menu.Visible && !backspaceORdel)
                DoAutocomplete(false);
            else
                ResetTimer(timer);
        }

        private void timer_Tick(Object sender, EventArgs e) {
            timer.Stop();
            DoAutocomplete(false);
        }

        private void ResetTimer(System.Windows.Forms.Timer timer) {
            timer.Stop();
            timer.Start();
        }

        internal void DoAutocomplete() => DoAutocomplete(false);

        internal void DoAutocomplete(Boolean forced) {
            if (!Menu.Enabled) {
                Menu.Close();
                return;
            }

            visibleItems.Clear();
            FocussedItemIndex = 0;
            VerticalScroll.Value = 0;
            //some magic for update scrolls
            AutoScrollMinSize -= new Size(1, 0);
            AutoScrollMinSize += new Size(1, 0);
            //get fragment around caret
            Range fragment = tb.Selection.GetFragment(Menu.SearchPattern);
            String text = fragment.Text;
            //calc screen point for popup menu
            Point point = tb.PlaceToPoint(fragment.End);
            point.Offset(2, tb.CharHeight);

            if (forced || (text.Length >= Menu.MinFragmentLength
                && tb.Selection.IsEmpty /*pops up only if selected range is empty*/
                && (tb.Selection.Start > fragment.Start || text.Length == 0/*pops up only if caret is after first letter*/))) {
                Menu.Fragment = fragment;
                Boolean foundSelected = false;
                //build popup menu
                foreach (AutocompleteItem item in sourceItems) {
                    item.Parent = Menu;
                    CompareResult res = item.Compare(text);
                    if (res != CompareResult.Hidden)
                        visibleItems.Add(item);
                    if (res == CompareResult.VisibleAndSelected && !foundSelected) {
                        foundSelected = true;
                        FocussedItemIndex = visibleItems.Count - 1;
                    }
                }

                if (foundSelected) {
                    AdjustScroll();
                    DoSelectedVisible();
                }
            }

            //show popup menu
            if (Count > 0) {
                if (!Menu.Visible) {
                    CancelEventArgs args = new CancelEventArgs();
                    Menu.OnOpening(args);
                    if (!args.Cancel)
                        Menu.Show(tb, point);
                }

                DoSelectedVisible();
                Invalidate();
            }
            else
                Menu.Close();
        }

        private void tb_SelectionChanged(Object sender, EventArgs e) {
            /*
            FastColoredTextBox tb = sender as FastColoredTextBox;

            if (Math.Abs(prevSelection.iChar - tb.Selection.Start.iChar) > 1 ||
                        prevSelection.iLine != tb.Selection.Start.iLine)
                Menu.Close();
            prevSelection = tb.Selection.Start;*/
            if (Menu.Visible) {
                Boolean needClose = false;

                if (!tb.Selection.IsEmpty)
                    needClose = true;
                else
                    if (!Menu.Fragment.Contains(tb.Selection.Start)) {
                    if (tb.Selection.Start.iLine == Menu.Fragment.End.iLine && tb.Selection.Start.iChar == Menu.Fragment.End.iChar + 1) {
                        //user press key at end of fragment
                        System.Char c = tb.Selection.CharBeforeStart;
                        if (!Regex.IsMatch(c.ToString(), Menu.SearchPattern))//check char
                            needClose = true;
                    }
                    else
                        needClose = true;
                }

                if (needClose)
                    Menu.Close();
            }
        }

        private void tb_KeyDown(Object sender, KeyEventArgs e) {
            FastColoredTextBox tb = sender as FastColoredTextBox;

            if (Menu.Visible)
                if (ProcessKey(e.KeyCode, e.Modifiers))
                    e.Handled = true;

            if (!Menu.Visible) {
                if (tb.HotkeysMapping.ContainsKey(e.KeyData) && tb.HotkeysMapping[e.KeyData] == FCTBAction.AutocompleteMenu) {
                    DoAutocomplete();
                    e.Handled = true;
                }
                else {
                    if (e.KeyCode == Keys.Escape && timer.Enabled)
                        timer.Stop();
                }
            }
        }

        private void AdjustScroll() {
            if (oldItemCount == visibleItems.Count)
                return;

            Int32 needHeight = ItemHeight * visibleItems.Count + 1;
            Height = Math.Min(needHeight, MaximumSize.Height);
            Menu.CalcSize();

            AutoScrollMinSize = new Size(0, needHeight);
            oldItemCount = visibleItems.Count;
        }

        protected override void OnPaint(PaintEventArgs e) {
            AdjustScroll();

            Int32 itemHeight = ItemHeight;
            Int32 startI = VerticalScroll.Value / itemHeight - 1;
            Int32 finishI = (VerticalScroll.Value + ClientSize.Height) / itemHeight + 1;
            startI = Math.Max(startI, 0);
            finishI = Math.Min(finishI, visibleItems.Count);
            Int32 y = 0;
            Int32 leftPadding = 18;
            for (Int32 i = startI; i < finishI; i++) {
                y = i * itemHeight - VerticalScroll.Value;

                AutocompleteItem item = visibleItems[i];

                if (item.BackColor != Color.Transparent)
                    using (SolidBrush brush = new SolidBrush(item.BackColor))
                        e.Graphics.FillRectangle(brush, 1, y, ClientSize.Width - 1 - 1, itemHeight - 1);

                if (ImageList != null && visibleItems[i].ImageIndex >= 0)
                    e.Graphics.DrawImage(ImageList.Images[item.ImageIndex], 1, y);

                if (i == FocussedItemIndex)
                    using (var selectedBrush = new LinearGradientBrush(new Point(0, y - 3), new Point(0, y + itemHeight), Color.Transparent, SelectedColor))
                    //using (SolidBrush selectedBrush = new SolidBrush(SelectedColor))// (new Point(0, y - 3), new Point(0, y + itemHeight), Color.Transparent, SelectedColor))
                    using (Pen pen = new Pen(SelectedColor)) {
                        e.Graphics.FillRectangle(selectedBrush, leftPadding, y, ClientSize.Width - 1 - leftPadding, itemHeight - 1);
                        e.Graphics.DrawRectangle(pen, leftPadding, y, ClientSize.Width - 1 - leftPadding, itemHeight - 1);
                    }

                if (i == hoveredItemIndex)
                    using (Pen pen = new Pen(HoveredColor))
                        e.Graphics.DrawRectangle(pen, leftPadding, y, ClientSize.Width - 1 - leftPadding, itemHeight - 1);

                using (SolidBrush brush = new SolidBrush(item.ForeColor != Color.Transparent ? item.ForeColor : ForeColor))
                    e.Graphics.DrawString(item.ToString(), Font, brush, leftPadding, y);
            }
        }

        protected override void OnScroll(ScrollEventArgs se) {
            base.OnScroll(se);
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                FocussedItemIndex = PointToItemIndex(e.Location);
                DoSelectedVisible();
                Invalidate();
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e) {
            base.OnMouseDoubleClick(e);
            FocussedItemIndex = PointToItemIndex(e.Location);
            Invalidate();
            OnSelecting();
        }

        internal virtual void OnSelecting() {
            if (FocussedItemIndex < 0 || FocussedItemIndex >= visibleItems.Count)
                return;
            tb.TextSource.Manager.BeginAutoUndoCommands();
            try {
                AutocompleteItem item = FocussedItem;
                SelectingEventArgs args = new SelectingEventArgs() {
                    Item = item,
                    SelectedIndex = FocussedItemIndex
                };

                Menu.OnSelecting(args);

                if (args.Cancel) {
                    FocussedItemIndex = args.SelectedIndex;
                    Invalidate();
                    return;
                }

                if (!args.Handled) {
                    Range fragment = Menu.Fragment;
                    DoAutocomplete(item, fragment);
                }

                Menu.Close();

                SelectedEventArgs args2 = new SelectedEventArgs() {
                    Item = item,
                    Tb = Menu.Fragment.tb
                };
                item.OnSelected(Menu, args2);
                Menu.OnSelected(args2);
            }
            finally {
                tb.TextSource.Manager.EndAutoUndoCommands();
            }
        }

        private void DoAutocomplete(AutocompleteItem item, Range fragment) {
            String newText = item.GetTextForReplace();

            //replace text of fragment
            FastColoredTextBox tb = fragment.tb;

            tb.BeginAutoUndo();
            tb.TextSource.Manager.ExecuteCommand(new SelectCommand(tb.TextSource));
            if (tb.Selection.ColumnSelectionMode) {
                Place start = tb.Selection.Start;
                Place end = tb.Selection.End;
                start.iChar = fragment.Start.iChar;
                end.iChar = fragment.End.iChar;
                tb.Selection.Start = start;
                tb.Selection.End = end;
            }
            else {
                tb.Selection.Start = fragment.Start;
                tb.Selection.End = fragment.End;
            }
            tb.InsertText(newText);
            tb.TextSource.Manager.ExecuteCommand(new SelectCommand(tb.TextSource));
            tb.EndAutoUndo();
            tb.Focus();
        }

        private Int32 PointToItemIndex(Point p) => (p.Y + VerticalScroll.Value) / ItemHeight;

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData) {
            ProcessKey(keyData, Keys.None);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Boolean ProcessKey(Keys keyData, Keys keyModifiers) {
            if (keyModifiers == Keys.None)
                switch (keyData) {
                    case Keys.Down:
                        SelectNext(+1);
                        return true;

                    case Keys.PageDown:
                        SelectNext(+10);
                        return true;

                    case Keys.Up:
                        SelectNext(-1);
                        return true;

                    case Keys.PageUp:
                        SelectNext(-10);
                        return true;

                    case Keys.Enter:
                        OnSelecting();
                        return true;

                    case Keys.Tab:
                        if (!AllowTabKey)
                            break;
                        OnSelecting();
                        return true;

                    case Keys.Escape:
                        Menu.Close();
                        return true;
                }

            return false;
        }

        public void SelectNext(Int32 shift) {
            FocussedItemIndex = Math.Max(0, Math.Min(FocussedItemIndex + shift, visibleItems.Count - 1));
            DoSelectedVisible();

            Invalidate();
        }

        private void DoSelectedVisible() {
            if (FocussedItem != null)
                SetToolTip(FocussedItem);

            Int32 y = FocussedItemIndex * ItemHeight - VerticalScroll.Value;
            if (y < 0)
                VerticalScroll.Value = FocussedItemIndex * ItemHeight;
            if (y > ClientSize.Height - ItemHeight)
                VerticalScroll.Value = Math.Min(VerticalScroll.Maximum, FocussedItemIndex * ItemHeight - ClientSize.Height + ItemHeight);
            //some magic for update scrolls
            AutoScrollMinSize -= new Size(1, 0);
            AutoScrollMinSize += new Size(1, 0);
        }

        private void SetToolTip(AutocompleteItem autocompleteItem) {
            String title = autocompleteItem.ToolTipTitle;
            String text = autocompleteItem.ToolTipText;

            if (String.IsNullOrEmpty(title)) {
                toolTip.ToolTipTitle = null;
                toolTip.SetToolTip(this, null);
                return;
            }

            if (Parent != null) {
                IWin32Window window = Parent ?? this;
                Point location;

                if ((PointToScreen(Location).X + MaxToolTipSize.Width + 105) < Screen.FromControl(Parent).WorkingArea.Right)
                    location = new Point(Right + 5, 0);
                else
                    location = new Point(Left - 105 - MaximumSize.Width, 0);

                if (String.IsNullOrEmpty(text)) {
                    toolTip.ToolTipTitle = null;
                    toolTip.Show(title, window, location.X, location.Y, ToolTipDuration);
                }
                else {
                    toolTip.ToolTipTitle = title;
                    toolTip.Show(text, window, location.X, location.Y, ToolTipDuration);
                }
            }
        }

        public Int32 Count => visibleItems.Count;

        public void SetAutocompleteItems(ICollection<String> items) {
            List<AutocompleteItem> list = new List<AutocompleteItem>(items.Count);
            foreach (String item in items)
                list.Add(new AutocompleteItem(item));
            SetAutocompleteItems(list);
        }

        public void SetAutocompleteItems(IEnumerable<AutocompleteItem> items) => sourceItems = items;
    }

    public class SelectingEventArgs : EventArgs {
        public AutocompleteItem Item { get; internal set; }
        public Boolean Cancel { get; set; }
        public Int32 SelectedIndex { get; set; }
        public Boolean Handled { get; set; }
    }

    public class SelectedEventArgs : EventArgs {
        public AutocompleteItem Item { get; internal set; }
        public FastColoredTextBox Tb { get; set; }
    }
}