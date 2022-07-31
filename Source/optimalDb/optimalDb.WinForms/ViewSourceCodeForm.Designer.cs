namespace optimalDb.WinForms
{
    partial class ViewSourceCodeForm
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
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.ViewSourcePanel = new System.Windows.Forms.Panel();
            this.ViewSourceCloseButton = new System.Windows.Forms.Button();
            this.ViewSourcePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceTextBox.Location = new System.Drawing.Point(0, 0);
            this.SourceTextBox.Multiline = true;
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SourceTextBox.Size = new System.Drawing.Size(514, 311);
            this.SourceTextBox.TabIndex = 0;
            this.SourceTextBox.Text = "test";
            this.SourceTextBox.WordWrap = false;
            // 
            // ViewSourcePanel
            // 
            this.ViewSourcePanel.Controls.Add(this.ViewSourceCloseButton);
            this.ViewSourcePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ViewSourcePanel.Location = new System.Drawing.Point(0, 311);
            this.ViewSourcePanel.Name = "ViewSourcePanel";
            this.ViewSourcePanel.Size = new System.Drawing.Size(514, 48);
            this.ViewSourcePanel.TabIndex = 1;
            // 
            // ViewSourceCloseButton
            // 
            this.ViewSourceCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewSourceCloseButton.Location = new System.Drawing.Point(427, 13);
            this.ViewSourceCloseButton.Name = "ViewSourceCloseButton";
            this.ViewSourceCloseButton.Size = new System.Drawing.Size(75, 23);
            this.ViewSourceCloseButton.TabIndex = 0;
            this.ViewSourceCloseButton.Text = "Close";
            this.ViewSourceCloseButton.UseVisualStyleBackColor = true;
            // 
            // ViewSourceCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 359);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.ViewSourcePanel);
            this.Name = "ViewSourceCodeForm";
            this.Text = "Kaputt SQL Code";
            this.Load += new System.EventHandler(this.ViewSourceCodeForm_Load);
            this.ViewSourcePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SourceTextBox;
        private Panel ViewSourcePanel;
        private Button ViewSourceCloseButton;
    }
}