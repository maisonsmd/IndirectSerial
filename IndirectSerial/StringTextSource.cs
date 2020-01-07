using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndirectSerial {

    /// <summary>
    /// Text source for displaying readonly text, given as string.
    /// </summary>
    public class StringTextSource : TextSource, IDisposable {
        private List<Int32> sourceStringLinePositions = new List<Int32>();
        private String sourceString;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public StringTextSource(FastColoredTextBox tb)
            : base(tb) {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        private void timer_Tick(Object sender, EventArgs e) {
            timer.Enabled = false;
            try {
                UnloadUnusedLines();
            }
            finally {
                timer.Enabled = true;
            }
        }

        private void UnloadUnusedLines() {
            const Int32 margin = 2000;
            Int32 iStartVisibleLine = CurrentTB.VisibleRange.Start.iLine;
            Int32 iFinishVisibleLine = CurrentTB.VisibleRange.End.iLine;

            Int32 count = 0;
            for (Int32 i = 0; i < Count; i++)
                if (base.lines[i] != null && !base.lines[i].IsChanged && Math.Abs(i - iFinishVisibleLine) > margin) {
                    base.lines[i] = null;
                    count++;
                }
#if debug
            Console.WriteLine("UnloadUnusedLines: " + count);
#endif
        }

        public void OpenString(String sourceString) {
            Clear();
            lines.Clear();
            sourceStringLinePositions.Clear();

            this.sourceString = sourceString;

            //parse lines
            Int32 index = -1;
            do {
                sourceStringLinePositions.Add(index + 1);
                base.lines.Add(null);
                index = sourceString.IndexOf('\n', index + 1);
            } while (index >= 0);

            OnLineInserted(0, Count);

            //load first lines for calc width of the text
            Int32 linesCount = Math.Min(lines.Count, CurrentTB.Height / CurrentTB.CharHeight);
            for (Int32 i = 0; i < linesCount; i++)
                LoadLineFromSourceString(i);

            NeedRecalc(new TextChangedEventArgs(0, linesCount - 1));
            if (CurrentTB.WordWrap)
                OnRecalcWordWrap(new TextChangedEventArgs(0, linesCount - 1));
        }

        public override void ClearIsChanged() {
            foreach (Line line in lines)
                if (line != null)
                    line.IsChanged = false;
        }

        public override Line this[Int32 i] {
            get {
                if (base.lines[i] != null)
                    return lines[i];
                else
                    LoadLineFromSourceString(i);

                return lines[i];
            }
            set => throw new NotImplementedException();
        }

        private void LoadLineFromSourceString(Int32 i) {
            Line line = CreateLine();
            String s;
            if (i == Count - 1)
                s = sourceString.Substring(sourceStringLinePositions[i]);
            else
                s = sourceString.Substring(sourceStringLinePositions[i], sourceStringLinePositions[i + 1] - sourceStringLinePositions[i] - 1);

            foreach (Char c in s)
                line.Add(new StyledChar(c));

            base.lines[i] = line;

            if (CurrentTB.WordWrap)
                OnRecalcWordWrap(new TextChangedEventArgs(i, i));
        }

        public override void InsertLine(Int32 index, Line line) {
            //throw new NotImplementedException();
            if (index < 0 || index >= lines.Count)
                //throw new IndexOutOfRangeException();
                return;
            lines.Insert(index, line);
        }

        public override void RemoveLine(Int32 index, Int32 count) {
            if (count == 0) return;
            //throw new NotImplementedException();
            if (index < 0 || index >= lines.Count || index + count >= lines.Count)
                //throw new IndexOutOfRangeException();
                return;
            lines.RemoveRange(index, count);
        }

        public override Int32 GetLineLength(Int32 i) {
            if (base.lines[i] == null)
                return 0;
            else
                return base.lines[i].Count;
        }

        public override Boolean LineHasFoldingStartMarker(Int32 iLine) {
            if (lines[iLine] == null)
                return false;
            else
                return !String.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
        }

        public override Boolean LineHasFoldingEndMarker(Int32 iLine) {
            if (lines[iLine] == null)
                return false;
            else
                return !String.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
        }

        public override void Dispose() => timer.Dispose();

        internal void UnloadLine(Int32 iLine) {
            if (lines[iLine] != null && !lines[iLine].IsChanged)
                lines[iLine] = null;
        }
    }
}