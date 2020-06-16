using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private void BoldButton_Click(object sender, EventArgs e)
        {
            VividTextBox.ApplyStyle(FontStyle.Bold);
        }
    }
}
