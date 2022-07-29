namespace optimalDb.WinForms
{
    partial class EditConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfigForm));
            this.configList = new System.Windows.Forms.ListView();
            this.DatabaseName = new System.Windows.Forms.ColumnHeader();
            this.ConnectionString = new System.Windows.Forms.ColumnHeader();
            this.DeleteConfigButtoon = new System.Windows.Forms.Button();
            this.AddConfigButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // configList
            // 
            this.configList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DatabaseName,
            this.ConnectionString});
            this.configList.Dock = System.Windows.Forms.DockStyle.Top;
            this.configList.GridLines = true;
            this.configList.Location = new System.Drawing.Point(0, 0);
            this.configList.Name = "configList";
            this.configList.Size = new System.Drawing.Size(674, 313);
            this.configList.TabIndex = 0;
            this.configList.UseCompatibleStateImageBehavior = false;
            this.configList.View = System.Windows.Forms.View.Details;
            // 
            // DatabaseName
            // 
            this.DatabaseName.Text = "Name";
            this.DatabaseName.Width = 150;
            // 
            // ConnectionString
            // 
            this.ConnectionString.Text = "URL";
            this.ConnectionString.Width = 520;
            // 
            // DeleteConfigButtoon
            // 
            this.DeleteConfigButtoon.Location = new System.Drawing.Point(587, 326);
            this.DeleteConfigButtoon.Name = "DeleteConfigButtoon";
            this.DeleteConfigButtoon.Size = new System.Drawing.Size(75, 23);
            this.DeleteConfigButtoon.TabIndex = 1;
            this.DeleteConfigButtoon.Text = "Delete";
            this.DeleteConfigButtoon.UseVisualStyleBackColor = true;
            // 
            // AddConfigButton
            // 
            this.AddConfigButton.Location = new System.Drawing.Point(12, 326);
            this.AddConfigButton.Name = "AddConfigButton";
            this.AddConfigButton.Size = new System.Drawing.Size(75, 23);
            this.AddConfigButton.TabIndex = 2;
            this.AddConfigButton.Text = "Add";
            this.AddConfigButton.UseVisualStyleBackColor = true;
            this.AddConfigButton.Click += new System.EventHandler(this.AddConfigButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(485, 326);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Ok";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // EditConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 361);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddConfigButton);
            this.Controls.Add(this.DeleteConfigButtoon);
            this.Controls.Add(this.configList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditConfigForm";
            this.Text = "Edit Config";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView configList;
        private Button DeleteConfigButtoon;
        private Button AddConfigButton;
        private Button SaveButton;
        private ColumnHeader DatabaseName;
        private ColumnHeader ConnectionString;
    }
}