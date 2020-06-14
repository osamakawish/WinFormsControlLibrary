namespace TextBoxes
{
    partial class FancyTextBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RichTextBox
            // 
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(800, 450);
            this.RichTextBox.TabIndex = 0;
            this.RichTextBox.Text = "";
            this.RichTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichTextBox_KeyPress);
            this.RichTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichTextBox_KeyUp);
            // 
            // FancyTextBox
            // 
            this.Controls.Add(this.RichTextBox);
            this.Name = "FancyTextBox";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBox;
    }
}
