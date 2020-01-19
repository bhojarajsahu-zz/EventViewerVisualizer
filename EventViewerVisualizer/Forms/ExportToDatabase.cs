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
    public partial class ExportToDatabase : Form
    {
        List<string> transactionList;
        bool isOnlyRX = true;
        string databaseLocation = string.Empty;
        Utility newUtility;
        public ExportToDatabase()
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

        private void ExportToDatabase_Load(object sender, EventArgs e)
        {
            setGridData();
            textBoxDbDetails.Text = databaseLocation;
        }
        public void setGridData()
        {

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            listBoxTXNList.Items.Clear();

            dataGridView.Columns.Add("Status", "Status");
            dataGridView.Columns.Add("Transaction", "Transaction");
            dataGridView.Columns.Add("Type", "Type");
            dataGridView.Columns.Add("Output Number", "Output Number");
            dataGridView.Columns.Add("Order", "Order");
            dataGridView.Columns.Add("Message", "Message");

            dataGridView.Columns[2].ReadOnly = true;
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 50;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 80;
            dataGridView.Columns[4].Width = 50;

            foreach (string tranData in transactionList)
            {
                string TXNType = string.Empty;
                listBoxTXNList.Items.Add(tranData);
                string[] actualData = tranData.Split('"');

                if (isOnlyRX)
                {
                    if (tranData.IndexOf("- RX -") > 0)
                    {
                        TXNType = "RX";
                        dataGridView.Rows.Add("NA", tranData.Substring(0, 6).ToString(), TXNType, "", "", actualData[1].ToString());
                    }
                }
                else
                {
                    if (tranData.IndexOf("- RX -") > 0)
                        TXNType = "RX";
                    else if (tranData.IndexOf("- TX -") > 0)
                        TXNType = "TX";
                    else
                        TXNType = "";

                    dataGridView.Rows.Add("NA", tranData.Substring(0, 6).ToString(), TXNType, "", "", actualData[1].ToString());

                }
                //dataGridView.Rows.Add("060701", "", tranData);
            }
        }

        private void radioButtonRX_CheckedChanged(object sender, EventArgs e)
        {
            radioSelectionChanged();
        }
        public void radioSelectionChanged()
        {
            if (radioButtonRX.Checked)
                isOnlyRX = true;
            else
                isOnlyRX = false;

            setGridData();
        }

        private void radioButtonALL_CheckedChanged(object sender, EventArgs e)
        {
            radioSelectionChanged();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            bool errorStatus = false;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dataGridView.Rows[i].Cells[3].Value.ToString())
                    || string.IsNullOrEmpty(dataGridView.Rows[i].Cells[4].Value.ToString())
                    || string.IsNullOrEmpty(dataGridView.Rows[i].Cells[5].Value.ToString()))
                {
                    errorStatus = true;
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
            if (!errorStatus)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    newUtility = new Utility();
                    InputModel newModel = new InputModel();
                    newModel.Output_Tran_Code = dataGridView.Rows[i].Cells[3].Value.ToString();
                    newModel.Output_Tran_Stream = dataGridView.Rows[i].Cells[5].Value.ToString();
                    newModel.Output_Tran_Stream_Order = dataGridView.Rows[i].Cells[4].Value.ToString();
                    int status = newUtility.insertIntoSimulatorDB(textBoxDbDetails.Text, newModel);
                    if (status > 0)
                        dataGridView.Rows[i].Cells[0].Value = "Success";
                    else
                        dataGridView.Rows[i].Cells[0].Value = "Error";
                }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                int stat = 0;
                foreach (DataGridViewRow item in dataGridView.Rows)
                {
                    if (dataGridView.Rows[i].Cells[3].Value.ToString() == item.Cells[3].Value.ToString())
                        stat++;
                }
                if (stat > 1)
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                else
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxTXNList.Items.Clear();
            dataGridView.Rows.Clear();
            transactionList.Clear();
        }

        private void buttonImportFromFile_Click(object sender, EventArgs e)
        {
            listBoxTXNList.Items.Clear();
            dataGridView.Rows.Clear();
            transactionList.Clear();

            string location = string.Empty;
            DialogResult result = openFileDialogTXN.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                location = openFileDialogTXN.FileName;

            if (!string.IsNullOrEmpty(location))
            {
                try
                {
                    foreach (string line in File.ReadLines(location))
                    {
                        transactionList.Add(line);
                    }
                    setGridData();
                }
                catch { }
            }

        }
    }
}
