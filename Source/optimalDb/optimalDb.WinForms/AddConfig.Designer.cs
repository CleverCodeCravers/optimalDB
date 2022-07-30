namespace optimalDb.WinForms
{
    partial class AddConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.databaseTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.SaveConfigButtoon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Name";
            // 
            // databaseTextBox
            // 
            this.databaseTextBox.Location = new System.Drawing.Point(144, 62);
            this.databaseTextBox.Name = "databaseTextBox";
            this.databaseTextBox.Size = new System.Drawing.Size(117, 23);
            this.databaseTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database URL";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(144, 108);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(272, 23);
            this.URLTextBox.TabIndex = 3;
            // 
            // SaveConfigButtoon
            // 
            this.SaveConfigButtoon.Location = new System.Drawing.Point(341, 166);
            this.SaveConfigButtoon.Name = "SaveConfigButtoon";
            this.SaveConfigButtoon.Size = new System.Drawing.Size(75, 23);
            this.SaveConfigButtoon.TabIndex = 4;
            this.SaveConfigButtoon.Text = "Save";
            this.SaveConfigButtoon.UseVisualStyleBackColor = true;
            this.SaveConfigButtoon.Click += new System.EventHandler(this.SaveConfigButtoon_Click);
            // 
            // AddConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 201);
            this.Controls.Add(this.SaveConfigButtoon);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.databaseTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox databaseTextBox;
        private Label label2;
        private TextBox URLTextBox;
        private Button SaveConfigButtoon;
    }
}