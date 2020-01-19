namespace EventViewerVisualizer.Forms
{
    partial class TransactionListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionListView));
            this.panelControl = new System.Windows.Forms.Panel();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.panelButtonControl = new System.Windows.Forms.Panel();
            this.buttonExportDB = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxTransactionList = new System.Windows.Forms.GroupBox();
            this.listBoxTXNList = new System.Windows.Forms.ListBox();
            this.SaveFileDialogTXN = new System.Windows.Forms.SaveFileDialog();
            this.panelControl.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.panelButtonControl.SuspendLayout();
            this.groupBoxTransactionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.groupBoxControl);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 252);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(708, 100);
            this.panelControl.TabIndex = 0;
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.panelButtonControl);
            this.groupBoxControl.Controls.Add(this.textBox1);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 0);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(708, 100);
            this.groupBoxControl.TabIndex = 0;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Controls";
            // 
            // panelButtonControl
            // 
            this.panelButtonControl.Controls.Add(this.buttonExportDB);
            this.panelButtonControl.Controls.Add(this.buttonExport);
            this.panelButtonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonControl.Location = new System.Drawing.Point(438, 36);
            this.panelButtonControl.Name = "panelButtonControl";
            this.panelButtonControl.Size = new System.Drawing.Size(267, 61);
            this.panelButtonControl.TabIndex = 3;
            // 
            // buttonExportDB
            // 
            this.buttonExportDB.Location = new System.Drawing.Point(21, 23);
            this.buttonExportDB.Name = "buttonExportDB";
            this.buttonExportDB.Size = new System.Drawing.Size(100, 23);
            this.buttonExportDB.TabIndex = 2;
            this.buttonExportDB.Text = "Export To DB";
            this.buttonExportDB.UseVisualStyleBackColor = true;
            this.buttonExportDB.Click += new System.EventHandler(this.buttonExportDB_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(141, 23);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(100, 23);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export To File";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(702, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBoxTransactionList
            // 
            this.groupBoxTransactionList.Controls.Add(this.listBoxTXNList);
            this.groupBoxTransactionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTransactionList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTransactionList.Name = "groupBoxTransactionList";
            this.groupBoxTransactionList.Size = new System.Drawing.Size(708, 252);
            this.groupBoxTransactionList.TabIndex = 2;
            this.groupBoxTransactionList.TabStop = false;
            this.groupBoxTransactionList.Text = "Transaction List";
            // 
            // listBoxTXNList
            // 
            this.listBoxTXNList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTXNList.FormattingEnabled = true;
            this.listBoxTXNList.Location = new System.Drawing.Point(3, 16);
            this.listBoxTXNList.Name = "listBoxTXNList";
            this.listBoxTXNList.Size = new System.Drawing.Size(702, 233);
            this.listBoxTXNList.TabIndex = 2;
            this.listBoxTXNList.SelectedIndexChanged += new System.EventHandler(this.listBoxTXNList_SelectedIndexChanged);
            // 
            // SaveFileDialogTXN
            // 
            this.SaveFileDialogTXN.Filter = "Text File|*.txt";
            this.SaveFileDialogTXN.Title = "Select File Location";
            // 
            // TransactionListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 352);
            this.Controls.Add(this.groupBoxTransactionList);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransactionListView";
            this.Text = "Transaction List View";
            this.Load += new System.EventHandler(this.TransactionListView_Load);
            this.panelControl.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.panelButtonControl.ResumeLayout(false);
            this.groupBoxTransactionList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.GroupBox groupBoxTransactionList;
        private System.Windows.Forms.ListBox listBoxTXNList;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogTXN;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonExportDB;
        private System.Windows.Forms.Panel panelButtonControl;
    }
}