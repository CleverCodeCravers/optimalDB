namespace optimalDb.WinForms
{
    partial class ConfigListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigListForm));
            this.configListView = new System.Windows.Forms.ListView();
            this.DatabaseName = new System.Windows.Forms.ColumnHeader();
            this.ConnectionString = new System.Windows.Forms.ColumnHeader();
            this.DeleteConfigButtoon = new System.Windows.Forms.Button();
            this.AddConfigButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // configListView
            // 
            this.configListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DatabaseName,
            this.ConnectionString});
            this.configListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.configListView.FullRowSelect = true;
            this.configListView.GridLines = true;
            this.configListView.Location = new System.Drawing.Point(0, 0);
            this.configListView.Name = "configListView";
            this.configListView.Size = new System.Drawing.Size(674, 313);
            this.configListView.TabIndex = 0;
            this.configListView.UseCompatibleStateImageBehavior = false;
            this.configListView.View = System.Windows.Forms.View.Details;
            // 
            // DatabaseName
            // 
            this.DatabaseName.Text = "Name";
            this.DatabaseName.Width = 150;
            // 
            // ConnectionString
            // 
            this.ConnectionString.Text = "Connection String";
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
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ConfigListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 361);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddConfigButton);
            this.Controls.Add(this.DeleteConfigButtoon);
            this.Controls.Add(this.configListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigListForm";
            this.Text = "Edit Config";
            this.Load += new System.EventHandler(this.EditConfigForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView configListView;
        private Button DeleteConfigButtoon;
        private Button AddConfigButton;
        private Button SaveButton;
        private ColumnHeader DatabaseName;
        private ColumnHeader ConnectionString;
    }
}