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
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VividTextBox
            // 
            this.VividTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VividTextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VividTextBox.Location = new System.Drawing.Point(0, 0);
            this.VividTextBox.Name = "VividTextBox";
            this.VividTextBox.Size = new System.Drawing.Size(800, 450);
            this.VividTextBox.TabIndex = 0;
            this.VividTextBox.Text = "";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.BoldButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 419);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(800, 31);
            this.ButtonPanel.TabIndex = 1;
            // 
            // BoldButton
            // 
            this.BoldButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.BoldButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoldButton.Location = new System.Drawing.Point(0, 0);
            this.BoldButton.Name = "BoldButton";
            this.BoldButton.Size = new System.Drawing.Size(111, 31);
            this.BoldButton.TabIndex = 0;
            this.BoldButton.Text = "Bold";
            this.BoldButton.UseVisualStyleBackColor = true;
            this.BoldButton.Click += new System.EventHandler(this.BoldButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.VividTextBox);
            this.Name = "Form";
            this.Text = "Form";
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxes.VividTextBox VividTextBox;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button BoldButton;
    }
}

