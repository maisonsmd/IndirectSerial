using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndirectSerial {

    public static class Extensions {

        public static String ReplaceFirst(this String text, String search, String replace) {
            Int32 pos = text.IndexOf(search);
            if (pos < 0) {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        /// <summary>
        /// Gets the last control that caused <see cref="T:System.Windows.Forms.ContextMenuStrip"/>
        /// to be displayed.
        /// </summary>
        /// <returns>
        /// The control that caused <see cref="T:System.Windows.Forms.ContextMenuStrip"/> to be displayed.
        /// </returns>
        public static Control GetParrentControl(this ToolStripItem item) {
            if (item != null) {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                    return owner.SourceControl;
            }

            return null;
        }

        public static List<String> ToStringList(this List<FastColoredTextBoxNS.AutocompleteItem> collection) {
            List<String> list = new List<String>(collection.Count);

            foreach (FastColoredTextBoxNS.AutocompleteItem item in collection) {
                list.Add(item.Text);
            }
            return list;
        }

        public static void AppendText(this RichTextBox box, String text, Color color) {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}