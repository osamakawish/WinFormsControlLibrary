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
    /// A text box that allows direct control of the RichTextBox.
    /// </summary>
    public partial class VividTextBox: RichTextBox
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontStyle"></param>
        /// <returns>Text style based on the color of the currently selected text and the given font style.</returns>
        public TextStyle GetTextStyle(FontStyle fontStyle)
        {
            return new TextStyle
            {
                Color = SelectionColor,
                FontStyle = fontStyle
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Text style based on the font style of the currently selected text and the provided color.</returns>
        public TextStyle GetTextStyle(Color color)
        {
            return new TextStyle
            {
                Color = color,
                FontStyle = SelectionFont.Style
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fontStyle"></param>
        /// <returns>Text style based on the given font style and color.</returns>
        public static TextStyle GetTextStyle(Color color, FontStyle fontStyle)
        {
            return new TextStyle
            {
                Color = color,
                FontStyle = fontStyle
            };
        }

        /// <summary>
        /// Applies the color to the current selection.
        /// </summary>
        /// <remarks>This is more efficient than defining a text style and applying it as it applies the color directly.</remarks>
        /// <param name="color"></param>
        public void ApplyStyle(Color color)
        {
            SelectionColor = color;
        }

        /// <summary>
        /// Applies the font style to the current selection. 
        /// </summary>
        /// <remarks>This is slightly more efficient than defining a text style and applying it, as it applies the font style directly.</remarks>
        /// <param name="fontStyle"></param>
        public void ApplyStyle(FontStyle fontStyle)
        {
            Font font = SelectionFont;
            SelectionFont = new Font(font, fontStyle);
        }

        /// <summary>
        /// Applies the given color and style to the text.
        /// </summary>
        /// <remarks>This does not create a new text style.</remarks>
        /// <param name="color"></param>
        /// <param name="fontStyle"></param>
        public void ApplyStyle(Color color, FontStyle fontStyle)
        {
            SelectionColor = color;
            Font ft = SelectionFont;
            SelectionFont = new Font(ft, fontStyle);
        }

        /// <summary>
        /// Styles the characters in the selection with the given style.
        /// </summary>
        /// <param name="style"></param>
        public void ApplyStyle(TextStyle style)
        {
            SelectionColor = style.Color; 
            Font ft = SelectionFont;
            SelectionFont = new Font(ft, style.FontStyle);
        }

        /// <summary>
        /// Applies the given color to the selected text. 
        /// </summary>
        /// <remarks>If selection length is 0, then the whole word containing the caret position is colored.</remarks>
        public void StyleSelection(Color color)
        {
            if (SelectionLength > 0)
            {
                ApplyStyle(color);
            }
            else
            {
                int s = SelectionStart, l = SelectionLength;
                SelectWholeWord(); ApplyStyle(color);
                Select(s, l);
            }
        }

        /// <summary>
        /// Applies the given font style to the selected text.
        /// </summary>
        /// <remarks>If selection length is 0, then the font style is applied to the whole word containing the caret position.</remarks>
        /// <param name="fontStyle"></param>
        public void StyleSelection(FontStyle fontStyle)
        {
            if (SelectionLength > 0)
            {
                ApplyStyle(fontStyle);
            }
            else
            {
                int s = SelectionStart, l = SelectionLength;
                SelectWholeWord(); ApplyStyle(fontStyle);
                Select(s, l);
            }
        }

        /// <summary>
        /// Styles the currently selected characters according to the given style.
        /// </summary>
        /// <remarks>If the selection length is 0, it styles the set of alphanumeric characters containing the selection start.</remarks>
        /// <param name="style"></param>        
        public void StyleSelection(TextStyle style) 
        {
            if (SelectionLength > 0)
            {
                ApplyStyle(style);
            }
            else
            {
                int s = SelectionStart, l = SelectionLength;
                SelectWholeWord(); ApplyStyle(style);
                Select(s, l);
            }
        }

        /// <summary>
        /// Colors the text in the provided index range.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="color"></param>
        public void StyleSelection(int start, int length, Color color)
        {
            int s = SelectionStart, l = SelectionLength;
            Select(start, length); ApplyStyle(color);
            Select(s, l);
        }

        /// <summary>
        /// Applies the font style to the text in the provided index range.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="fontStyle"></param>
        public void StyleSelection(int start, int length, FontStyle fontStyle)
        {
            int s = SelectionStart, l = SelectionLength;
            Select(start, length); ApplyStyle(fontStyle);
            Select(s, l);
        }

        /// <summary>
        /// Styles the characters within the given index range.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="style"></param>
        public void StyleSelection(int start, int length, TextStyle style)
        {
            int s = SelectionStart, l = SelectionLength;
            Select(start, length); ApplyStyle(style); Select(s, l);
        }

        /// <summary>
        /// Selects the whole word(s) containing the current selection.
        /// </summary>
        /// <remarks>A whole word is a consecutive set of letters and digits.</remarks>
        public void SelectWholeWord()
        {
            while (SelectionStart > 0 && char.IsLetterOrDigit(Text[SelectionStart])) SelectionStart--;

            for (int pos = SelectionStart + SelectionLength; char.IsLetterOrDigit(Text[pos]) && pos < Text.Length; pos++)
            {
                SelectionLength++;
            }
        }
    }

    public class TextStyle
    {
        public Color Color { get; set; }
        public FontStyle FontStyle { get; set; }

        public static bool operator !=(TextStyle textStyle1, TextStyle textStyle2)
        {
            return !(textStyle1 == textStyle2);
        }

        public static bool operator ==(TextStyle textStyle1, TextStyle textStyle2)
        {
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
            return Color.ToArgb() * FontStyle.GetHashCode();
        }

        public override string ToString()
        {
            return $"TextStyle({Color}, {FontStyle})";
        }
    }
}
