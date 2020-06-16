namespace LibraryTestingForm
{
    partial class Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VividTextBox = new TextBoxes.VividTextBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.BoldButton = new System.Windows.Forms.Button();
            this.ItalicsButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VividTextBox
            // 
            this.VividTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VividTextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VividTextBox.Location = new System.Drawing.Point(0, 0);
            this.VividTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VividTextBox.Name = "VividTextBox";
            this.VividTextBox.Size = new System.Drawing.Size(1067, 554);
            this.VividTextBox.TabIndex = 0;
            this.VividTextBox.Text = "";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.ColorButton);
            this.ButtonPanel.Controls.Add(this.ItalicsButton);
            this.ButtonPanel.Controls.Add(this.BoldButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 516);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1067, 38);
            this.ButtonPanel.TabIndex = 1;
            // 
            // BoldButton
            // 
            this.BoldButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.BoldButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoldButton.Location = new System.Drawing.Point(0, 0);
            this.BoldButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BoldButton.Name = "BoldButton";
            this.BoldButton.Size = new System.Drawing.Size(148, 38);
            this.BoldButton.TabIndex = 1;
            this.BoldButton.Text = "Bold";
            this.BoldButton.UseVisualStyleBackColor = true;
            this.BoldButton.Click += new System.EventHandler(this.BoldButton_Click);
            // 
            // ItalicsButton
            // 
            this.ItalicsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ItalicsButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItalicsButton.Location = new System.Drawing.Point(148, 0);
            this.ItalicsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ItalicsButton.Name = "ItalicsButton";
            this.ItalicsButton.Size = new System.Drawing.Size(148, 38);
            this.ItalicsButton.TabIndex = 2;
            this.ItalicsButton.Text = "Italics";
            this.ItalicsButton.UseVisualStyleBackColor = true;
            this.ItalicsButton.Click += new System.EventHandler(this.ItalicsButton_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ColorButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorButton.Location = new System.Drawing.Point(919, 0);
            this.ColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(148, 38);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.Text = "Color";
            this.ColorButton.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.VividTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form";
            this.Text = "Form";
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxes.VividTextBox VividTextBox;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button BoldButton;
        private System.Windows.Forms.Button ItalicsButton;
        private System.Windows.Forms.Button ColorButton;
    }
}

