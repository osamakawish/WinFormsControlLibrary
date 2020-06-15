using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxes
{
    /// <summary>
    /// A text box that allows stronger control of the rich text Box.
    /// </summary>
    public partial class FancyTextBox: RichTextBox
    {
        private List<TextStyle> TextStyles { get; set; }

        /// <summary>
        /// The style of the text to be followed by the string in the key, ending with the string in TextStyle.EndsWith. 
        /// The Color and FontStyle of the text are changed to match the TextStyle.
        /// </summary>
        private Dictionary<string,KeyValuePair<string,TextStyle>> Styles { get; set; }

        public FancyTextBox()
        {
            this.KeyPress += KeyPressEvent;
            this.KeyUp += KeyUpEvent;
        }

        public void AddStyle(int priority, string startsWith, string endsWith, FontStyle fontStyle = FontStyle.Regular)
        {
            Styles.Add(startsWith, new KeyValuePair<string, TextStyle> (endsWith,
                new TextStyle
                {
                    Priority = priority,
                    Color = Color.Black,
                    FontStyle = fontStyle
                }));
        }

        public void AddStyle(int priority, string startsWith, string endsWith, Color color, FontStyle fontStyle=FontStyle.Regular)
        {
            Styles.Add(startsWith, new KeyValuePair<string, TextStyle> (endsWith,
                new TextStyle
                {
                    Priority = priority,
                    Color = color,
                    FontStyle = fontStyle
                }));
            UpdateText();
        }

        /// <summary>
        /// Modifies the style with the key startsWith to the specified style.
        /// </summary>
        /// <param name="startsWith"></param>
        /// <param name="style"></param>
        /// <returns>True if a style starts with string startsWith. False otherwise.</returns>
        public bool ModifyStyle(string startsWith, string endsWith, TextStyle style)
        {
            if (!Styles.ContainsKey(startsWith)) return false;
            
            Styles[startsWith] = new KeyValuePair<string, TextStyle>(endsWith, style); UpdateText(); return true;
        }

        /// <summary>
        /// Removes the style with the given key.
        /// </summary>
        /// <param name="startsWith"></param>
        /// <returns>True if a style starts with string startsWith. False otherwise.</returns>
        public bool RemoveStyle(string startsWith)
        {
            if (Styles.ContainsKey(startsWith)) { Styles.Remove(startsWith); UpdateText(); return true; }
            return false;
        }

        /// <summary>
        /// Called whenever the styling is modified.
        /// </summary>
        private void UpdateText()
        {
            Dictionary<int, HashSet<string>> keyLengths = new Dictionary<int, HashSet<string>>();
            // Organize dict keys by string length
            foreach (var key in Styles.Keys) {
                var l = key.Length;
                if (keyLengths.ContainsKey(l))
                {
                    keyLengths[l].Add(key);
                }
                else
                {
                    keyLengths.Add(l, new HashSet<string> { key });
                }
            } 

            // Need to account for Style Priority
            for (int textPos = 0; textPos < Text.Length; textPos++)
            {
                foreach (var len in keyLengths.Keys)
                {
                    if (len < textPos) UpdateTextStyle(textPos, len, keyLengths);
                }
            }
        }

        private void UpdateTextStyle(int textPos, int len, Dictionary<int, HashSet<string>> keyLengths)
        {
            foreach (var str in keyLengths[len])
            {
                if (Text.Substring(0, len).EndsWith(str))
                {
                    // Style the text.
                    StyleSelection(textPos - len, textPos, Styles[str].Value);
                }
            }

            // Maintain the text formatting until the end string is reached.
        }

        private void KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            int s = this.SelectionStart;

            foreach (var key in Styles.Keys)
            {
                int l = key.Length;
                int i = s - l;
                if (i > 0 && this.Text.Substring(i,l) == key)
                {
                    // DO NOT REMOVE. Line added for readability.
                    TextStyle style = Styles[key].Value;
                    
                    TextStyles.Add(style);
                }
            }
        }

        public void StyleSelection(int start, int end, TextStyle style)
        {
            int s = SelectionStart, l = SelectionLength;

            Select(start, end - start);
            SelectionColor = style.Color;
            Font ft = SelectionFont;
            SelectionFont = new Font(ft, style.FontStyle);

            Select(s, l);
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {

        }
    }

    public class TextStyle
    {
        public int Priority { get; set; }
        public Color Color { get; set; }
        public FontStyle FontStyle { get; set; }

        public static bool operator !=(TextStyle textStyle1, TextStyle textStyle2)
        {
            return !(textStyle1 == textStyle2);
        }

        public static bool operator ==(TextStyle textStyle1, TextStyle textStyle2)
        {
            if (textStyle1.Priority != textStyle2.Priority) return false;
            if (textStyle1.Color != textStyle2.Color) return false;
            if (textStyle1.FontStyle != textStyle2.FontStyle) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return this == (TextStyle)obj;
        }

        public override int GetHashCode()
        {
            return Color.ToArgb() * Priority * FontStyle.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Priority}: {Color} {FontStyle}";
        }
    }
}
