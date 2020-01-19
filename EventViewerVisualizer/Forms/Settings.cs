using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventViewerVisualizer.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            if (Utility.checkRegistryValue())
            {
                SettingData newSettData = new SettingData();
                newSettData = Utility.getSettingDetails();
                textBoxSystem.Text = newSettData.SystemName;
                textBoxTXNLocation.Text = newSettData.TXNPath;
                textBoxTeller.Text = newSettData.UserFilter;
                textBoxTXN.Text = newSettData.TXNFilter;
                textBoxDBDetails.Text = newSettData.DBDetails;
                textBoxLogName.Text = newSettData.LogName;
                textBoxSource.Text = newSettData.Source;
            }
            else
                textBoxSystem.Text = Utility.getSystemName();

        }
        private void textBoxTXNLocation_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialogTXNLocation.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                textBoxTXNLocation.Text = folderBrowserDialogTXNLocation.SelectedPath;
            else
                textBoxTXNLocation.Text = "";
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSystem.Text) && !string.IsNullOrEmpty(textBoxTXNLocation.Text))
            {
                SettingData newData = new SettingData();
                newData.SystemName = textBoxSystem.Text;
                newData.TXNPath = textBoxTXNLocation.Text;
                newData.UserFilter = textBoxTeller.Text;
                newData.TXNFilter = textBoxTXN.Text;
                newData.DBDetails = textBoxDBDetails.Text;
                newData.LogName = textBoxLogName.Text;
                newData.Source = textBoxSource.Text;

                Utility.updateRegistryValue(newData);
                this.Close();
                try
                {
                    Environment.Exit(0);
                }
                catch { }
            }
            else
                MessageBox.Show("Please fill the details.");

            //EventVisualizer parent = (EventVisualizer)this.Owner;
            //parent.updatetext();
            //parent.updatetext();
            //parent.updatetext();
            //parent.updatetext();
            this.Close();
        }

        private void groupBoxSettings_Enter(object sender, EventArgs e)
        {

        }
    }
}
