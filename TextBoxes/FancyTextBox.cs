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
        private Dictionary<string,TextStyle> Styles { get; set; }

        /// <summary>
        /// Use this to make direct edits to the rich text box.
        /// </summary>
        public ref RichTextBox TextBox { get { return ref RichTextBox; } }

        public FancyTextBox()
        {
            InitializeComponent();
        }

        public void AddStyle(int priority, string startsWith, string endsWith, FontStyle fontStyle = FontStyle.Regular)
        {
            Styles.Add(startsWith,
                new TextStyle
                {
                    Priority = priority,
                    Color = Color.Black,
                    FontStyle = fontStyle,
                    EndsWith = endsWith
                });
        }

        public void AddStyle(int priority, string startsWith, string endsWith, Color color, FontStyle fontStyle=FontStyle.Regular)
        {
            Styles.Add(startsWith,
                new TextStyle
                {
                    Priority = priority,
                    Color = color,
                    FontStyle = fontStyle,
                    EndsWith = endsWith
                });
            UpdateText();
        }

        /// <summary>
        /// Modifies the style with the key startsWith to the specified style.
        /// </summary>
        /// <param name="startsWith"></param>
        /// <param name="style"></param>
        /// <returns>True if a style starts with string startsWith. False otherwise.</returns>
        public bool ModifyStyle(string startsWith, TextStyle style)
        {
            if (!Styles.ContainsKey(startsWith)) return false;
            
            Styles[startsWith] = style; UpdateText(); return true;
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
            string text = RichTextBox.Text;
            Dictionary<int, int> startEnds = new Dictionary<int, int>();

            // Need to figure out how to do this efficiently.
            for (int j = 0; j < text.Length; j++)
            {

            }
        }

        private void RichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = 0, l = 0, s = RichTextBox.SelectionStart;
            foreach (var key in Styles.Keys)
            {
                l = key.Length; i = s - l;
                if (i > 0 && RichTextBox.Text.Substring(i,l) == key)
                {
                    TextStyles.Add(Styles[key]);
                }
            }
        }

        private void RichTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }

    public class TextStyle
    {
        public int Priority { get; set; }
        public Color Color { get; set; }
        public FontStyle FontStyle { get; set; }
        public string EndsWith { get; set; }

        public static bool operator !=(TextStyle textStyle1, TextStyle textStyle2)
        {
            return !(textStyle1 == textStyle2);
        }

        public static bool operator ==(TextStyle textStyle1, TextStyle textStyle2)
        {
            if (textStyle1.Priority != textStyle2.Priority) return false;
            if (textStyle1.Color != textStyle2.Color) return false;
            if (textStyle1.FontStyle != textStyle2.FontStyle) return false;
            if (textStyle1.EndsWith != textStyle2.EndsWith) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return this == (TextStyle)obj;
        }

        public override int GetHashCode()
        {
            return Color.ToArgb() + Priority + FontStyle.GetHashCode() + EndsWith.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Priority}: {Color} {FontStyle} (Ends With: {EndsWith})";
        }
    }
}
