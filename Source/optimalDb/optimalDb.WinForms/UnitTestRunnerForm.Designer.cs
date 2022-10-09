namespace optimalDb.WinForms
{
    partial class UnitTestRunnerForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.unitTestListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runAllTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.UnitTestResultListView = new System.Windows.Forms.ListView();
            this.Test = new System.Windows.Forms.ColumnHeader();
            this.IsSuccess = new System.Windows.Forms.ColumnHeader();
            this.Message = new System.Windows.Forms.ColumnHeader();
            this.ResultTableDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.unitTestListBox);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(981, 575);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // unitTestListBox
            // 
            this.unitTestListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitTestListBox.FormattingEnabled = true;
            this.unitTestListBox.ItemHeight = 15;
            this.unitTestListBox.Location = new System.Drawing.Point(0, 24);
            this.unitTestListBox.Name = "unitTestListBox";
            this.unitTestListBox.Size = new System.Drawing.Size(380, 551);
            this.unitTestListBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runAllTestsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(380, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runAllTestsToolStripMenuItem
            // 
            this.runAllTestsToolStripMenuItem.Name = "runAllTestsToolStripMenuItem";
            this.runAllTestsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.runAllTestsToolStripMenuItem.Text = "Run All Tests";
            this.runAllTestsToolStripMenuItem.Click += new System.EventHandler(this.runAllTestsToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.UnitTestResultListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ResultTableDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(597, 575);
            this.splitContainer2.SplitterDistance = 199;
            this.splitContainer2.TabIndex = 1;
            // 
            // UnitTestResultListView
            // 
            this.UnitTestResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Test,
            this.IsSuccess,
            this.Message});
            this.UnitTestResultListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnitTestResultListView.FullRowSelect = true;
            this.UnitTestResultListView.GridLines = true;
            this.UnitTestResultListView.Location = new System.Drawing.Point(0, 0);
            this.UnitTestResultListView.Name = "UnitTestResultListView";
            this.UnitTestResultListView.Size = new System.Drawing.Size(597, 199);
            this.UnitTestResultListView.TabIndex = 0;
            this.UnitTestResultListView.UseCompatibleStateImageBehavior = false;
            this.UnitTestResultListView.View = System.Windows.Forms.View.Details;
            this.UnitTestResultListView.SelectedIndexChanged += new System.EventHandler(this.UnitTestResultListView_SelectedIndexChanged);
            // 
            // Test
            // 
            this.Test.Text = "Test";
            this.Test.Width = 120;
            // 
            // IsSuccess
            // 
            this.IsSuccess.Text = "IsSuccess";
            this.IsSuccess.Width = 70;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 403;
            // 
            // ResultTableDataGridView
            // 
            this.ResultTableDataGridView.AllowUserToAddRows = false;
            this.ResultTableDataGridView.AllowUserToDeleteRows = false;
            this.ResultTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultTableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ResultTableDataGridView.Name = "ResultTableDataGridView";
            this.ResultTableDataGridView.ReadOnly = true;
            this.ResultTableDataGridView.RowTemplate.Height = 25;
            this.ResultTableDataGridView.Size = new System.Drawing.Size(597, 372);
            this.ResultTableDataGridView.TabIndex = 0;
            // 
            // UnitTestRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 575);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UnitTestRunnerForm";
            this.Text = "UnitTestRunnerForm";
            this.Load += new System.EventHandler(this.UnitTestRunnerForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultTableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox unitTestListBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem runAllTestsToolStripMenuItem;
        private ListView UnitTestResultListView;
        private ColumnHeader Test;
        private ColumnHeader IsSuccess;
        private ColumnHeader Message;
        private SplitContainer splitContainer2;
        private DataGridView ResultTableDataGridView;
    }
}