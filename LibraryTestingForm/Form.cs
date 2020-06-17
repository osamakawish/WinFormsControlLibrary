using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBoxes;

namespace LibraryTestingForm
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();

            VividTextBox.Text = 
                "The celebrities of the Human World of their life stories we know\n" +
                "But the legends they come and the legends they go\n" +
                "People die and babies are born every day\n" +
                "And the Reaper on all lives has the final say\n" +
                "Except for the troubled individuals who for whatever reason decide\n" +
                "For to end their existence in the act of suicide\n" +
                "'Tis a fact of life and facts do never lie\n" +
                "That what is born to life must eventually die\n" +
                "Many feel I look at life in a negative way\n" +
                "But that is their opinion and with me that is okay\n" +
                "On what I say on many things many may disagree\n" +
                "But we all are very different and we see things differently\n" +
                "But the one who makes all equal on us has the final call\n" +
                "To the scythe of the Grim Reaper we eventually must fall.\n";

            TestVividTextBox();

            
        }

        private void TestVividTextBox()
        {
            VividTextBox.ApplyToSubstring(4, 24, VividTextBox.ApplyStyle, Color.Red);
        }

        private void BoldButton_Click(object sender, EventArgs e)
        {
            VividTextBox.Focus();
            VividTextBox.SwapStyle(FontStyle.Bold);
        }

        private void ItalicsButton_Click(object sender, EventArgs e)
        {
            VividTextBox.Focus();
            VividTextBox.SwapStyle(FontStyle.Italic);
        }
    }
}
