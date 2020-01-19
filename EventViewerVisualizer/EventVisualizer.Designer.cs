namespace EventViewerVisualizer
{
    partial class EventVisualizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventVisualizer));
            this.groupBoxSystem = new System.Windows.Forms.GroupBox();
            this.checkBoxExportDb = new System.Windows.Forms.CheckBox();
            this.checkBoxShowAll = new System.Windows.Forms.CheckBox();
            this.checkBoxTransactionView = new System.Windows.Forms.CheckBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.textBoxLogName = new System.Windows.Forms.TextBox();
            this.labelLogName = new System.Windows.Forms.Label();
            this.textBoxTXNLocation = new System.Windows.Forms.TextBox();
            this.labelTXNLocation = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.checkBoxShowFilter = new System.Windows.Forms.CheckBox();
            this.buttonApplySettingsFilter = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonCLearLog = new System.Windows.Forms.Button();
            this.textBoxSystem = new System.Windows.Forms.TextBox();
            this.labelSystem = new System.Windows.Forms.Label();
            this.statusStripStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTransactionNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDivider = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelectedText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelErrorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialogTXNLocation = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogTXNLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainerEvents = new System.Windows.Forms.SplitContainer();
            this.panelEvents = new System.Windows.Forms.Panel();
            this.groupBoxAllEvents = new System.Windows.Forms.GroupBox();
            this.listBoxAllEvents = new System.Windows.Forms.ListBox();
            this.textBoxEventText = new System.Windows.Forms.TextBox();
            this.groupBoxBlank = new System.Windows.Forms.GroupBox();
            this.groupBoxTextView = new System.Windows.Forms.GroupBox();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            this.groupBoxVisualizer = new System.Windows.Forms.GroupBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.labelTXNNo = new System.Windows.Forms.Label();
            this.textBoxTXN = new System.Windows.Forms.TextBox();
            this.labelTeller = new System.Windows.Forms.Label();
            this.textBoxTeller = new System.Windows.Forms.TextBox();
            this.labelDBDetails = new System.Windows.Forms.Label();
            this.textBoxDBDetails = new System.Windows.Forms.TextBox();
            this.labelFilterNote = new System.Windows.Forms.Label();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxSystem.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.statusStripStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEvents)).BeginInit();
            this.splitContainerEvents.Panel1.SuspendLayout();
            this.splitContainerEvents.Panel2.SuspendLayout();
            this.splitContainerEvents.SuspendLayout();
            this.panelEvents.SuspendLayout();
            this.groupBoxAllEvents.SuspendLayout();
            this.groupBoxBlank.SuspendLayout();
            this.groupBoxTextView.SuspendLayout();
            this.groupBoxVisualizer.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSystem
            // 
            this.groupBoxSystem.Controls.Add(this.checkBoxExportDb);
            this.groupBoxSystem.Controls.Add(this.checkBoxShowAll);
            this.groupBoxSystem.Controls.Add(this.checkBoxTransactionView);
            this.groupBoxSystem.Controls.Add(this.textBoxSource);
            this.groupBoxSystem.Controls.Add(this.labelSource);
            this.groupBoxSystem.Controls.Add(this.textBoxLogName);
            this.groupBoxSystem.Controls.Add(this.labelLogName);
            this.groupBoxSystem.Controls.Add(this.textBoxTXNLocation);
            this.groupBoxSystem.Controls.Add(this.labelTXNLocation);
            this.groupBoxSystem.Controls.Add(this.panelSettings);
            this.groupBoxSystem.Controls.Add(this.textBoxSystem);
            this.groupBoxSystem.Controls.Add(this.labelSystem);
            this.groupBoxSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSystem.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSystem.Name = "groupBoxSystem";
            this.groupBoxSystem.Size = new System.Drawing.Size(929, 103);
            this.groupBoxSystem.TabIndex = 0;
            this.groupBoxSystem.TabStop = false;
            this.groupBoxSystem.Text = "Select Event Source";
            // 
            // checkBoxExportDb
            // 
            this.checkBoxExportDb.AutoSize = true;
            this.checkBoxExportDb.Location = new System.Drawing.Point(385, 80);
            this.checkBoxExportDb.Name = "checkBoxExportDb";
            this.checkBoxExportDb.Size = new System.Drawing.Size(121, 17);
            this.checkBoxExportDb.TabIndex = 13;
            this.checkBoxExportDb.Text = "Export To Database";
            this.checkBoxExportDb.UseVisualStyleBackColor = true;
            this.checkBoxExportDb.CheckedChanged += new System.EventHandler(this.checkBoxExportDb_CheckedChanged);
            // 
            // checkBoxShowAll
            // 
            this.checkBoxShowAll.AutoSize = true;
            this.checkBoxShowAll.Checked = true;
            this.checkBoxShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowAll.Location = new System.Drawing.Point(97, 80);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(98, 17);
            this.checkBoxShowAll.TabIndex = 12;
            this.checkBoxShowAll.Text = "Show All Event";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            this.checkBoxShowAll.CheckedChanged += new System.EventHandler(this.checkBoxShowAll_CheckedChanged);
            // 
            // checkBoxTransactionView
            // 
            this.checkBoxTransactionView.AutoSize = true;
            this.checkBoxTransactionView.Location = new System.Drawing.Point(218, 80);
            this.checkBoxTransactionView.Name = "checkBoxTransactionView";
            this.checkBoxTransactionView.Size = new System.Drawing.Size(161, 17);
            this.checkBoxTransactionView.TabIndex = 8;
            this.checkBoxTransactionView.Text = "Show Transaction List Panel";
            this.checkBoxTransactionView.UseVisualStyleBackColor = true;
            this.checkBoxTransactionView.CheckedChanged += new System.EventHandler(this.checkBoxTransactionView_CheckedChanged);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(366, 49);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.Size = new System.Drawing.Size(165, 20);
            this.textBoxSource.TabIndex = 11;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(316, 52);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 10;
            this.labelSource.Text = "Source:";
            // 
            // textBoxLogName
            // 
            this.textBoxLogName.Location = new System.Drawing.Point(97, 49);
            this.textBoxLogName.Name = "textBoxLogName";
            this.textBoxLogName.ReadOnly = true;
            this.textBoxLogName.Size = new System.Drawing.Size(165, 20);
            this.textBoxLogName.TabIndex = 9;
            // 
            // labelLogName
            // 
            this.labelLogName.AutoSize = true;
            this.labelLogName.Location = new System.Drawing.Point(32, 52);
            this.labelLogName.Name = "labelLogName";
            this.labelLogName.Size = new System.Drawing.Size(59, 13);
            this.labelLogName.TabIndex = 8;
            this.labelLogName.Text = "Log Name:";
            // 
            // textBoxTXNLocation
            // 
            this.textBoxTXNLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxTXNLocation.Location = new System.Drawing.Point(366, 25);
            this.textBoxTXNLocation.Name = "textBoxTXNLocation";
            this.textBoxTXNLocation.ReadOnly = true;
            this.textBoxTXNLocation.Size = new System.Drawing.Size(292, 20);
            this.textBoxTXNLocation.TabIndex = 7;
            this.textBoxTXNLocation.Click += new System.EventHandler(this.textBoxTXNLocation_Click);
            // 
            // labelTXNLocation
            // 
            this.labelTXNLocation.AutoSize = true;
            this.labelTXNLocation.Location = new System.Drawing.Point(284, 28);
            this.labelTXNLocation.Name = "labelTXNLocation";
            this.labelTXNLocation.Size = new System.Drawing.Size(76, 13);
            this.labelTXNLocation.TabIndex = 6;
            this.labelTXNLocation.Text = "TXN Location:";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.checkBoxShowFilter);
            this.panelSettings.Controls.Add(this.buttonApplySettingsFilter);
            this.panelSettings.Controls.Add(this.buttonRefresh);
            this.panelSettings.Controls.Add(this.buttonCLearLog);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(675, 16);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(251, 84);
            this.panelSettings.TabIndex = 5;
            // 
            // checkBoxShowFilter
            // 
            this.checkBoxShowFilter.AutoSize = true;
            this.checkBoxShowFilter.Location = new System.Drawing.Point(114, 63);
            this.checkBoxShowFilter.Name = "checkBoxShowFilter";
            this.checkBoxShowFilter.Size = new System.Drawing.Size(108, 17);
            this.checkBoxShowFilter.TabIndex = 8;
            this.checkBoxShowFilter.Text = "Show Filter Panel";
            this.checkBoxShowFilter.UseVisualStyleBackColor = true;
            this.checkBoxShowFilter.CheckedChanged += new System.EventHandler(this.checkBoxShowFilter_CheckedChanged);
            // 
            // buttonApplySettingsFilter
            // 
            this.buttonApplySettingsFilter.Location = new System.Drawing.Point(110, 33);
            this.buttonApplySettingsFilter.Name = "buttonApplySettingsFilter";
            this.buttonApplySettingsFilter.Size = new System.Drawing.Size(131, 25);
            this.buttonApplySettingsFilter.TabIndex = 5;
            this.buttonApplySettingsFilter.Text = "Apply Settings Or Filters";
            this.buttonApplySettingsFilter.UseVisualStyleBackColor = true;
            this.buttonApplySettingsFilter.Click += new System.EventHandler(this.buttonApplySettingsFilter_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRefresh.Location = new System.Drawing.Point(0, 0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(96, 84);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonCLearLog
            // 
            this.buttonCLearLog.Location = new System.Drawing.Point(110, 5);
            this.buttonCLearLog.Name = "buttonCLearLog";
            this.buttonCLearLog.Size = new System.Drawing.Size(131, 25);
            this.buttonCLearLog.TabIndex = 3;
            this.buttonCLearLog.Text = "Clear Log";
            this.buttonCLearLog.UseVisualStyleBackColor = true;
            this.buttonCLearLog.Click += new System.EventHandler(this.buttonCLearLog_Click);
            // 
            // textBoxSystem
            // 
            this.textBoxSystem.Location = new System.Drawing.Point(97, 25);
            this.textBoxSystem.Name = "textBoxSystem";
            this.textBoxSystem.ReadOnly = true;
            this.textBoxSystem.Size = new System.Drawing.Size(165, 20);
            this.textBoxSystem.TabIndex = 2;
            // 
            // labelSystem
            // 
            this.labelSystem.AutoSize = true;
            this.labelSystem.Location = new System.Drawing.Point(47, 28);
            this.labelSystem.Name = "labelSystem";
            this.labelSystem.Size = new System.Drawing.Size(44, 13);
            this.labelSystem.TabIndex = 1;
            this.labelSystem.Text = "System:";
            // 
            // statusStripStatus
            // 
            this.statusStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTransactionNumber,
            this.toolStripStatusLabelDivider,
            this.toolStripStatusLabelSelectedText,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelErrorStatus});
            this.statusStripStatus.Location = new System.Drawing.Point(0, 461);
            this.statusStripStatus.Name = "statusStripStatus";
            this.statusStripStatus.Size = new System.Drawing.Size(929, 22);
            this.statusStripStatus.TabIndex = 3;
            this.statusStripStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabelTransactionNumber
            // 
            this.toolStripStatusLabelTransactionNumber.Name = "toolStripStatusLabelTransactionNumber";
            this.toolStripStatusLabelTransactionNumber.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabelTransactionNumber.Text = "000000";
            // 
            // toolStripStatusLabelDivider
            // 
            this.toolStripStatusLabelDivider.Name = "toolStripStatusLabelDivider";
            this.toolStripStatusLabelDivider.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelDivider.Text = " | ";
            // 
            // toolStripStatusLabelSelectedText
            // 
            this.toolStripStatusLabelSelectedText.Name = "toolStripStatusLabelSelectedText";
            this.toolStripStatusLabelSelectedText.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabelSelectedText.Text = "Selected Value";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel2.Text = " | ";
            // 
            // toolStripStatusLabelErrorStatus
            // 
            this.toolStripStatusLabelErrorStatus.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelErrorStatus.Name = "toolStripStatusLabelErrorStatus";
            this.toolStripStatusLabelErrorStatus.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabelErrorStatus.Text = "Error Status";
            // 
            // openFileDialogTXNLocation
            // 
            this.openFileDialogTXNLocation.FileName = "openFileDialog1";
            // 
            // splitContainerEvents
            // 
            this.splitContainerEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEvents.Location = new System.Drawing.Point(0, 103);
            this.splitContainerEvents.Name = "splitContainerEvents";
            this.splitContainerEvents.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEvents.Panel1
            // 
            this.splitContainerEvents.Panel1.Controls.Add(this.splitContainerMain);
            // 
            // splitContainerEvents.Panel2
            // 
            this.splitContainerEvents.Panel2.Controls.Add(this.panelEvents);
            this.splitContainerEvents.Size = new System.Drawing.Size(929, 358);
            this.splitContainerEvents.SplitterDistance = 207;
            this.splitContainerEvents.TabIndex = 8;
            // 
            // panelEvents
            // 
            this.panelEvents.Controls.Add(this.groupBoxAllEvents);
            this.panelEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEvents.Location = new System.Drawing.Point(0, 0);
            this.panelEvents.Name = "panelEvents";
            this.panelEvents.Size = new System.Drawing.Size(929, 147);
            this.panelEvents.TabIndex = 8;
            // 
            // groupBoxAllEvents
            // 
            this.groupBoxAllEvents.Controls.Add(this.listBoxAllEvents);
            this.groupBoxAllEvents.Controls.Add(this.textBoxEventText);
            this.groupBoxAllEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAllEvents.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAllEvents.Name = "groupBoxAllEvents";
            this.groupBoxAllEvents.Size = new System.Drawing.Size(929, 147);
            this.groupBoxAllEvents.TabIndex = 0;
            this.groupBoxAllEvents.TabStop = false;
            this.groupBoxAllEvents.Text = "All events";
            // 
            // listBoxAllEvents
            // 
            this.listBoxAllEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAllEvents.FormattingEnabled = true;
            this.listBoxAllEvents.Location = new System.Drawing.Point(3, 16);
            this.listBoxAllEvents.Name = "listBoxAllEvents";
            this.listBoxAllEvents.Size = new System.Drawing.Size(923, 52);
            this.listBoxAllEvents.TabIndex = 5;
            this.listBoxAllEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxAllEvents_SelectedIndexChanged);
            // 
            // textBoxEventText
            // 
            this.textBoxEventText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxEventText.Location = new System.Drawing.Point(3, 68);
            this.textBoxEventText.Multiline = true;
            this.textBoxEventText.Name = "textBoxEventText";
            this.textBoxEventText.ReadOnly = true;
            this.textBoxEventText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEventText.Size = new System.Drawing.Size(923, 76);
            this.textBoxEventText.TabIndex = 4;
            // 
            // groupBoxBlank
            // 
            this.groupBoxBlank.Controls.Add(this.groupBoxVisualizer);
            this.groupBoxBlank.Controls.Add(this.groupBoxTextView);
            this.groupBoxBlank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBlank.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBlank.Name = "groupBoxBlank";
            this.groupBoxBlank.Size = new System.Drawing.Size(674, 207);
            this.groupBoxBlank.TabIndex = 5;
            this.groupBoxBlank.TabStop = false;
            // 
            // groupBoxTextView
            // 
            this.groupBoxTextView.Controls.Add(this.textBoxEventLog);
            this.groupBoxTextView.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTextView.Location = new System.Drawing.Point(3, 16);
            this.groupBoxTextView.Name = "groupBoxTextView";
            this.groupBoxTextView.Size = new System.Drawing.Size(668, 90);
            this.groupBoxTextView.TabIndex = 7;
            this.groupBoxTextView.TabStop = false;
            this.groupBoxTextView.Text = "Text View";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEventLog.Location = new System.Drawing.Point(3, 16);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEventLog.Size = new System.Drawing.Size(662, 71);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // groupBoxVisualizer
            // 
            this.groupBoxVisualizer.Controls.Add(this.textBoxDestination);
            this.groupBoxVisualizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxVisualizer.Location = new System.Drawing.Point(3, 106);
            this.groupBoxVisualizer.Name = "groupBoxVisualizer";
            this.groupBoxVisualizer.Size = new System.Drawing.Size(668, 98);
            this.groupBoxVisualizer.TabIndex = 8;
            this.groupBoxVisualizer.TabStop = false;
            this.groupBoxVisualizer.Text = "Visualizer";
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDestination.Location = new System.Drawing.Point(3, 16);
            this.textBoxDestination.Multiline = true;
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.ReadOnly = true;
            this.textBoxDestination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDestination.Size = new System.Drawing.Size(662, 79);
            this.textBoxDestination.TabIndex = 1;
            this.textBoxDestination.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxDestination_MouseClick);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.labelFilterNote);
            this.groupBoxFilter.Controls.Add(this.textBoxDBDetails);
            this.groupBoxFilter.Controls.Add(this.labelDBDetails);
            this.groupBoxFilter.Controls.Add(this.textBoxTeller);
            this.groupBoxFilter.Controls.Add(this.labelTeller);
            this.groupBoxFilter.Controls.Add(this.textBoxTXN);
            this.groupBoxFilter.Controls.Add(this.labelTXNNo);
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(251, 140);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filters";
            this.groupBoxFilter.Visible = false;
            // 
            // labelTXNNo
            // 
            this.labelTXNNo.AutoSize = true;
            this.labelTXNNo.Location = new System.Drawing.Point(12, 48);
            this.labelTXNNo.Name = "labelTXNNo";
            this.labelTXNNo.Size = new System.Drawing.Size(83, 13);
            this.labelTXNNo.TabIndex = 16;
            this.labelTXNNo.Text = "Transaction No:";
            // 
            // textBoxTXN
            // 
            this.textBoxTXN.Location = new System.Drawing.Point(101, 45);
            this.textBoxTXN.Name = "textBoxTXN";
            this.textBoxTXN.ReadOnly = true;
            this.textBoxTXN.Size = new System.Drawing.Size(83, 20);
            this.textBoxTXN.TabIndex = 17;
            // 
            // labelTeller
            // 
            this.labelTeller.AutoSize = true;
            this.labelTeller.Location = new System.Drawing.Point(59, 22);
            this.labelTeller.Name = "labelTeller";
            this.labelTeller.Size = new System.Drawing.Size(36, 13);
            this.labelTeller.TabIndex = 14;
            this.labelTeller.Text = "Teller:";
            // 
            // textBoxTeller
            // 
            this.textBoxTeller.Location = new System.Drawing.Point(101, 19);
            this.textBoxTeller.Name = "textBoxTeller";
            this.textBoxTeller.ReadOnly = true;
            this.textBoxTeller.Size = new System.Drawing.Size(83, 20);
            this.textBoxTeller.TabIndex = 15;
            // 
            // labelDBDetails
            // 
            this.labelDBDetails.AutoSize = true;
            this.labelDBDetails.Location = new System.Drawing.Point(25, 74);
            this.labelDBDetails.Name = "labelDBDetails";
            this.labelDBDetails.Size = new System.Drawing.Size(60, 13);
            this.labelDBDetails.TabIndex = 18;
            this.labelDBDetails.Text = "DB Details:";
            // 
            // textBoxDBDetails
            // 
            this.textBoxDBDetails.Location = new System.Drawing.Point(101, 71);
            this.textBoxDBDetails.Name = "textBoxDBDetails";
            this.textBoxDBDetails.ReadOnly = true;
            this.textBoxDBDetails.Size = new System.Drawing.Size(134, 20);
            this.textBoxDBDetails.TabIndex = 19;
            // 
            // labelFilterNote
            // 
            this.labelFilterNote.AutoSize = true;
            this.labelFilterNote.ForeColor = System.Drawing.Color.Brown;
            this.labelFilterNote.Location = new System.Drawing.Point(32, 106);
            this.labelFilterNote.Name = "labelFilterNote";
            this.labelFilterNote.Size = new System.Drawing.Size(166, 13);
            this.labelFilterNote.TabIndex = 20;
            this.labelFilterNote.Text = "**To change filter Go To Settings.";
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.listBoxEvents);
            this.groupBoxEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEvent.Location = new System.Drawing.Point(0, 140);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(251, 67);
            this.groupBoxEvent.TabIndex = 5;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Events";
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(3, 16);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(245, 48);
            this.listBoxEvents.TabIndex = 0;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxEvent);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxFilter);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxBlank);
            this.splitContainerMain.Size = new System.Drawing.Size(929, 207);
            this.splitContainerMain.SplitterDistance = 251;
            this.splitContainerMain.TabIndex = 9;
            // 
            // EventVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 483);
            this.Controls.Add(this.splitContainerEvents);
            this.Controls.Add(this.statusStripStatus);
            this.Controls.Add(this.groupBoxSystem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(945, 475);
            this.Name = "EventVisualizer";
            this.Text = "Visualizer";
            this.Load += new System.EventHandler(this.EventVisualizer_Load);
            this.groupBoxSystem.ResumeLayout(false);
            this.groupBoxSystem.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.statusStripStatus.ResumeLayout(false);
            this.statusStripStatus.PerformLayout();
            this.splitContainerEvents.Panel1.ResumeLayout(false);
            this.splitContainerEvents.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEvents)).EndInit();
            this.splitContainerEvents.ResumeLayout(false);
            this.panelEvents.ResumeLayout(false);
            this.groupBoxAllEvents.ResumeLayout(false);
            this.groupBoxAllEvents.PerformLayout();
            this.groupBoxBlank.ResumeLayout(false);
            this.groupBoxTextView.ResumeLayout(false);
            this.groupBoxTextView.PerformLayout();
            this.groupBoxVisualizer.ResumeLayout(false);
            this.groupBoxVisualizer.PerformLayout();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxEvent.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSystem;
        private System.Windows.Forms.StatusStrip statusStripStatus;
        private System.Windows.Forms.TextBox textBoxSystem;
        private System.Windows.Forms.Label labelSystem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTransactionNumber;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonCLearLog;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button buttonApplySettingsFilter;
        private System.Windows.Forms.TextBox textBoxTXNLocation;
        private System.Windows.Forms.Label labelTXNLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialogTXNLocation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTXNLocation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDivider;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelErrorStatus;
        private System.Windows.Forms.CheckBox checkBoxShowFilter;
        private System.Windows.Forms.TextBox textBoxLogName;
        private System.Windows.Forms.Label labelLogName;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelectedText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.CheckBox checkBoxTransactionView;
        private System.Windows.Forms.SplitContainer splitContainerEvents;
        private System.Windows.Forms.Panel panelEvents;
        private System.Windows.Forms.GroupBox groupBoxAllEvents;
        private System.Windows.Forms.ListBox listBoxAllEvents;
        private System.Windows.Forms.TextBox textBoxEventText;
        private System.Windows.Forms.CheckBox checkBoxShowAll;
        private System.Windows.Forms.CheckBox checkBoxExportDb;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelFilterNote;
        private System.Windows.Forms.TextBox textBoxDBDetails;
        private System.Windows.Forms.Label labelDBDetails;
        private System.Windows.Forms.TextBox textBoxTeller;
        private System.Windows.Forms.Label labelTeller;
        private System.Windows.Forms.TextBox textBoxTXN;
        private System.Windows.Forms.Label labelTXNNo;
        private System.Windows.Forms.GroupBox groupBoxBlank;
        private System.Windows.Forms.GroupBox groupBoxVisualizer;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.GroupBox groupBoxTextView;
        private System.Windows.Forms.TextBox textBoxEventLog;

    }
}

