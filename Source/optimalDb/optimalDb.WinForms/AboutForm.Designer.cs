﻿namespace optimalDb.WinForms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.appNameLabel = new System.Windows.Forms.Label();
            this.appPage = new System.Windows.Forms.Label();
            this.appGithubPage = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appNameLabel
            // 
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appNameLabel.Location = new System.Drawing.Point(87, 35);
            this.appNameLabel.MaximumSize = new System.Drawing.Size(0, 60);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(129, 21);
            this.appNameLabel.TabIndex = 1;
            this.appNameLabel.Text = "nameAndVersion";
            this.appNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // appPage
            // 
            this.appPage.AutoSize = true;
            this.appPage.Location = new System.Drawing.Point(68, 85);
            this.appPage.Name = "appPage";
            this.appPage.Size = new System.Drawing.Size(139, 15);
            this.appPage.TabIndex = 2;
            this.appPage.Text = "Visit OptimalDb Page on ";
            // 
            // appGithubPage
            // 
            this.appGithubPage.AutoSize = true;
            this.appGithubPage.Location = new System.Drawing.Point(204, 85);
            this.appGithubPage.Name = "appGithubPage";
            this.appGithubPage.Size = new System.Drawing.Size(43, 15);
            this.appGithubPage.TabIndex = 3;
            this.appGithubPage.TabStop = true;
            this.appGithubPage.Text = "Github";
            this.appGithubPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.appGithubPage_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "May the code be with you!";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(111, 172);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 216);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appGithubPage);
            this.Controls.Add(this.appPage);
            this.Controls.Add(this.appNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label appNameLabel;
        private Label appPage;
        private LinkLabel appGithubPage;
        private Label label1;
        private Button closeButton;
    }
}