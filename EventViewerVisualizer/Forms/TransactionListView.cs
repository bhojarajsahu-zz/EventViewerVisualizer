using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventViewerVisualizer.Forms
{
    public partial class TransactionListView : Form
    {
        List<string> transactionList;
        string fileListLocation = string.Empty;
        string databaseLocation = string.Empty;
        public TransactionListView()
        {
            InitializeComponent();
        }
        public void setData(List<string> transList)
        {
            transactionList = new List<string>();
            transactionList = transList;
        }

        public void setDbDetails(string DbDetails)
        {
            databaseLocation = DbDetails;
        }
        private void buttonExport_Click(object sender, EventArgs e)
        {
            DialogResult result = SaveFileDialogTXN.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                fileListLocation = SaveFileDialogTXN.FileName + ".txt";
                try
                {
                    if (!File.Exists(fileListLocation))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(fileListLocation))
                        {
                            foreach (string tranData in transactionList)
                            {
                                sw.WriteLine(tranData);// + Environment.NewLine
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("File already exists. Please choose another name.");
                    }
                }
                catch { }
            }
        }

        private void TransactionListView_Load(object sender, EventArgs e)
        {
            foreach (string tranData in transactionList)
                listBoxTXNList.Items.Add(tranData);
        }

        private void listBoxTXNList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selValue = listBoxTXNList.SelectedItem.ToString();
            //listBoxTXNList.SelectedItem.ToString().Substring(41, listBoxTXNList.SelectedItem.ToString().Length - 42);
            textBox1.Text = selValue.Substring(41, selValue.Length - 42);
        }

        private void buttonExportDB_Click(object sender, EventArgs e)
        {
            Forms.ExportToDatabase newView = new Forms.ExportToDatabase();
            newView.setData(transactionList);
            newView.setDbDetails(databaseLocation);
            newView.Show();
        }
    }
}
