using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace FastColoredTextBoxNS {

    /// <summary>
    /// This class contains the source text (chars and styles). It stores a text lines, the manager
    /// of commands, undo/redo stack, styles.
    /// </summary>
    public class TextSource : IList<Line>, IDisposable {
        protected readonly List<Line> lines = new List<Line>();
        protected LinesAccessor linesAccessor;
        private Int32 lastLineUniqueId;
        public CommandManager Manager { get; set; }

        private FastColoredTextBox currentTB;

        /// <summary>
        /// Styles
        /// </summary>
        public readonly Style[] Styles;

        /// <summary>
        /// Occurs when line was inserted/added
        /// </summary>
        public event EventHandler<LineInsertedEventArgs> LineInserted;
        /// <summary>
        /// Occurs when line was removed
        /// </summary>
        public event EventHandler<LineRemovedEventArgs> LineRemoved;
        /// <summary>
        /// Occurs when text was changed
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged;
        /// <summary>
        /// Occurs when recalc is needed
        /// </summary>
        public event EventHandler<TextChangedEventArgs> RecalcNeeded;
        /// <summary>
        /// Occurs when recalc wordwrap is needed
        /// </summary>
        public event EventHandler<TextChangedEventArgs> RecalcWordWrap;
        /// <summary>
        /// Occurs before text changing
        /// </summary>
        public event EventHandler<TextChangingEventArgs> TextChanging;
        /// <summary>
        /// Occurs after CurrentTB was changed
        /// </summary>
        public event EventHandler CurrentTBChanged;
        /// <summary>
        /// Current focused FastColoredTextBox
        /// </summary>
        public FastColoredTextBox CurrentTB {
            get => currentTB;
            set {
                if (currentTB == value)
                    return;
                currentTB = value;
                OnCurrentTBChanged();
            }
        }

        public virtual void ClearIsChanged() {
            foreach (Line line in lines)
                line.IsChanged = false;
        }

        public virtual Line CreateLine() => new Line(GenerateUniqueLineId());

        private void OnCurrentTBChanged() {
            if (CurrentTBChanged != null)
                CurrentTBChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Default text style This style is using when no one other TextStyle is not defined in Char.style
        /// </summary>
        public TextStyle DefaultStyle { get; set; }

        public TextSource(FastColoredTextBox currentTB) {
            CurrentTB = currentTB;
            linesAccessor = new LinesAccessor(this);
            Manager = new CommandManager(this);

            if (Enum.GetUnderlyingType(typeof(StyleIndex)) == typeof(UInt32))
                Styles = new Style[32];
            else
                Styles = new Style[16];

            InitDefaultStyle();
        }

        public virtual void InitDefaultStyle() => DefaultStyle = new TextStyle(null, null, FontStyle.Regular);

        public virtual Line this[Int32 i] {
            get => lines[i];
            set => throw new NotImplementedException();
        }

        public virtual Boolean IsLineLoaded(Int32 iLine) => lines[iLine] != null;

        /// <summary>
        /// Text lines
        /// </summary>
        public virtual IList<String> GetLines() => linesAccessor;

        public IEnumerator<Line> GetEnumerator() => lines.GetEnumerator();

        IEnumerator System.Collections.IEnumerable.GetEnumerator() => (lines as IEnumerator);

        public virtual Int32 BinarySearch(Line item, IComparer<Line> comparer) => lines.BinarySearch(item, comparer);

        public virtual Int32 GenerateUniqueLineId() => lastLineUniqueId++;

        public virtual void InsertLine(Int32 index, Line line) {
            lines.Insert(index, line);
            OnLineInserted(index);
        }

        public virtual void OnLineInserted(Int32 index) => OnLineInserted(index, 1);

        public virtual void OnLineInserted(Int32 index, Int32 count) {
            if (LineInserted != null)
                LineInserted(this, new LineInsertedEventArgs(index, count));
        }

        public virtual void RemoveLine(Int32 index) => RemoveLine(index, 1);

        public virtual Boolean IsNeedBuildRemovedLineIds => LineRemoved != null;

        public virtual void RemoveLine(Int32 index, Int32 count) {
            List<Int32> removedLineIds = new List<Int32>();

            if (count > 0)
                if (IsNeedBuildRemovedLineIds)
                    for (Int32 i = 0; i < count; i++)
                        removedLineIds.Add(this[index + i].UniqueId);

            lines.RemoveRange(index, count);

            OnLineRemoved(index, count, removedLineIds);
        }

        public virtual void OnLineRemoved(Int32 index, Int32 count, List<Int32> removedLineIds) {
            if (count > 0)
                if (LineRemoved != null)
                    LineRemoved(this, new LineRemovedEventArgs(index, count, removedLineIds));
        }

        public virtual void OnTextChanged(Int32 fromLine, Int32 toLine) {
            if (TextChanged != null)
                TextChanged(this, new TextChangedEventArgs(Math.Min(fromLine, toLine), Math.Max(fromLine, toLine)));
        }

        public class TextChangedEventArgs : EventArgs {
            public Int32 iFromLine;
            public Int32 iToLine;

            public TextChangedEventArgs(Int32 iFromLine, Int32 iToLine) {
                this.iFromLine = iFromLine;
                this.iToLine = iToLine;
            }
        }

        public virtual Int32 IndexOf(Line item) => lines.IndexOf(item);

        public virtual void Insert(Int32 index, Line item) => InsertLine(index, item);

        public virtual void RemoveAt(Int32 index) => RemoveLine(index);

        public virtual void Add(Line item) => InsertLine(Count, item);

        public virtual void Clear() => RemoveLine(0, Count);

        public virtual Boolean Contains(Line item) => lines.Contains(item);

        public virtual void CopyTo(Line[] array, Int32 arrayIndex) => lines.CopyTo(array, arrayIndex);

        /// <summary>
        /// Lines count
        /// </summary>
        public virtual Int32 Count => lines.Count;

        public virtual Boolean IsReadOnly => false;

        public virtual Boolean Remove(Line item) {
            Int32 i = IndexOf(item);
            if (i >= 0) {
                RemoveLine(i);
                return true;
            }
            else
                return false;
        }

        public virtual void NeedRecalc(TextChangedEventArgs args) {
            if (RecalcNeeded != null)
                RecalcNeeded(this, args);
        }

        public virtual void OnRecalcWordWrap(TextChangedEventArgs args) {
            if (RecalcWordWrap != null)
                RecalcWordWrap(this, args);
        }

        public virtual void OnTextChanging() {
            String temp = null;
            OnTextChanging(ref temp);
        }

        public virtual void OnTextChanging(ref String text) {
            if (TextChanging != null) {
                TextChangingEventArgs args = new TextChangingEventArgs() { InsertingText = text };
                TextChanging(this, args);
                text = args.InsertingText;
                if (args.Cancel)
                    text = String.Empty;
            };
        }

        public virtual Int32 GetLineLength(Int32 i) => lines[i].Count;

        public virtual Boolean LineHasFoldingStartMarker(Int32 iLine) => !String.IsNullOrEmpty(lines[iLine].FoldingStartMarker);

        public virtual Boolean LineHasFoldingEndMarker(Int32 iLine) => !String.IsNullOrEmpty(lines[iLine].FoldingEndMarker);

        public virtual void Dispose() {
            ;
        }

        public virtual void SaveToFile(String fileName, Encoding enc) {
            using (StreamWriter sw = new StreamWriter(fileName, false, enc)) {
                for (Int32 i = 0; i < Count - 1; i++)
                    sw.WriteLine(lines[i].Text);

                sw.Write(lines[Count - 1].Text);
            }
        }
    }
}