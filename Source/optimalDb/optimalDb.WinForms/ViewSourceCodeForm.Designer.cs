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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSourceCodeForm));
            this.ViewSourcePanel = new System.Windows.Forms.Panel();
            this.ViewSourceCloseButton = new System.Windows.Forms.Button();
            this.SourceTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ViewSourcePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceTextBox)).BeginInit();
            this.SuspendLayout();
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
            // SourceTextBox
            // 
            this.SourceTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.SourceTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.SourceTextBox.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.SourceTextBox.BackBrush = null;
            this.SourceTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.SourceTextBox.CharHeight = 14;
            this.SourceTextBox.CharWidth = 8;
            this.SourceTextBox.DefaultMarkerSize = 8;
            this.SourceTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceTextBox.FindForm = null;
            this.SourceTextBox.GoToForm = null;
            this.SourceTextBox.Hotkeys = resources.GetString("SourceTextBox.Hotkeys");
            this.SourceTextBox.IsReplaceMode = false;
            this.SourceTextBox.Language = FastColoredTextBoxNS.Text.Language.SQL;
            this.SourceTextBox.LeftBracket = '(';
            this.SourceTextBox.LeftBracket2 = '{';
            this.SourceTextBox.Location = new System.Drawing.Point(0, 0);
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.SourceTextBox.ReadOnly = true;
            this.SourceTextBox.ReplaceForm = null;
            this.SourceTextBox.RightBracket = ')';
            this.SourceTextBox.RightBracket2 = '}';
            this.SourceTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.SourceTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("SourceTextBox.ServiceColors")));
            this.SourceTextBox.Size = new System.Drawing.Size(514, 311);
            this.SourceTextBox.SourceTextBox = this.SourceTextBox;
            this.SourceTextBox.TabIndex = 2;
            this.SourceTextBox.Text = "fastColoredTextBox1";
            this.SourceTextBox.Zoom = 100;
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
            ((System.ComponentModel.ISupportInitialize)(this.SourceTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel ViewSourcePanel;
        private Button ViewSourceCloseButton;
        private FastColoredTextBoxNS.FastColoredTextBox SourceTextBox;
    }
}