namespace EventViewerVisualizer.Forms
{
    partial class ExportToDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportToDatabase));
            this.panelControl = new System.Windows.Forms.Panel();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelControlButton = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonImportFromFile = new System.Windows.Forms.Button();
            this.textBoxDbDetails = new System.Windows.Forms.TextBox();
            this.labelDBDetails = new System.Windows.Forms.Label();
            this.groupBoxTransactionList = new System.Windows.Forms.GroupBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.listBoxTXNList = new System.Windows.Forms.ListBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelTXNType = new System.Windows.Forms.Panel();
            this.radioButtonALL = new System.Windows.Forms.RadioButton();
            this.radioButtonRX = new System.Windows.Forms.RadioButton();
            this.labelTXNType = new System.Windows.Forms.Label();
            this.openFileDialogTXN = new System.Windows.Forms.OpenFileDialog();
            this.panelControl.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelControlButton.SuspendLayout();
            this.groupBoxTransactionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelTXNType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.groupBoxControl);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 315);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(899, 100);
            this.panelControl.TabIndex = 3;
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.panelButtons);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 0);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(899, 100);
            this.groupBoxControl.TabIndex = 0;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Controls";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonExport);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(696, 16);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(200, 81);
            this.panelButtons.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(50, 29);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(100, 23);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Export To DB";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelControlButton);
            this.groupBox1.Controls.Add(this.textBoxDbDetails);
            this.groupBox1.Controls.Add(this.labelDBDetails);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 83);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // panelControlButton
            // 
            this.panelControlButton.Controls.Add(this.buttonClear);
            this.panelControlButton.Controls.Add(this.buttonImportFromFile);
            this.panelControlButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControlButton.Location = new System.Drawing.Point(584, 49);
            this.panelControlButton.Name = "panelControlButton";
            this.panelControlButton.Size = new System.Drawing.Size(312, 31);
            this.panelControlButton.TabIndex = 5;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(180, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear Grid";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonImportFromFile
            // 
            this.buttonImportFromFile.Location = new System.Drawing.Point(55, 3);
            this.buttonImportFromFile.Name = "buttonImportFromFile";
            this.buttonImportFromFile.Size = new System.Drawing.Size(100, 23);
            this.buttonImportFromFile.TabIndex = 3;
            this.buttonImportFromFile.Text = "Import From File";
            this.buttonImportFromFile.UseVisualStyleBackColor = true;
            this.buttonImportFromFile.Click += new System.EventHandler(this.buttonImportFromFile_Click);
            // 
            // textBoxDbDetails
            // 
            this.textBoxDbDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxDbDetails.Location = new System.Drawing.Point(3, 29);
            this.textBoxDbDetails.Name = "textBoxDbDetails";
            this.textBoxDbDetails.ReadOnly = true;
            this.textBoxDbDetails.Size = new System.Drawing.Size(893, 20);
            this.textBoxDbDetails.TabIndex = 4;
            // 
            // labelDBDetails
            // 
            this.labelDBDetails.AutoSize = true;
            this.labelDBDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDBDetails.Location = new System.Drawing.Point(3, 16);
            this.labelDBDetails.Name = "labelDBDetails";
            this.labelDBDetails.Size = new System.Drawing.Size(91, 13);
            this.labelDBDetails.TabIndex = 3;
            this.labelDBDetails.Text = "Database Details:";
            // 
            // groupBoxTransactionList
            // 
            this.groupBoxTransactionList.Controls.Add(this.splitContainerMain);
            this.groupBoxTransactionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTransactionList.Location = new System.Drawing.Point(0, 83);
            this.groupBoxTransactionList.Name = "groupBoxTransactionList";
            this.groupBoxTransactionList.Size = new System.Drawing.Size(899, 232);
            this.groupBoxTransactionList.TabIndex = 6;
            this.groupBoxTransactionList.TabStop = false;
            this.groupBoxTransactionList.Text = "Transaction List";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 16);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.listBoxTXNList);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dataGridView);
            this.splitContainerMain.Panel2.Controls.Add(this.panelTXNType);
            this.splitContainerMain.Size = new System.Drawing.Size(893, 213);
            this.splitContainerMain.SplitterDistance = 106;
            this.splitContainerMain.TabIndex = 3;
            // 
            // listBoxTXNList
            // 
            this.listBoxTXNList.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxTXNList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTXNList.FormattingEnabled = true;
            this.listBoxTXNList.Location = new System.Drawing.Point(0, 0);
            this.listBoxTXNList.Name = "listBoxTXNList";
            this.listBoxTXNList.Size = new System.Drawing.Size(893, 106);
            this.listBoxTXNList.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 34);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(893, 69);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // panelTXNType
            // 
            this.panelTXNType.Controls.Add(this.radioButtonALL);
            this.panelTXNType.Controls.Add(this.radioButtonRX);
            this.panelTXNType.Controls.Add(this.labelTXNType);
            this.panelTXNType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTXNType.Location = new System.Drawing.Point(0, 0);
            this.panelTXNType.Name = "panelTXNType";
            this.panelTXNType.Size = new System.Drawing.Size(893, 34);
            this.panelTXNType.TabIndex = 0;
            // 
            // radioButtonALL
            // 
            this.radioButtonALL.AutoSize = true;
            this.radioButtonALL.Location = new System.Drawing.Point(222, 9);
            this.radioButtonALL.Name = "radioButtonALL";
            this.radioButtonALL.Size = new System.Drawing.Size(44, 17);
            this.radioButtonALL.TabIndex = 2;
            this.radioButtonALL.Text = "ALL";
            this.radioButtonALL.UseVisualStyleBackColor = true;
            this.radioButtonALL.CheckedChanged += new System.EventHandler(this.radioButtonALL_CheckedChanged);
            // 
            // radioButtonRX
            // 
            this.radioButtonRX.AutoSize = true;
            this.radioButtonRX.Checked = true;
            this.radioButtonRX.Location = new System.Drawing.Point(163, 9);
            this.radioButtonRX.Name = "radioButtonRX";
            this.radioButtonRX.Size = new System.Drawing.Size(40, 17);
            this.radioButtonRX.TabIndex = 1;
            this.radioButtonRX.TabStop = true;
            this.radioButtonRX.Text = "RX";
            this.radioButtonRX.UseVisualStyleBackColor = true;
            this.radioButtonRX.CheckedChanged += new System.EventHandler(this.radioButtonRX_CheckedChanged);
            // 
            // labelTXNType
            // 
            this.labelTXNType.AutoSize = true;
            this.labelTXNType.Location = new System.Drawing.Point(9, 11);
            this.labelTXNType.Name = "labelTXNType";
            this.labelTXNType.Size = new System.Drawing.Size(139, 13);
            this.labelTXNType.TabIndex = 0;
            this.labelTXNType.Text = "Transaction Type To Export";
            // 
            // openFileDialogTXN
            // 
            this.openFileDialogTXN.FileName = "openFileDialog1";
            // 
            // ExportToDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 415);
            this.Controls.Add(this.groupBoxTransactionList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportToDatabase";
            this.Text = "ExportToDatabase";
            this.Load += new System.EventHandler(this.ExportToDatabase_Load);
            this.panelControl.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelControlButton.ResumeLayout(false);
            this.groupBoxTransactionList.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelTXNType.ResumeLayout(false);
            this.panelTXNType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxTransactionList;
        private System.Windows.Forms.TextBox textBoxDbDetails;
        private System.Windows.Forms.Label labelDBDetails;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelControlButton;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonImportFromFile;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ListBox listBoxTXNList;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelTXNType;
        private System.Windows.Forms.RadioButton radioButtonALL;
        private System.Windows.Forms.RadioButton radioButtonRX;
        private System.Windows.Forms.Label labelTXNType;
        private System.Windows.Forms.OpenFileDialog openFileDialogTXN;
    }
}