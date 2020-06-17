using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TextBoxes
{
    /// <summary>
    /// A text box that allows direct control of the RichTextBox.
    /// </summary>
    public partial class VividTextBox: RichTextBox
    {
        public VividTextBox ()
	    {
            DetectUrls = true;
            LinkClicked += (s, e) => System.Diagnostics.Process.Start(e.LinkText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns>True if at least one of the characters has the given color applied. False otherwise.</returns>
        public bool HasStyle(Color color) => HasStyle(SelectionColor, color);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontStyle"></param>
        /// <returns>True if any character in the selection contains the given font style. False otherwise.</returns>
        public bool HasStyle(FontStyle fontStyle) => HasStyle(SelectionFont.Style, fontStyle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textStyle"></param>
        /// <returns>True if any character in the selection contains the text style. False otherwise.</returns>
        public bool HasStyle(TextStyle textStyle)
            => HasStyle(new TextStyle { Color = SelectionColor, FontStyle = SelectionFont.Style }, textStyle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="color"></param>
        /// <returns>True if any character in the selection contains the given color. False otherwise.</returns>
        public bool HasStyle(int start, int length, Color color) => HasStyle(start, length, SelectionColor, color);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontStyle"></param>
        /// <returns>True if any character in the selection contains the given font style. False otherwise.</returns>
        public bool HasStyle(int start, int length, FontStyle fontStyle) 
            => HasStyle(start, length, SelectionFont.Style, fontStyle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="textStyle"></param>
        /// <returns>True if any character in the selection contains the text style. False otherwise.</returns>
        public bool HasStyle(int start, int length, TextStyle textStyle)
            => HasStyle(start, length, new TextStyle { Color = SelectionColor, FontStyle = SelectionFont.Style }, textStyle);

        /// <summary>
        /// A convenient simplified definition for public HasStyle methods, containing reused code.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selection"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool HasStyle<T>(T selection, T source)
        {
            int s = SelectionStart, l = SelectionLength;
            for (int j = 0; j < l; j++)
            {
                Select(s + j, s + j + 1);
                if (selection.Equals(source)) return true;
            }
            return false;
        }

        private bool HasStyle<T>(int start, int length, T selection, T source)
        {
            int s = SelectionStart, l = SelectionLength;
            Select(start, length); bool hasStyle = HasStyle(selection, source);
            Select(s, l);

            return hasStyle;
        }

        /// <summary>
        /// Ensures that the text at the end of a styling returns to default rather than continuing to style additional new text.
        /// </summary>
        /// <param name="end"></param>
        private void SelectionOnly(bool selectionOnly) 
        { 
            if (selectionOnly) ClearStyles(SelectionStart + SelectionLength, 0); 
        }

        /// <summary>
        /// Removes all styles for the selected text.
        /// </summary>
        public void ClearStyles()
        {
            SelectionColor = ForeColor; SelectionFont = new Font(SelectionFont, FontStyle.Regular);
        }

        /// <summary>
        /// Removes all styles from the text in the provided index range.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void ClearStyles(int start, int end)
        {
            int s = SelectionStart, l = SelectionLength;
            Select(start, end); ClearStyles(); Select(s, l);
        }

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
        /// Applies the color to the current selection. Set selectionOnly to true if the style should not be applied to oncoming new text.
        /// </summary>
        /// <remarks>This is more efficient than defining a text style and applying it as it applies the color directly.</remarks>
        /// <param name="color"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyStyle(Color color, bool selectionOnly = false)
        {
            SelectionColor = color;
            SelectionOnly(selectionOnly);
        }

        /// <summary>
        /// Applies the font style to the current selection. 
        /// </summary>
        /// <remarks>This is slightly more efficient than defining a text style and applying it, as it applies the font style directly.</remarks>
        /// <param name="fontStyle"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyStyle(FontStyle fontStyle, bool selectionOnly = false)
        {
            Font font = SelectionFont;
            SelectionFont = new Font(font, font.Style | fontStyle);
            SelectionOnly(selectionOnly);
        }

        /// <summary>
        /// Applies the given color and style to the text.
        /// </summary>
        /// <remarks>This does not create a new text style.</remarks>
        /// <param name="color"></param>
        /// <param name="fontStyle"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyStyle(Color color, FontStyle fontStyle, bool selectionOnly = false)
        {
            SelectionColor = color;
            Font ft = SelectionFont;
            SelectionFont = new Font(ft, fontStyle);
            SelectionOnly(selectionOnly);
        }

        /// <summary>
        /// Styles the characters in the selection with the given style.
        /// </summary>
        /// <param name="style"></param>
        public void ApplyStyle(TextStyle style, bool selectionOnly = false)
        {
            SelectionColor = style.Color; 
            SelectionFont = new Font(SelectionFont, style.FontStyle);
            SelectionOnly(selectionOnly);
        }

        /// <summary>
        /// Applies the given color to the selected text. 
        /// </summary>
        /// <remarks>If selection length is 0, then the whole word containing the caret position is colored.</remarks>
        public void StyleSelection(Color color, bool selectionOnly = false)
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

        /// <summary>
        /// Removes the color of the selection and changes it to the the ForeColor value.
        /// </summary>
        /// <typeparam name="Color"></typeparam>
        public void RemoveStyle<Color>() => ApplyStyle(ForeColor);

        /// <summary>
        /// Removes the given font style of the selection.
        /// </summary>
        /// <param name="fontStyle"></param>
        public void RemoveStyle(FontStyle fontStyle) => ApplyStyle(SelectionFont.Style & ~fontStyle);

        /// <summary>
        /// Removes the provided color and font style from the selection.
        /// </summary>
        /// <param name="textStyle"></param>
        public void RemoveStyle(TextStyle textStyle) => ApplyStyle(ForeColor, SelectionFont.Style & ~textStyle.FontStyle);

        /// <summary>
        /// Swaps the font style from its current value.
        /// </summary>
        /// <param name="fontStyle"></param>
        /// <param name="selectionOnly"></param>
        public void SwapStyle(FontStyle fontStyle, bool selectionOnly=false) => ApplyStyle(SelectionFont.Style ^ fontStyle, selectionOnly);

        /// <summary>
        /// Swaps the font style from its current value.
        /// </summary>
        /// <param name="textStyle"></param>
        /// <param name="selectionOnly"></param>
        public void SwapStyle(TextStyle textStyle, bool selectionOnly = false) => ApplyStyle(SelectionFont.Style ^ textStyle.FontStyle, selectionOnly);

        /// <summary>
        /// Applies the action to the character preceding the selection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyToLastChar<T>(Action<T,bool> action, T newValue, bool selectionOnly = false)
        {
            int s = SelectionStart, l = SelectionLength;
            if (s == 0) return;
            Select(s-1, s); action(newValue,selectionOnly); Select(s, l);
        }

        /// <summary>
        /// Applies the action to the character following the selection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyToNextChar<T>(Action<T, bool> action, T newValue, bool selectionOnly = false)
        {
            int s = SelectionStart, l = SelectionLength;
            if (s + l == Text.Length) return;
            Select(s + l, s + l + 1); action(newValue,selectionOnly); Select(s, l);
        }

        /// <summary>
        /// Applies the given actiontion to the provided index range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyToSubstring<T>(int start, int length, Action<T, bool> action, T newValue, bool selectionOnly = false)
        {
            int s = SelectionStart, l = SelectionLength;
            Select(start, length); action(newValue,selectionOnly); Select(s, l);
        }

        /// <summary>
        /// Applies the action to the match.
        /// </summary>
        /// <remarks>This method will not test to see if the match apply to the text.</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyToMatch<T>(Match match, Action<T, bool> action, T newValue, bool selectionOnly = false) 
            => ApplyToSubstring(match.Index, match.Length, action, newValue, selectionOnly);

        /// <summary>
        /// Applies the action to the first match.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pattern"></param>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        /// <returns>The first match that matches the pattern.</returns>
        public Match ApplyToMatch<T>(string pattern, Action<T, bool> action, T newValue, bool selectionOnly = false)
        {
            Match match = Regex.Match(Text, pattern);
            ApplyToSubstring(match.Index, match.Length, action, newValue, selectionOnly);
            return match;
        }

        /// <summary>
        /// Applies the action to all the matches in the list.
        /// </summary>
        /// <remarks>This method will not test to see if the matches apply to the text.</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="matches"></param>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        public void ApplyToMatches<T>(MatchCollection matches, Action<T, bool> action, T newValue, bool selectionOnly = false)
        {
            int s = SelectionStart, l = SelectionLength;

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                Select(match.Index, match.Length);
                action(newValue, selectionOnly);
            }

            Select(s, l);
        }

        /// <summary>
        /// Applies the action to all matches with the given pattern.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pattern"></param>
        /// <param name="action"></param>
        /// <param name="newValue"></param>
        /// <param name="selectionOnly"></param>
        /// <returns>The collection of matches representing the pattern.</returns>
        public MatchCollection ApplyToMatches<T>(string pattern, Action<T, bool> action, T newValue, bool selectionOnly = false)
        {
            MatchCollection matches = Regex.Matches(Text, pattern);
            ApplyToMatches(matches, action, newValue, selectionOnly);
            return matches;
        }
    }

    public class TextStyle : IEquatable<TextStyle>
    {
        public Color Color { get; set; }
        public FontStyle FontStyle { get; set; }

        public static bool operator !=(TextStyle textStyle1, TextStyle textStyle2) => !(textStyle1 == textStyle2);

        public static bool operator ==(TextStyle textStyle1, TextStyle textStyle2)
        {
            if (textStyle1.Color != textStyle2.Color) return false;
            if (textStyle1.FontStyle != textStyle2.FontStyle) return false;

            return true;
        }

        public override bool Equals(object obj) => this == (TextStyle)obj;

        public override int GetHashCode() => Color.ToArgb() * FontStyle.GetHashCode();

        public override string ToString() => $"TextStyle({Color}, {FontStyle})";

        public bool Equals(TextStyle other) => this == other;
    }
}
