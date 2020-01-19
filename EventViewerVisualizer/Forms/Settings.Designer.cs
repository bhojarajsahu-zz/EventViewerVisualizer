namespace EventViewerVisualizer.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLogName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDBDetails = new System.Windows.Forms.TextBox();
            this.labelDB = new System.Windows.Forms.Label();
            this.textBoxTXN = new System.Windows.Forms.TextBox();
            this.labelTXN = new System.Windows.Forms.Label();
            this.textBoxTeller = new System.Windows.Forms.TextBox();
            this.labelTeller = new System.Windows.Forms.Label();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.textBoxTXNLocation = new System.Windows.Forms.TextBox();
            this.labelTXNLocation = new System.Windows.Forms.Label();
            this.textBoxSystem = new System.Windows.Forms.TextBox();
            this.labelSystem = new System.Windows.Forms.Label();
            this.folderBrowserDialogTXNLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.textBoxSource);
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Controls.Add(this.textBoxLogName);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.textBoxDBDetails);
            this.groupBoxSettings.Controls.Add(this.labelDB);
            this.groupBoxSettings.Controls.Add(this.textBoxTXN);
            this.groupBoxSettings.Controls.Add(this.labelTXN);
            this.groupBoxSettings.Controls.Add(this.textBoxTeller);
            this.groupBoxSettings.Controls.Add(this.labelTeller);
            this.groupBoxSettings.Controls.Add(this.buttonSaveSettings);
            this.groupBoxSettings.Controls.Add(this.textBoxTXNLocation);
            this.groupBoxSettings.Controls.Add(this.labelTXNLocation);
            this.groupBoxSettings.Controls.Add(this.textBoxSystem);
            this.groupBoxSettings.Controls.Add(this.labelSystem);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(514, 291);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            this.groupBoxSettings.Enter += new System.EventHandler(this.groupBoxSettings_Enter);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(175, 152);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(165, 20);
            this.textBoxSource.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Source:";
            // 
            // textBoxLogName
            // 
            this.textBoxLogName.Location = new System.Drawing.Point(175, 126);
            this.textBoxLogName.Name = "textBoxLogName";
            this.textBoxLogName.Size = new System.Drawing.Size(165, 20);
            this.textBoxLogName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Log Name:";
            // 
            // textBoxDBDetails
            // 
            this.textBoxDBDetails.Location = new System.Drawing.Point(175, 178);
            this.textBoxDBDetails.Name = "textBoxDBDetails";
            this.textBoxDBDetails.Size = new System.Drawing.Size(301, 20);
            this.textBoxDBDetails.TabIndex = 14;
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Location = new System.Drawing.Point(112, 181);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(57, 13);
            this.labelDB.TabIndex = 13;
            this.labelDB.Text = "DB Details";
            // 
            // textBoxTXN
            // 
            this.textBoxTXN.Location = new System.Drawing.Point(175, 100);
            this.textBoxTXN.Name = "textBoxTXN";
            this.textBoxTXN.Size = new System.Drawing.Size(301, 20);
            this.textBoxTXN.TabIndex = 12;
            // 
            // labelTXN
            // 
            this.labelTXN.AutoSize = true;
            this.labelTXN.Location = new System.Drawing.Point(125, 103);
            this.labelTXN.Name = "labelTXN";
            this.labelTXN.Size = new System.Drawing.Size(54, 13);
            this.labelTXN.TabIndex = 11;
            this.labelTXN.Text = "TXNFilter:";
            // 
            // textBoxTeller
            // 
            this.textBoxTeller.Location = new System.Drawing.Point(175, 74);
            this.textBoxTeller.Name = "textBoxTeller";
            this.textBoxTeller.Size = new System.Drawing.Size(301, 20);
            this.textBoxTeller.TabIndex = 10;
            // 
            // labelTeller
            // 
            this.labelTeller.AutoSize = true;
            this.labelTeller.Location = new System.Drawing.Point(125, 77);
            this.labelTeller.Name = "labelTeller";
            this.labelTeller.Size = new System.Drawing.Size(36, 13);
            this.labelTeller.TabIndex = 9;
            this.labelTeller.Text = "Teller:";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(367, 256);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(135, 23);
            this.buttonSaveSettings.TabIndex = 8;
            this.buttonSaveSettings.Text = "Save Settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // textBoxTXNLocation
            // 
            this.textBoxTXNLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxTXNLocation.Location = new System.Drawing.Point(175, 48);
            this.textBoxTXNLocation.Name = "textBoxTXNLocation";
            this.textBoxTXNLocation.Size = new System.Drawing.Size(301, 20);
            this.textBoxTXNLocation.TabIndex = 7;
            this.textBoxTXNLocation.Click += new System.EventHandler(this.textBoxTXNLocation_Click);
            // 
            // labelTXNLocation
            // 
            this.labelTXNLocation.AutoSize = true;
            this.labelTXNLocation.Location = new System.Drawing.Point(40, 51);
            this.labelTXNLocation.Name = "labelTXNLocation";
            this.labelTXNLocation.Size = new System.Drawing.Size(129, 13);
            this.labelTXNLocation.TabIndex = 6;
            this.labelTXNLocation.Text = "Transaction File Location:";
            // 
            // textBoxSystem
            // 
            this.textBoxSystem.Location = new System.Drawing.Point(175, 22);
            this.textBoxSystem.Name = "textBoxSystem";
            this.textBoxSystem.Size = new System.Drawing.Size(301, 20);
            this.textBoxSystem.TabIndex = 2;
            // 
            // labelSystem
            // 
            this.labelSystem.AutoSize = true;
            this.labelSystem.Location = new System.Drawing.Point(125, 25);
            this.labelSystem.Name = "labelSystem";
            this.labelSystem.Size = new System.Drawing.Size(44, 13);
            this.labelSystem.TabIndex = 1;
            this.labelSystem.Text = "System:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 291);
            this.Controls.Add(this.groupBoxSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(530, 325);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 325);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TextBox textBoxTXNLocation;
        private System.Windows.Forms.Label labelTXNLocation;
        private System.Windows.Forms.TextBox textBoxSystem;
        private System.Windows.Forms.Label labelSystem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTXNLocation;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.TextBox textBoxTeller;
        private System.Windows.Forms.Label labelTeller;
        private System.Windows.Forms.TextBox textBoxDBDetails;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.TextBox textBoxTXN;
        private System.Windows.Forms.Label labelTXN;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLogName;
        private System.Windows.Forms.Label label1;
    }
}