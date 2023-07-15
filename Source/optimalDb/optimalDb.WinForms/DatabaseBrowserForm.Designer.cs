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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseBrowserForm));
            menuStrip1 = new MenuStrip();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            loadConfigurationToolStripMenuItem = new ToolStripMenuItem();
            selectScriptFolderToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            navigateToolStripMenuItem = new ToolStripMenuItem();
            gotoDatabaseObjectCtrlTToolStripMenuItem = new ToolStripMenuItem();
            scriptsToolStripMenuItem = new ToolStripMenuItem();
            executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            performanceOptimizationToolStripMenuItem = new ToolStripMenuItem();
            findProblematicSqlObjectsInTheDatabaseToolStripMenuItem = new ToolStripMenuItem();
            startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem = new ToolStripMenuItem();
            analyseTableSizesAndSpaceTendenciesToolStripMenuItem = new ToolStripMenuItem();
            analyseAndOptimizeIndexesToolStripMenuItem = new ToolStripMenuItem();
            findProblemsToolStripMenuItem = new ToolStripMenuItem();
            findCodeThatSpansMultipleDatabasesToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            ConnectionsListbox = new ListBox();
            ConnectionContextMenuStrip = new ContextMenuStrip(components);
            runUnitTestsToolStripMenuItem = new ToolStripMenuItem();
            panel7 = new Panel();
            ConnectionsSearchTextbox = new TextBox();
            panel1 = new Panel();
            UpdateConnectionsButton = new Button();
            label1 = new Label();
            splitContainer2 = new SplitContainer();
            DatabasesListbox = new ListBox();
            panel6 = new Panel();
            DatabasesSearchTextbox = new TextBox();
            panel2 = new Panel();
            UpdateDatabasesButton = new Button();
            label2 = new Label();
            splitContainer3 = new SplitContainer();
            DatabaseObjectsListBox = new ListBox();
            panel5 = new Panel();
            DatabaseObjectsSearchTextbox = new TextBox();
            panel3 = new Panel();
            UpdateDatabaseObjectsButton = new Button();
            ObjectsLabel = new Label();
            splitContainer4 = new SplitContainer();
            CodeActionsListBox = new ListBox();
            panel8 = new Panel();
            AutoClipboardCheckbox = new CheckBox();
            ExecuteButton = new Button();
            CodeTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
            panel4 = new Panel();
            LanguageComboBox = new ComboBox();
            label3 = new Label();
            imageList1 = new ImageList(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ConnectionContextMenuStrip.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CodeTextbox).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { configurationToolStripMenuItem, aboutToolStripMenuItem, navigateToolStripMenuItem, scriptsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1187, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadConfigurationToolStripMenuItem, selectScriptFolderToolStripMenuItem });
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(93, 20);
            configurationToolStripMenuItem.Text = "Configuration";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            loadConfigurationToolStripMenuItem.Size = new Size(183, 22);
            loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            loadConfigurationToolStripMenuItem.Click += loadConfigurationToolStripMenuItem_Click;
            // 
            // selectScriptFolderToolStripMenuItem
            // 
            selectScriptFolderToolStripMenuItem.Name = "selectScriptFolderToolStripMenuItem";
            selectScriptFolderToolStripMenuItem.Size = new Size(183, 22);
            selectScriptFolderToolStripMenuItem.Text = "Select Script Folder...";
            selectScriptFolderToolStripMenuItem.Click += selectScriptFolderToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // navigateToolStripMenuItem
            // 
            navigateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gotoDatabaseObjectCtrlTToolStripMenuItem });
            navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            navigateToolStripMenuItem.Size = new Size(66, 20);
            navigateToolStripMenuItem.Text = "Navigate";
            // 
            // gotoDatabaseObjectCtrlTToolStripMenuItem
            // 
            gotoDatabaseObjectCtrlTToolStripMenuItem.Name = "gotoDatabaseObjectCtrlTToolStripMenuItem";
            gotoDatabaseObjectCtrlTToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            gotoDatabaseObjectCtrlTToolStripMenuItem.Size = new Size(281, 22);
            gotoDatabaseObjectCtrlTToolStripMenuItem.Text = "Goto Database-Object (Ctrl + T)";
            gotoDatabaseObjectCtrlTToolStripMenuItem.Click += gotoDatabaseObjectToolStripMenuItem_Click;
            // 
            // scriptsToolStripMenuItem
            // 
            scriptsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem, toolStripMenuItem1, performanceOptimizationToolStripMenuItem, findProblemsToolStripMenuItem, toolsToolStripMenuItem });
            scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            scriptsToolStripMenuItem.Size = new Size(46, 20);
            scriptsToolStripMenuItem.Text = "Tools";
            // 
            // executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem
            // 
            executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Name = "executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem";
            executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Size = new Size(350, 22);
            executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Text = "Execute Script on Selected Database Object...";
            executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem.Click += executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(347, 6);
            // 
            // performanceOptimizationToolStripMenuItem
            // 
            performanceOptimizationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findProblematicSqlObjectsInTheDatabaseToolStripMenuItem, startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem, analyseTableSizesAndSpaceTendenciesToolStripMenuItem, analyseAndOptimizeIndexesToolStripMenuItem });
            performanceOptimizationToolStripMenuItem.Name = "performanceOptimizationToolStripMenuItem";
            performanceOptimizationToolStripMenuItem.Size = new Size(350, 22);
            performanceOptimizationToolStripMenuItem.Text = "Optimize Performance";
            performanceOptimizationToolStripMenuItem.Click += performanceOptimizationToolStripMenuItem_Click;
            // 
            // findProblematicSqlObjectsInTheDatabaseToolStripMenuItem
            // 
            findProblematicSqlObjectsInTheDatabaseToolStripMenuItem.Name = "findProblematicSqlObjectsInTheDatabaseToolStripMenuItem";
            findProblematicSqlObjectsInTheDatabaseToolStripMenuItem.Size = new Size(376, 22);
            findProblematicSqlObjectsInTheDatabaseToolStripMenuItem.Text = "Find problematic Sql Objects in the database";
            // 
            // startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem
            // 
            startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem.Name = "startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem";
            startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem.Size = new Size(376, 22);
            startPerformanceOptimizationSessionOnThisSqlObjectToolStripMenuItem.Text = "Start performance optimization session on this Sql Object";
            // 
            // analyseTableSizesAndSpaceTendenciesToolStripMenuItem
            // 
            analyseTableSizesAndSpaceTendenciesToolStripMenuItem.Name = "analyseTableSizesAndSpaceTendenciesToolStripMenuItem";
            analyseTableSizesAndSpaceTendenciesToolStripMenuItem.Size = new Size(376, 22);
            analyseTableSizesAndSpaceTendenciesToolStripMenuItem.Text = "Analyse table sizes and space tendencies";
            // 
            // analyseAndOptimizeIndexesToolStripMenuItem
            // 
            analyseAndOptimizeIndexesToolStripMenuItem.Name = "analyseAndOptimizeIndexesToolStripMenuItem";
            analyseAndOptimizeIndexesToolStripMenuItem.Size = new Size(376, 22);
            analyseAndOptimizeIndexesToolStripMenuItem.Text = "Analyse and optimize indexes";
            // 
            // findProblemsToolStripMenuItem
            // 
            findProblemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findCodeThatSpansMultipleDatabasesToolStripMenuItem });
            findProblemsToolStripMenuItem.Name = "findProblemsToolStripMenuItem";
            findProblemsToolStripMenuItem.Size = new Size(350, 22);
            findProblemsToolStripMenuItem.Text = "Find Problems";
            // 
            // findCodeThatSpansMultipleDatabasesToolStripMenuItem
            // 
            findCodeThatSpansMultipleDatabasesToolStripMenuItem.Name = "findCodeThatSpansMultipleDatabasesToolStripMenuItem";
            findCodeThatSpansMultipleDatabasesToolStripMenuItem.Size = new Size(285, 22);
            findCodeThatSpansMultipleDatabasesToolStripMenuItem.Text = "Find code that spans multiple databases";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(350, 22);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ConnectionsListbox);
            splitContainer1.Panel1.Controls.Add(panel7);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1187, 601);
            splitContainer1.SplitterDistance = 176;
            splitContainer1.TabIndex = 1;
            // 
            // ConnectionsListbox
            // 
            ConnectionsListbox.ContextMenuStrip = ConnectionContextMenuStrip;
            ConnectionsListbox.Dock = DockStyle.Fill;
            ConnectionsListbox.FormattingEnabled = true;
            ConnectionsListbox.ItemHeight = 15;
            ConnectionsListbox.Location = new Point(0, 54);
            ConnectionsListbox.Name = "ConnectionsListbox";
            ConnectionsListbox.Size = new Size(176, 547);
            ConnectionsListbox.TabIndex = 1;
            ConnectionsListbox.SelectedIndexChanged += connectionStringListbox_SelectedIndexChanged;
            // 
            // ConnectionContextMenuStrip
            // 
            ConnectionContextMenuStrip.Items.AddRange(new ToolStripItem[] { runUnitTestsToolStripMenuItem });
            ConnectionContextMenuStrip.Name = "ConnectionContextMenuStrip";
            ConnectionContextMenuStrip.Size = new Size(160, 26);
            ConnectionContextMenuStrip.Opening += ConnectionContextMenuStrip_Opening;
            // 
            // runUnitTestsToolStripMenuItem
            // 
            runUnitTestsToolStripMenuItem.Name = "runUnitTestsToolStripMenuItem";
            runUnitTestsToolStripMenuItem.Size = new Size(159, 22);
            runUnitTestsToolStripMenuItem.Text = "Run Unit-Tests...";
            runUnitTestsToolStripMenuItem.Click += runUnitTestsToolStripMenuItem_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(ConnectionsSearchTextbox);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 27);
            panel7.Name = "panel7";
            panel7.Size = new Size(176, 27);
            panel7.TabIndex = 5;
            // 
            // ConnectionsSearchTextbox
            // 
            ConnectionsSearchTextbox.Dock = DockStyle.Top;
            ConnectionsSearchTextbox.Location = new Point(0, 0);
            ConnectionsSearchTextbox.Name = "ConnectionsSearchTextbox";
            ConnectionsSearchTextbox.Size = new Size(176, 23);
            ConnectionsSearchTextbox.TabIndex = 0;
            ConnectionsSearchTextbox.KeyDown += ConnectionsSearchTextbox_KeyDown;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(UpdateConnectionsButton);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(176, 27);
            panel1.TabIndex = 0;
            // 
            // UpdateConnectionsButton
            // 
            UpdateConnectionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateConnectionsButton.Location = new Point(145, 1);
            UpdateConnectionsButton.Name = "UpdateConnectionsButton";
            UpdateConnectionsButton.Size = new Size(30, 25);
            UpdateConnectionsButton.TabIndex = 2;
            UpdateConnectionsButton.UseVisualStyleBackColor = true;
            UpdateConnectionsButton.Click += UpdateConnectionsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Connections";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(DatabasesListbox);
            splitContainer2.Panel1.Controls.Add(panel6);
            splitContainer2.Panel1.Controls.Add(panel2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1007, 601);
            splitContainer2.SplitterDistance = 211;
            splitContainer2.TabIndex = 0;
            // 
            // DatabasesListbox
            // 
            DatabasesListbox.Dock = DockStyle.Fill;
            DatabasesListbox.FormattingEnabled = true;
            DatabasesListbox.ItemHeight = 15;
            DatabasesListbox.Location = new Point(0, 54);
            DatabasesListbox.Name = "DatabasesListbox";
            DatabasesListbox.Size = new Size(211, 547);
            DatabasesListbox.TabIndex = 2;
            DatabasesListbox.SelectedIndexChanged += DatabasesListbox_SelectedIndexChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(DatabasesSearchTextbox);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 27);
            panel6.Name = "panel6";
            panel6.Size = new Size(211, 27);
            panel6.TabIndex = 5;
            // 
            // DatabasesSearchTextbox
            // 
            DatabasesSearchTextbox.Dock = DockStyle.Top;
            DatabasesSearchTextbox.Location = new Point(0, 0);
            DatabasesSearchTextbox.Name = "DatabasesSearchTextbox";
            DatabasesSearchTextbox.Size = new Size(211, 23);
            DatabasesSearchTextbox.TabIndex = 0;
            DatabasesSearchTextbox.KeyDown += DatabasesSearchTextbox_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(UpdateDatabasesButton);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 27);
            panel2.TabIndex = 1;
            // 
            // UpdateDatabasesButton
            // 
            UpdateDatabasesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateDatabasesButton.Location = new Point(180, 1);
            UpdateDatabasesButton.Name = "UpdateDatabasesButton";
            UpdateDatabasesButton.Size = new Size(30, 25);
            UpdateDatabasesButton.TabIndex = 2;
            UpdateDatabasesButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 0;
            label2.Text = "Databases";
            // 
            // splitContainer3
            // 
            splitContainer3.BackColor = SystemColors.ControlLight;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel1;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(DatabaseObjectsListBox);
            splitContainer3.Panel1.Controls.Add(panel5);
            splitContainer3.Panel1.Controls.Add(panel3);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Panel2.Controls.Add(panel4);
            splitContainer3.Size = new Size(792, 601);
            splitContainer3.SplitterDistance = 262;
            splitContainer3.TabIndex = 0;
            // 
            // DatabaseObjectsListBox
            // 
            DatabaseObjectsListBox.Dock = DockStyle.Fill;
            DatabaseObjectsListBox.FormattingEnabled = true;
            DatabaseObjectsListBox.ItemHeight = 15;
            DatabaseObjectsListBox.Location = new Point(0, 54);
            DatabaseObjectsListBox.Name = "DatabaseObjectsListBox";
            DatabaseObjectsListBox.Size = new Size(262, 547);
            DatabaseObjectsListBox.TabIndex = 3;
            DatabaseObjectsListBox.SelectedIndexChanged += DatabaseObjectsListBox_SelectedIndexChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(DatabaseObjectsSearchTextbox);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 27);
            panel5.Name = "panel5";
            panel5.Size = new Size(262, 27);
            panel5.TabIndex = 4;
            // 
            // DatabaseObjectsSearchTextbox
            // 
            DatabaseObjectsSearchTextbox.Dock = DockStyle.Top;
            DatabaseObjectsSearchTextbox.Location = new Point(0, 0);
            DatabaseObjectsSearchTextbox.Name = "DatabaseObjectsSearchTextbox";
            DatabaseObjectsSearchTextbox.Size = new Size(262, 23);
            DatabaseObjectsSearchTextbox.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(UpdateDatabaseObjectsButton);
            panel3.Controls.Add(ObjectsLabel);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(262, 27);
            panel3.TabIndex = 2;
            // 
            // UpdateDatabaseObjectsButton
            // 
            UpdateDatabaseObjectsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateDatabaseObjectsButton.Location = new Point(231, 1);
            UpdateDatabaseObjectsButton.Name = "UpdateDatabaseObjectsButton";
            UpdateDatabaseObjectsButton.Size = new Size(30, 25);
            UpdateDatabaseObjectsButton.TabIndex = 1;
            UpdateDatabaseObjectsButton.UseVisualStyleBackColor = true;
            UpdateDatabaseObjectsButton.Click += UpdateDatabaseObjectsButton_Click;
            // 
            // ObjectsLabel
            // 
            ObjectsLabel.AutoSize = true;
            ObjectsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ObjectsLabel.Location = new Point(3, 4);
            ObjectsLabel.Name = "ObjectsLabel";
            ObjectsLabel.Size = new Size(103, 15);
            ObjectsLabel.TabIndex = 0;
            ObjectsLabel.Text = "Database Objects";
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.FixedPanel = FixedPanel.Panel1;
            splitContainer4.Location = new Point(0, 23);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(CodeActionsListBox);
            splitContainer4.Panel1.Controls.Add(panel8);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(CodeTextbox);
            splitContainer4.Size = new Size(526, 578);
            splitContainer4.SplitterDistance = 159;
            splitContainer4.TabIndex = 4;
            // 
            // CodeActionsListBox
            // 
            CodeActionsListBox.Dock = DockStyle.Fill;
            CodeActionsListBox.FormattingEnabled = true;
            CodeActionsListBox.ItemHeight = 15;
            CodeActionsListBox.Location = new Point(0, 0);
            CodeActionsListBox.Name = "CodeActionsListBox";
            CodeActionsListBox.SelectionMode = SelectionMode.MultiExtended;
            CodeActionsListBox.Size = new Size(387, 159);
            CodeActionsListBox.TabIndex = 2;
            CodeActionsListBox.SelectedIndexChanged += CodeActionsListBox_SelectedIndexChanged;
            // 
            // panel8
            // 
            panel8.Controls.Add(AutoClipboardCheckbox);
            panel8.Controls.Add(ExecuteButton);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(387, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(139, 159);
            panel8.TabIndex = 1;
            // 
            // AutoClipboardCheckbox
            // 
            AutoClipboardCheckbox.AutoSize = true;
            AutoClipboardCheckbox.Checked = true;
            AutoClipboardCheckbox.CheckState = CheckState.Checked;
            AutoClipboardCheckbox.Location = new Point(6, 108);
            AutoClipboardCheckbox.Name = "AutoClipboardCheckbox";
            AutoClipboardCheckbox.Size = new Size(109, 19);
            AutoClipboardCheckbox.TabIndex = 1;
            AutoClipboardCheckbox.Text = "Auto-Clipboard";
            AutoClipboardCheckbox.UseVisualStyleBackColor = true;
            // 
            // ExecuteButton
            // 
            ExecuteButton.Location = new Point(3, 133);
            ExecuteButton.Name = "ExecuteButton";
            ExecuteButton.Size = new Size(133, 23);
            ExecuteButton.TabIndex = 0;
            ExecuteButton.Text = "Execute";
            ExecuteButton.UseVisualStyleBackColor = true;
            ExecuteButton.Click += ExecuteButton_Click;
            // 
            // CodeTextbox
            // 
            CodeTextbox.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
            CodeTextbox.AutoIndentCharsPatterns = "";
            CodeTextbox.AutoScrollMinSize = new Size(27, 14);
            CodeTextbox.BackBrush = null;
            CodeTextbox.CharHeight = 14;
            CodeTextbox.CharWidth = 8;
            CodeTextbox.CommentPrefix = "--";
            CodeTextbox.DefaultMarkerSize = 8;
            CodeTextbox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            CodeTextbox.Dock = DockStyle.Fill;
            CodeTextbox.FindForm = null;
            CodeTextbox.GoToForm = null;
            CodeTextbox.Hotkeys = resources.GetString("CodeTextbox.Hotkeys");
            CodeTextbox.IsReplaceMode = false;
            CodeTextbox.Language = FastColoredTextBoxNS.Text.Language.SQL;
            CodeTextbox.LeftBracket = '(';
            CodeTextbox.Location = new Point(0, 0);
            CodeTextbox.Name = "CodeTextbox";
            CodeTextbox.Paddings = new Padding(0);
            CodeTextbox.ReplaceForm = null;
            CodeTextbox.RightBracket = ')';
            CodeTextbox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            CodeTextbox.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("CodeTextbox.ServiceColors");
            CodeTextbox.Size = new Size(526, 415);
            CodeTextbox.TabIndex = 0;
            CodeTextbox.Zoom = 100;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDark;
            panel4.Controls.Add(LanguageComboBox);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(526, 23);
            panel4.TabIndex = 3;
            // 
            // LanguageComboBox
            // 
            LanguageComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LanguageComboBox.FormattingEnabled = true;
            LanguageComboBox.Items.AddRange(new object[] { "T-SQL", "C#" });
            LanguageComboBox.Location = new Point(401, 0);
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.Size = new Size(122, 23);
            LanguageComboBox.TabIndex = 1;
            LanguageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 0;
            label3.Text = "Code";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // DatabaseBrowserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 625);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "DatabaseBrowserForm";
            Text = "DatabaseBrowserForm";
            Load += DatabaseBrowserForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ConnectionContextMenuStrip.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CodeTextbox).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ListBox CodeActionsListBox;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ContextMenuStrip ConnectionContextMenuStrip;
        private ToolStripMenuItem runUnitTestsToolStripMenuItem;
    }
}