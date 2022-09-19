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
            this.selectScriptFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoDatabaseObjectCtrlTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.performanceOptimizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findProblematicSqlObjectsInTheDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseTableSizesAndSpaceTendenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseAndOptimizeIndexesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findProblemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCodeThatSpansMultipleDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ConnectionsListbox = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ConnectionsSearchTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateConnectionsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DatabasesListbox = new System.Windows.Forms.ListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DatabasesSearchTextbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UpdateDatabasesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DatabaseObjectsListBox = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DatabaseObjectsSearchTextbox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UpdateDatabaseObjectsButton = new System.Windows.Forms.Button();
            this.ObjectsLabel = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.codeActionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.CodeTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.AutoClipboardCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextbox)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.navigateToolStripMenuItem,
            this.scriptsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1187, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigurationToolStripMenuItem,
            this.selectScriptFolderToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.loadConfigurationToolStripMenuItem_Click);
            // 
            // selectScriptFolderToolStripMenuItem
            // 
            this.selectScriptFolderToolStripMenuItem.Name = "selectScriptFolderToolStripMenuItem";
            this.selectScriptFolderToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.selectScriptFolderToolStripMenuItem.Text = "Select Script Folder...";
            this.selectScriptFolderToolStripMenuItem.Click += new System.EventHandler(this.selectScriptFolderToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // navigateToolStripMenuItem
            // 
            this.navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoDatabaseObjectCtrlTToolStripMenuItem});
            this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            this.navigateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.navigateToolStripMenuItem.Text = "Navigate";
            // 
            // gotoDatabaseObjectCtrlTToolStripMenuItem
            // 
            this.gotoDatabaseObjectCtrlTToolStripMenuItem.Name = "gotoDatabaseObjectCtrlTToolStripMenuItem";
            this.gotoDatabaseObjectCtrlTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.gotoDatabaseObjectCtrlTToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.gotoDatabaseObjectCtrlTToolStripMenuItem.Text = "Goto Database-Object (Ctrl + T)";
            this.gotoDatabaseObjectCtrlTToolStripMenuItem.Click += new System.EventHandler(this.gotoDatabaseObjectToolStripMenuItem_Click);
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem,
            this.toolStripMenuItem1,
            this.performanceOptimizationToolStripMenuItem,
            this.findProblemsToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.scriptsToolStripMenuItem.Text = "Tools";
            // 
            // executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem
            // 
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Name = "executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem";
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Text = "Execute Script on Selected Database Object...";
            this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Click += new System.EventHandler(this.executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(349, 6);
            // 
            // performanceOptimizationToolStripMenuItem
            // 
            this.performanceOptimizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findProblematicSqlObjectsInTheDatabaseToolStripMenuItem,
            this.startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem,
            this.analyseTableSizesAndSpaceTendenciesToolStripMenuItem,
            this.analyseAndOptimizeIndexesToolStripMenuItem});
            this.performanceOptimizationToolStripMenuItem.Name = "performanceOptimizationToolStripMenuItem";
            this.performanceOptimizationToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.performanceOptimizationToolStripMenuItem.Text = "Optimize Performance";
            this.performanceOptimizationToolStripMenuItem.Click += new System.EventHandler(this.performanceOptimizationToolStripMenuItem_Click);
            // 
            // findProblematicSqlObjectsInTheDatabaseToolStripMenuItem
            // 
            this.findProblematicSqlObjectsInTheDatabaseToolStripMenuItem.Name = "findProblematicSqlObjectsInTheDatabaseToolStripMenuItem";
            this.findProblematicSqlObjectsInTheDatabaseToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.findProblematicSqlObjectsInTheDatabaseToolStripMenuItem.Text = "Find problematic Sql Objects in the database";
            // 
            // startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem
            // 
            this.startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem.Name = "startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem";
            this.startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem.Text = "Start performance optimization session on this Sql Object";
            // 
            // analyseTableSizesAndSpaceTendenciesToolStripMenuItem
            // 
            this.analyseTableSizesAndSpaceTendenciesToolStripMenuItem.Name = "analyseTableSizesAndSpaceTendenciesToolStripMenuItem";
            this.analyseTableSizesAndSpaceTendenciesToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.analyseTableSizesAndSpaceTendenciesToolStripMenuItem.Text = "Analyse table sizes and space tendencies";
            // 
            // analyseAndOptimizeIndexesToolStripMenuItem
            // 
            this.analyseAndOptimizeIndexesToolStripMenuItem.Name = "analyseAndOptimizeIndexesToolStripMenuItem";
            this.analyseAndOptimizeIndexesToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.analyseAndOptimizeIndexesToolStripMenuItem.Text = "Analyse and optimize indexes";
            // 
            // findProblemsToolStripMenuItem
            // 
            this.findProblemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findCodeThatSpansMultipleDatabasesToolStripMenuItem});
            this.findProblemsToolStripMenuItem.Name = "findProblemsToolStripMenuItem";
            this.findProblemsToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.findProblemsToolStripMenuItem.Text = "Find Problems";
            // 
            // findCodeThatSpansMultipleDatabasesToolStripMenuItem
            // 
            this.findCodeThatSpansMultipleDatabasesToolStripMenuItem.Name = "findCodeThatSpansMultipleDatabasesToolStripMenuItem";
            this.findCodeThatSpansMultipleDatabasesToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.findCodeThatSpansMultipleDatabasesToolStripMenuItem.Text = "Find code that spans multiple databases";
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
            this.splitContainer1.Panel1.Controls.Add(this.ConnectionsListbox);
            this.splitContainer1.Panel1.Controls.Add(this.panel7);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 601);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.TabIndex = 1;
            // 
            // ConnectionsListbox
            // 
            this.ConnectionsListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectionsListbox.FormattingEnabled = true;
            this.ConnectionsListbox.ItemHeight = 15;
            this.ConnectionsListbox.Location = new System.Drawing.Point(0, 54);
            this.ConnectionsListbox.Name = "ConnectionsListbox";
            this.ConnectionsListbox.Size = new System.Drawing.Size(176, 547);
            this.ConnectionsListbox.TabIndex = 1;
            this.ConnectionsListbox.SelectedIndexChanged += new System.EventHandler(this.connectionStringListbox_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ConnectionsSearchTextbox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 27);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(176, 27);
            this.panel7.TabIndex = 5;
            // 
            // ConnectionsSearchTextbox
            // 
            this.ConnectionsSearchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectionsSearchTextbox.Location = new System.Drawing.Point(0, 0);
            this.ConnectionsSearchTextbox.Name = "ConnectionsSearchTextbox";
            this.ConnectionsSearchTextbox.Size = new System.Drawing.Size(176, 23);
            this.ConnectionsSearchTextbox.TabIndex = 0;
            this.ConnectionsSearchTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionsSearchTextbox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.UpdateConnectionsButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 27);
            this.panel1.TabIndex = 0;
            // 
            // UpdateConnectionsButton
            // 
            this.UpdateConnectionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateConnectionsButton.Location = new System.Drawing.Point(145, 1);
            this.UpdateConnectionsButton.Name = "UpdateConnectionsButton";
            this.UpdateConnectionsButton.Size = new System.Drawing.Size(30, 25);
            this.UpdateConnectionsButton.TabIndex = 2;
            this.UpdateConnectionsButton.UseVisualStyleBackColor = true;
            this.UpdateConnectionsButton.Click += new System.EventHandler(this.UpdateConnectionsButton_Click);
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
            this.splitContainer2.Panel1.Controls.Add(this.panel6);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1007, 601);
            this.splitContainer2.SplitterDistance = 211;
            this.splitContainer2.TabIndex = 0;
            // 
            // DatabasesListbox
            // 
            this.DatabasesListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabasesListbox.FormattingEnabled = true;
            this.DatabasesListbox.ItemHeight = 15;
            this.DatabasesListbox.Location = new System.Drawing.Point(0, 54);
            this.DatabasesListbox.Name = "DatabasesListbox";
            this.DatabasesListbox.Size = new System.Drawing.Size(211, 547);
            this.DatabasesListbox.TabIndex = 2;
            this.DatabasesListbox.SelectedIndexChanged += new System.EventHandler(this.DatabasesListbox_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DatabasesSearchTextbox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(211, 27);
            this.panel6.TabIndex = 5;
            // 
            // DatabasesSearchTextbox
            // 
            this.DatabasesSearchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DatabasesSearchTextbox.Location = new System.Drawing.Point(0, 0);
            this.DatabasesSearchTextbox.Name = "DatabasesSearchTextbox";
            this.DatabasesSearchTextbox.Size = new System.Drawing.Size(211, 23);
            this.DatabasesSearchTextbox.TabIndex = 0;
            this.DatabasesSearchTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabasesSearchTextbox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.UpdateDatabasesButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 27);
            this.panel2.TabIndex = 1;
            // 
            // UpdateDatabasesButton
            // 
            this.UpdateDatabasesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDatabasesButton.Location = new System.Drawing.Point(180, 1);
            this.UpdateDatabasesButton.Name = "UpdateDatabasesButton";
            this.UpdateDatabasesButton.Size = new System.Drawing.Size(30, 25);
            this.UpdateDatabasesButton.TabIndex = 2;
            this.UpdateDatabasesButton.UseVisualStyleBackColor = true;
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
            this.splitContainer3.Panel1.Controls.Add(this.DatabaseObjectsListBox);
            this.splitContainer3.Panel1.Controls.Add(this.panel5);
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Panel2.Controls.Add(this.panel4);
            this.splitContainer3.Size = new System.Drawing.Size(792, 601);
            this.splitContainer3.SplitterDistance = 262;
            this.splitContainer3.TabIndex = 0;
            // 
            // DatabaseObjectsListBox
            // 
            this.DatabaseObjectsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseObjectsListBox.FormattingEnabled = true;
            this.DatabaseObjectsListBox.ItemHeight = 15;
            this.DatabaseObjectsListBox.Location = new System.Drawing.Point(0, 54);
            this.DatabaseObjectsListBox.Name = "DatabaseObjectsListBox";
            this.DatabaseObjectsListBox.Size = new System.Drawing.Size(262, 547);
            this.DatabaseObjectsListBox.TabIndex = 3;
            this.DatabaseObjectsListBox.SelectedIndexChanged += new System.EventHandler(this.DatabaseObjectsListBox_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DatabaseObjectsSearchTextbox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(262, 27);
            this.panel5.TabIndex = 4;
            // 
            // DatabaseObjectsSearchTextbox
            // 
            this.DatabaseObjectsSearchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DatabaseObjectsSearchTextbox.Location = new System.Drawing.Point(0, 0);
            this.DatabaseObjectsSearchTextbox.Name = "DatabaseObjectsSearchTextbox";
            this.DatabaseObjectsSearchTextbox.Size = new System.Drawing.Size(262, 23);
            this.DatabaseObjectsSearchTextbox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.UpdateDatabaseObjectsButton);
            this.panel3.Controls.Add(this.ObjectsLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 27);
            this.panel3.TabIndex = 2;
            // 
            // UpdateDatabaseObjectsButton
            // 
            this.UpdateDatabaseObjectsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDatabaseObjectsButton.Location = new System.Drawing.Point(231, 1);
            this.UpdateDatabaseObjectsButton.Name = "UpdateDatabaseObjectsButton";
            this.UpdateDatabaseObjectsButton.Size = new System.Drawing.Size(30, 25);
            this.UpdateDatabaseObjectsButton.TabIndex = 1;
            this.UpdateDatabaseObjectsButton.UseVisualStyleBackColor = true;
            this.UpdateDatabaseObjectsButton.Click += new System.EventHandler(this.UpdateDatabaseObjectsButton_Click);
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
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 23);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.codeActionsCheckedListBox);
            this.splitContainer4.Panel1.Controls.Add(this.panel8);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.CodeTextbox);
            this.splitContainer4.Size = new System.Drawing.Size(526, 578);
            this.splitContainer4.SplitterDistance = 126;
            this.splitContainer4.TabIndex = 4;
            // 
            // codeActionsCheckedListBox
            // 
            this.codeActionsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeActionsCheckedListBox.FormattingEnabled = true;
            this.codeActionsCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.codeActionsCheckedListBox.Name = "codeActionsCheckedListBox";
            this.codeActionsCheckedListBox.Size = new System.Drawing.Size(387, 126);
            this.codeActionsCheckedListBox.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.AutoClipboardCheckbox);
            this.panel8.Controls.Add(this.ExecuteButton);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(387, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(139, 126);
            this.panel8.TabIndex = 1;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(3, 100);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(133, 23);
            this.ExecuteButton.TabIndex = 0;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
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
            this.CodeTextbox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.CodeTextbox.BackBrush = null;
            this.CodeTextbox.CharHeight = 14;
            this.CodeTextbox.CharWidth = 8;
            this.CodeTextbox.CommentPrefix = "--";
            this.CodeTextbox.DefaultMarkerSize = 8;
            this.CodeTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CodeTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeTextbox.FindForm = null;
            this.CodeTextbox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CodeTextbox.GoToForm = null;
            this.CodeTextbox.Hotkeys = resources.GetString("CodeTextbox.Hotkeys");
            this.CodeTextbox.IsReplaceMode = false;
            this.CodeTextbox.Language = FastColoredTextBoxNS.Text.Language.SQL;
            this.CodeTextbox.LeftBracket = '(';
            this.CodeTextbox.Location = new System.Drawing.Point(0, 0);
            this.CodeTextbox.Name = "CodeTextbox";
            this.CodeTextbox.Paddings = new System.Windows.Forms.Padding(0);
            this.CodeTextbox.ReplaceForm = null;
            this.CodeTextbox.RightBracket = ')';
            this.CodeTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.CodeTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeTextbox.ServiceColors")));
            this.CodeTextbox.Size = new System.Drawing.Size(526, 448);
            this.CodeTextbox.TabIndex = 0;
            this.CodeTextbox.Zoom = 100;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.LanguageComboBox);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(526, 23);
            this.panel4.TabIndex = 3;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "T-SQL",
            "C#"});
            this.LanguageComboBox.Location = new System.Drawing.Point(401, 0);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(122, 23);
            this.LanguageComboBox.TabIndex = 1;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AutoClipboardCheckbox
            // 
            this.AutoClipboardCheckbox.AutoSize = true;
            this.AutoClipboardCheckbox.Checked = true;
            this.AutoClipboardCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoClipboardCheckbox.Location = new System.Drawing.Point(6, 74);
            this.AutoClipboardCheckbox.Name = "AutoClipboardCheckbox";
            this.AutoClipboardCheckbox.Size = new System.Drawing.Size(109, 19);
            this.AutoClipboardCheckbox.TabIndex = 1;
            this.AutoClipboardCheckbox.Text = "Auto-Clipboard";
            this.AutoClipboardCheckbox.UseVisualStyleBackColor = true;
            // 
            // DatabaseBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 625);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DatabaseBrowserForm";
            this.Text = "DatabaseBrowserForm";
            this.Load += new System.EventHandler(this.DatabaseBrowserForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
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
        private ListBox ConnectionsListbox;
        private ListBox DatabasesListbox;
        private Panel panel4;
        private Label label3;
        private FastColoredTextBoxNS.FastColoredTextBox CodeTextbox;
        private ToolStripMenuItem scriptsToolStripMenuItem;
        private ToolStripMenuItem executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem;
        private ComboBox LanguageComboBox;
        private ToolStripMenuItem selectScriptFolderToolStripMenuItem;
        private Button UpdateDatabaseObjectsButton;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel panel7;
        private TextBox ConnectionsSearchTextbox;
        private Button UpdateConnectionsButton;
        private Panel panel6;
        private TextBox DatabasesSearchTextbox;
        private Button UpdateDatabasesButton;
        private ListBox DatabaseObjectsListBox;
        private Panel panel5;
        private TextBox DatabaseObjectsSearchTextbox;
        private ImageList imageList1;
        private SplitContainer splitContainer4;
        private Panel panel8;
        private Button ExecuteButton;
        private CheckedListBox codeActionsCheckedListBox;
        private ToolStripMenuItem navigateToolStripMenuItem;
        private ToolStripMenuItem gotoDatabaseObjectCtrlTToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem performanceOptimizationToolStripMenuItem;
        private ToolStripMenuItem findProblematicSqlObjectsInTheDatabaseToolStripMenuItem;
        private ToolStripMenuItem startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem;
        private ToolStripMenuItem analyseTableSizesAndSpaceTendenciesToolStripMenuItem;
        private ToolStripMenuItem analyseAndOptimizeIndexesToolStripMenuItem;
        private ToolStripMenuItem findProblemsToolStripMenuItem;
        private ToolStripMenuItem findCodeThatSpansMultipleDatabasesToolStripMenuItem;
        private CheckBox AutoClipboardCheckbox;
    }
}