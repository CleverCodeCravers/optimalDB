namespace optimalDb.WinForms
{
    partial class DatabaseBrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseBrowserForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoDatabaseObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.connectionStringListbox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DatabasesListbox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DatabaseObjectsTreeView = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ObjectsLabel = new System.Windows.Forms.Label();
            this.CodeTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextbox)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.gotoDatabaseObjectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1167, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigurationToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.loadConfigurationToolStripMenuItem_Click);
            // 
            // gotoDatabaseObjectToolStripMenuItem
            // 
            this.gotoDatabaseObjectToolStripMenuItem.Name = "gotoDatabaseObjectToolStripMenuItem";
            this.gotoDatabaseObjectToolStripMenuItem.ShortcutKeyDisplayString = "Strg+T";
            this.gotoDatabaseObjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.gotoDatabaseObjectToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.gotoDatabaseObjectToolStripMenuItem.Text = "Goto Database-Object (Ctrl + T)";
            this.gotoDatabaseObjectToolStripMenuItem.Click += new System.EventHandler(this.gotoDatabaseObjectToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.connectionStringListbox);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1167, 552);
            this.splitContainer1.SplitterDistance = 152;
            this.splitContainer1.TabIndex = 1;
            // 
            // connectionStringListbox
            // 
            this.connectionStringListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionStringListbox.FormattingEnabled = true;
            this.connectionStringListbox.ItemHeight = 15;
            this.connectionStringListbox.Location = new System.Drawing.Point(0, 23);
            this.connectionStringListbox.Name = "connectionStringListbox";
            this.connectionStringListbox.Size = new System.Drawing.Size(152, 529);
            this.connectionStringListbox.TabIndex = 1;
            this.connectionStringListbox.SelectedIndexChanged += new System.EventHandler(this.connectionStringListbox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 23);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connections";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DatabasesListbox);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1011, 552);
            this.splitContainer2.SplitterDistance = 195;
            this.splitContainer2.TabIndex = 0;
            // 
            // DatabasesListbox
            // 
            this.DatabasesListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabasesListbox.FormattingEnabled = true;
            this.DatabasesListbox.ItemHeight = 15;
            this.DatabasesListbox.Location = new System.Drawing.Point(0, 23);
            this.DatabasesListbox.Name = "DatabasesListbox";
            this.DatabasesListbox.Size = new System.Drawing.Size(195, 529);
            this.DatabasesListbox.TabIndex = 2;
            this.DatabasesListbox.SelectedIndexChanged += new System.EventHandler(this.DatabasesListbox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 23);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Databases";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DatabaseObjectsTreeView);
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.CodeTextbox);
            this.splitContainer3.Panel2.Controls.Add(this.panel4);
            this.splitContainer3.Size = new System.Drawing.Size(812, 552);
            this.splitContainer3.SplitterDistance = 262;
            this.splitContainer3.TabIndex = 0;
            // 
            // DatabaseObjectsTreeView
            // 
            this.DatabaseObjectsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseObjectsTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.DatabaseObjectsTreeView.FullRowSelect = true;
            this.DatabaseObjectsTreeView.HideSelection = false;
            this.DatabaseObjectsTreeView.Location = new System.Drawing.Point(0, 23);
            this.DatabaseObjectsTreeView.Name = "DatabaseObjectsTreeView";
            this.DatabaseObjectsTreeView.Size = new System.Drawing.Size(262, 529);
            this.DatabaseObjectsTreeView.TabIndex = 3;
            this.DatabaseObjectsTreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.DatabaseObjectsTreeView_DrawNode);
            this.DatabaseObjectsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DatabaseObjectsTreeView_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.ObjectsLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 23);
            this.panel3.TabIndex = 2;
            // 
            // ObjectsLabel
            // 
            this.ObjectsLabel.AutoSize = true;
            this.ObjectsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ObjectsLabel.Location = new System.Drawing.Point(3, 4);
            this.ObjectsLabel.Name = "ObjectsLabel";
            this.ObjectsLabel.Size = new System.Drawing.Size(103, 15);
            this.ObjectsLabel.TabIndex = 0;
            this.ObjectsLabel.Text = "Database Objects";
            // 
            // CodeTextbox
            // 
            this.CodeTextbox.AutoCompleteBracketsList = new char[] {
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
            this.CodeTextbox.AutoIndentCharsPatterns = "";
            this.CodeTextbox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.CodeTextbox.BackBrush = null;
            this.CodeTextbox.CharHeight = 14;
            this.CodeTextbox.CharWidth = 8;
            this.CodeTextbox.CommentPrefix = "--";
            this.CodeTextbox.DefaultMarkerSize = 8;
            this.CodeTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CodeTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeTextbox.FindForm = null;
            this.CodeTextbox.GoToForm = null;
            this.CodeTextbox.Hotkeys = resources.GetString("CodeTextbox.Hotkeys");
            this.CodeTextbox.IsReplaceMode = false;
            this.CodeTextbox.Language = FastColoredTextBoxNS.Text.Language.SQL;
            this.CodeTextbox.LeftBracket = '(';
            this.CodeTextbox.Location = new System.Drawing.Point(0, 23);
            this.CodeTextbox.Name = "CodeTextbox";
            this.CodeTextbox.Paddings = new System.Windows.Forms.Padding(0);
            this.CodeTextbox.ReplaceForm = null;
            this.CodeTextbox.RightBracket = ')';
            this.CodeTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.CodeTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeTextbox.ServiceColors")));
            this.CodeTextbox.Size = new System.Drawing.Size(546, 529);
            this.CodeTextbox.TabIndex = 0;
            this.CodeTextbox.Zoom = 100;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(546, 23);
            this.panel4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Code";
            // 
            // DatabaseBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 576);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DatabaseBrowserForm";
            this.Text = "DatabaseBrowserForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextbox)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Label label1;
        private SplitContainer splitContainer2;
        private Panel panel2;
        private Label label2;
        private SplitContainer splitContainer3;
        private Panel panel3;
        private Label ObjectsLabel;
        private ListBox connectionStringListbox;
        private ListBox DatabasesListbox;
        private TreeView DatabaseObjectsTreeView;
        private Panel panel4;
        private Label label3;
        private FastColoredTextBoxNS.FastColoredTextBox CodeTextbox;
        private ToolStripMenuItem gotoDatabaseObjectToolStripMenuItem;
    }
}