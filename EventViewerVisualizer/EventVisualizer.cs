using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using FrameWork.WorkFlowModel;
using System.Collections;
using FrameWork.Plugin;
using Library;

namespace EventViewerVisualizer
{
    public partial class EventVisualizer : Form
    {
        List<string> eventList = null;
        string actualMessage = string.Empty;
        string transactionNo = string.Empty;
        string TXorRX = string.Empty;
        XmlDocument rxXMLDoc = null;
        string TXNLocation = string.Empty;
        XmlDocument finalTransactionXML;
        List<string> transactionList;
        List<string> allTransactionList;
        SettingData settingData;

        private bool m_bAddIncludes = false;
        private int m_RXHostPosPointer = 78;
        private int m_RXHostMesgLength = 0;
        private string m_byteStream = null;
        private SettingsModel m_Settings = null;
        private CobolFormatLibrary cobolLibrary = new CobolFormatLibrary();


        public EventVisualizer()
        {
            InitializeComponent();
        }

        private void EventVisualizer_Load(object sender, EventArgs e)
        {
            transactionList = new List<string>();
            allTransactionList = new List<string>();
            if (Utility.checkRegistryValue())
            {
                fillSettingsDetails();
                //textBoxSystem.Text = Utility.getSystemName();
                getEventLog();
            }
            else
            {
                this.Enabled = false;
                using (Forms.Settings childform = new Forms.Settings())
                {
                    childform.ShowDialog(this);
                }
            }

            //EventQueryExample ex = new EventQueryExample();
            ////ex.QueryActiveLog();
            ////ex.QueryExternalFile();
            //ex.QueryRemoteComputer();
        }
        public void updatetext()
        {
            if (Utility.checkRegistryValue())
            {
                fillSettingsDetails();
                this.Enabled = true;
            }
            else
                Application.Exit();

        }
        public void fillSettingsDetails()
        {
            settingData = new SettingData();
            settingData = Utility.getSettingDetails();
            textBoxSystem.Text = settingData.SystemName;
            textBoxTXNLocation.Text = settingData.TXNPath;
            textBoxTeller.Text = settingData.UserFilter;
            textBoxTXN.Text = settingData.TXNFilter;
            textBoxDBDetails.Text = settingData.DBDetails;
            textBoxLogName.Text = settingData.LogName;
            textBoxSource.Text = settingData.Source;
        }

        public void getEventLog(bool ClearLog = false)
        {
            textBoxEventLog.Text = string.Empty;
            listBoxEvents.Items.Clear();
            listBoxAllEvents.Items.Clear();
            eventList = new List<string>();
            string eventLogName = (Utility.getSettingDetails()).LogName;//"FNSBANCSLink";
            string sourceName = (Utility.getSettingDetails()).Source; //"CFNSTCPSocket";//FNSBANCSLink
            string machineName = (Utility.getSettingDetails()).SystemName;//15/16/014
            EventLog eventLog;
            eventLog = new EventLog();
            eventLog.Log = eventLogName;
            eventLog.Source = sourceName;
            eventLog.MachineName = machineName;
            if (ClearLog == true)
            {
                eventLog.Clear();
                toolStripStatusLabelErrorStatus.Text = "Log cleared.";
            }
            else
            {
                try
                {
                    foreach (EventLogEntry log in eventLog.Entries)
                    {
                        allTransactionList.Add(log.Message);
                        listBoxAllEvents.Items.Add(log.EntryType + " - " + log.TimeGenerated + " - " + log.Source);

                        if (log.EntryType == EventLogEntryType.Information)
                        {
                            string tranNo = string.Empty;
                            string actMessage = getActualMessage(log.Message);
                            //actMessage = applyFilters(log.Message);
                            if (actMessage.Length > 60)
                            {

                                tranNo = actMessage.Substring(54, 6);
                                eventList.Add(log.Message);
                                string txRx = string.Empty;
                                if (log.Message.Contains("TX"))
                                {
                                    txRx = "TX";
                                    //m_RXHostPosPointer = 78;
                                }
                                if (log.Message.Contains("RX"))
                                {
                                    txRx = "RX";
                                    //m_RXHostPosPointer = 80;
                                }
                                transactionList.Add(tranNo + " - " + txRx + " - (" + log.TimeGenerated + ") \"" + actMessage + "\"");
                                listBoxEvents.Items.Add("(" + txRx + ")" + tranNo + "-" + log.TimeGenerated);
                                //listBoxEvents.Items.Add("(" + tranNo + ")" + log.Source + "/" + log.TimeGenerated);
                            }
                            //else
                            //    listBoxEvents.Items.Add(log.Source + "/" + log.TimeGenerated);

                            //Console.WriteLine("{0}\n", log.Source);
                        }
                    }
                    for (int i = 0; i < transactionList.Count; i++)
                    {
                        if (transactionList[i].IndexOf("O.K.") > 0)
                            textBoxEventLog.BackColor = Color.LightGreen;
                        else if (transactionList[i].IndexOf("ERROR") > 0)
                            textBoxEventLog.BackColor = Color.OrangeRed;
                        else
                            textBoxEventLog.BackColor = Color.White;

                    }
                }
                catch (Exception ex) { }
            }
        }
        public string getActualMessage(string message)
        {
            string actMessage = string.Empty;
            int index = 0;
            if (message.Contains(":"))
            {
                index = message.IndexOf(":") + 1;
                actMessage = message.Substring(index, message.Length - index);
            }
            return actMessage;

        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            transactionList = new List<string>();
            allTransactionList = new List<string>();
            textBoxEventText.Text = "";
            fillSettingsDetails();
            getEventLog();
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEventLog.BackColor = Color.White;

            int selectedIndex = listBoxEvents.SelectedIndex;
            textBoxDestination.Text = "";
            string message = Convert.ToString(eventList[selectedIndex]);
            if (message.Contains("Teller"))
            {
                textBoxEventLog.Text = message.Substring(message.IndexOf("Teller"), message.Length - message.IndexOf("Teller"));
                actualMessage = getActualMessage(textBoxEventLog.Text);
                if (actualMessage.Length > 60)
                    transactionNo = actualMessage.Substring(54, 6);
                else
                {
                    textBoxEventLog.Text = message;
                    transactionNo = "";
                }

                getFormattedOutput(actualMessage, transactionNo);

                string Destination = XmlOperation.Beautify(rxXMLDoc);
                textBoxDestination.Text = Destination;

                toolStripStatusLabelTransactionNumber.Text = "Transaction Number: " + transactionNo + "  | Date Time: " + listBoxEvents.SelectedItem.ToString().Substring(11, 22);
                if (string.IsNullOrEmpty(Destination))
                    toolStripStatusLabelErrorStatus.Text = "If you dont see anything on Visualizer, Please check the TXN path :)";
                else
                    toolStripStatusLabelErrorStatus.Text = "";
            }
        }
        public void getFormattedOutput(string actualMessage, string transactionNumber)
        {
            string TXNFilePath = string.Empty;
            XmlDocument transactionXML = null;

            TXNFilePath = Path.Combine(textBoxTXNLocation.Text, transactionNumber + ".xml");

            try
            {
                XmlDocument rxDoc = new XmlDocument();

                if (File.Exists(TXNFilePath))
                {
                    transactionXML = new XmlDocument();
                    transactionXML.Load(TXNFilePath);

                }
                else
                {
                    //Set the error model and return to main
                    throw new Exception("Settings model not found");
                }


                XmlDocument outputXml = new XmlDocument();
                XmlElement xmlOuterElement = outputXml.CreateElement("MessageGroup");
                outputXml.AppendChild(xmlOuterElement);


                //XmlDocument rxXMLDoc = null;
                if (textBoxEventLog.Text.Contains("TX"))
                {
                    TXorRX = "TX";
                    m_RXHostPosPointer = 78;
                }
                if (textBoxEventLog.Text.Contains("RX"))
                {
                    TXorRX = "RX";
                    m_RXHostPosPointer = 80;
                }

                //AddHeaderNodeToTXNxml(transactionXML);

                rxXMLDoc = ProcessRXXML(transactionXML, actualMessage, outputXml);
            }
            catch { }
        }
        //public void AddHeaderNodeToTXNxml(XmlDocument txnXML)
        //{
        //    string HeaderFilePath = string.Empty;
        //    XmlDocument HeaderXML = null;

        //    HeaderFilePath = Path.Combine(textBoxTXNLocation.Text, "Master73.xml");

        //    try
        //    {
        //        if (File.Exists(HeaderFilePath))
        //        {
        //            HeaderXML = new XmlDocument();
        //            HeaderXML.Load(HeaderFilePath);
        //        }
        //        else
        //        {
        //            //Set the error model and return to main
        //            throw new Exception("\"" + HeaderFilePath + "\" not found");
        //        }
        //    }
        //    catch { }


        //    finalTransactionXML = new XmlDocument();

        //    XmlNodeList headernodeList = HeaderXML.SelectSingleNode("/GROUP/RX").ChildNodes;

        //    foreach (XmlNode hNode in headernodeList)
        //    {
        //        string name = hNode.Name;
        //        if (String.Compare(name, "FIELD", false) == 0)
        //        {
        //            try
        //            {
        //                XmlNode xElt = xDoc.SelectSingleNode("//name[@ref=\"a2\"]");
        //                XmlElement xNewChild = xDoc.CreateElement("name");
        //                xNewChild.SetAttribute("ref", "b2");
        //                xNewChild.SetAttribute("type", "aaa");
        //                xDoc.DocumentElement.InsertAfter(xNewChild, xElt);

        //                txnXML.SelectSingleNode("/GROUP/" + TXorRX).AppendChild(hNode);
        //            }
        //            catch (Exception ex) { }
        //        }
        //    }


        //}
        #region NotSureCode
        /// <summary>
        /// Process XML
        /// </summary>
        /// <param name="transactionDefinition">transactionDefinition</param>
        /// <param name="responseByteStream">responseByteStream</param>
        /// <param name="outputXml">outputXml</param>
        /// <returns>XML Document</returns>
        public XmlDocument ProcessRXXML(XmlDocument transactionDefinition, string responseByteStream, XmlDocument outputXml)
        {
            try
            {
                m_byteStream = responseByteStream;
                m_RXHostMesgLength = Convert.ToInt32(m_byteStream.Substring(1, 4));

                //XmlDocument outputXml = new XmlDocument();
                //XmlElement xmlOuterElement = outputXml.CreateElement("MessageGroup");
                //outputXml.AppendChild(xmlOuterElement);

                XmlNode xmlOuterElement = outputXml.SelectSingleNode("MessageGroup");
                outputXml.AppendChild(xmlOuterElement);

                XmlElement xmlElement = outputXml.CreateElement("Message");
                xmlOuterElement.AppendChild(xmlElement);

                string tranNo = string.Empty;
                if (responseByteStream.Length > 60)
                    tranNo = responseByteStream.Substring(54, 6);

                XmlElement elem = outputXml.CreateElement("TranNo");
                elem.InnerText = tranNo;
                xmlElement.AppendChild(elem);

                XmlNode node = null;
                node = transactionDefinition.SelectSingleNode("/GROUP/" + TXorRX);
                if (node != null)
                {


                    IEnumerator enumerator = null;

                    enumerator = node.ChildNodes.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlNode tranNode = (XmlNode)enumerator.Current;
                        this.ProcessNode(tranNode, xmlElement, xmlElement);
                    }
                }
                else
                {
                    if (responseByteStream.IndexOf("O.K.") > 0)
                        textBoxEventLog.BackColor = Color.LightGreen;
                    else if (responseByteStream.IndexOf("ERROR") > 0)
                        textBoxEventLog.BackColor = Color.OrangeRed;
                    else
                        textBoxEventLog.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {

            }//finally
            return outputXml;
        }

        /// <summary>
        /// ProcessTXXML
        /// </summary>
        /// <param name="headerDoc">headerDoc</param>
        /// <param name="transactionDoc">transactionDoc</param>
        /// <param name="inputDataDoc">inputDataDoc</param>
        /// <returns>string</returns>
        public string ProcessTXXML(XmlDocument headerDoc, XmlDocument transactionDoc, XmlDocument inputDataDoc)
        {
            m_RXHostMesgLength = 0;
            //m_RXHostPosPointer = 78;
            m_byteStream = string.Empty;
            XmlNode node = headerDoc.SelectSingleNode("//GROUP[@ID='FNSTransactions73.CFNSHost']/" + TXorRX);
            XmlNode inputNode = inputDataDoc.SelectSingleNode("/" + TXorRX);
            IEnumerator enumerator = null;
            IEnumerator enumerator1 = null;
            IEnumerator enumerator2 = null;
            try
            {
                enumerator = node.ChildNodes.GetEnumerator();
                enumerator1 = inputNode.ChildNodes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator1.MoveNext();
                    XmlNode tranNode = (XmlNode)enumerator.Current;
                    m_byteStream += this.ProcessTXField(tranNode, (XmlNode)enumerator1.Current);
                }

                node = transactionDoc.SelectSingleNode("/GROUP/" + TXorRX);

                enumerator2 = node.ChildNodes.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    XmlNode tranNode = (XmlNode)enumerator2.Current;
                    m_byteStream += this.ProcessTXField(tranNode, (XmlNode)enumerator1.Current);
                    enumerator1.MoveNext();
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    ((IDisposable)enumerator).Dispose();
                }
                if (enumerator2 is IDisposable)
                {
                    ((IDisposable)enumerator2).Dispose();
                }
                if (enumerator1 is IDisposable)
                {
                    ((IDisposable)enumerator1).Dispose();
                }
            }

            return m_byteStream;
        }

        /// <summary>
        /// ProcessTXField
        /// </summary>
        /// <param name="CurrentField">CurrentField</param>
        /// <param name="inputData">inputData</param>
        /// <returns>string</returns>
        private string ProcessTXField(XmlNode CurrentField, XmlNode inputData)
        {
            string result = string.Empty;
            try
            {
                XmlNode namedItem = CurrentField.Attributes.GetNamedItem("ID");
                XmlNode formatItem = CurrentField.Attributes.GetNamedItem("Format");
                XmlNode offsetItem = CurrentField.Attributes.GetNamedItem("Offset");
                if (formatItem != null && namedItem != null)
                {
                    string DataByte = cobolLibrary.ConvertToByteString(inputData.InnerXml, formatItem.InnerText);

                    if (offsetItem != null)
                    {
                        int offset = Convert.ToInt32(offsetItem.InnerText);
                        if (offset > 0)
                        {
                            string offsetBytes = new string('0', offset);
                            DataByte = offsetBytes + DataByte;
                        }
                    }
                    result += DataByte;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("ProcessTXField: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessNode
        /// </summary>
        /// <param name="TranNode">TranNode</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <param name="DataNode">DataNode</param>
        private void ProcessNode(XmlNode TranNode, XmlNode MesgNode, XmlNode DataNode)
        {
            string name = TranNode.Name;
            IEnumerator enumerator = null;
            if (String.Compare(name, "FIELD", false) == 0)
            {
                MesgNode.AppendChild(this.ProcessField(TranNode, DataNode));
            }
            else if (String.Compare(name, "SELECT", false) == 0)
            {
                XmlNode xmlNode = this.ProcessSelect(TranNode, MesgNode);
                if (xmlNode != null)
                {
                    try
                    {
                        enumerator = xmlNode.ChildNodes.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            XmlNode tranNode = (XmlNode)enumerator.Current;
                            this.ProcessNode(tranNode, MesgNode, DataNode);
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                    }
                }
            }
            else if (String.Compare(name, "COLLECTION", false) == 0)
            {
                this.ProcessCollection(TranNode, MesgNode, DataNode);
            }
            else if (String.Compare(name, "SELECTINCLUDE", false) == 0)
            {
                XmlNode xmlNode = this.ProcessSelectInclude(TranNode, MesgNode);
                IEnumerator enumerator2 = null;
                if (xmlNode != null)
                {
                    try
                    {
                        enumerator2 = xmlNode.ChildNodes.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            XmlNode tranNode = (XmlNode)enumerator2.Current;
                            this.ProcessNode(tranNode, MesgNode, DataNode);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            ((IDisposable)enumerator2).Dispose();
                        }
                    }
                    if (this.m_bAddIncludes)
                    {
                        TranNode.ParentNode.InnerXml = xmlNode.InnerXml;
                    }
                }
            }
            else if (String.Compare(name, "INCLUDE", false) == 0)
            {
                XmlNode xmlNode = this.ProcessInclude(TranNode, MesgNode);
                IEnumerator enumerator3 = null;
                if (xmlNode != null)
                {
                    try
                    {
                        enumerator3 = xmlNode.ChildNodes.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                            XmlNode tranNode = (XmlNode)enumerator3.Current;
                            this.ProcessNode(tranNode, MesgNode, DataNode);
                        }
                    }
                    finally
                    {
                        if (enumerator3 is IDisposable)
                        {
                            ((IDisposable)enumerator3).Dispose();
                        }
                    }
                    if (this.m_bAddIncludes)
                    {
                        TranNode.ParentNode.InnerXml = xmlNode.InnerXml;
                    }
                }
            }
            else if (String.Compare(name, "GROUP", false) == 0)
            {
                IEnumerator enumerator4 = null;
                try
                {
                    enumerator4 = TranNode.ChildNodes.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        XmlNode tranNode = (XmlNode)enumerator4.Current;
                        this.ProcessNode(tranNode, MesgNode, DataNode);
                    }
                }
                finally
                {
                    if (enumerator4 is IDisposable)
                    {
                        ((IDisposable)enumerator4).Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// ProcessField
        /// </summary>
        /// <param name="CurrentField">CurrentField</param>
        /// <param name="DataNode">DataNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessField(XmlNode CurrentField, XmlNode DataNode)
        {
            XmlNode result;
            try
            {
                XmlNode namedItem = CurrentField.Attributes.GetNamedItem("ID");
                XmlNode formatItem = CurrentField.Attributes.GetNamedItem("Format");
                XmlNode offsetItem = CurrentField.Attributes.GetNamedItem("Offset");

                if (offsetItem != null)
                {
                    int offset = Convert.ToInt32(offsetItem.InnerText);
                    m_RXHostPosPointer += offset;
                }
                int txtLen = cobolLibrary.GetFormatStringLength(formatItem.InnerText);
                if (m_byteStream.Length < m_RXHostPosPointer + txtLen)
                {
                    int shortTxtLen = m_byteStream.Length - m_RXHostPosPointer;
                    int moreLength = txtLen - shortTxtLen;
                    CurrentField.InnerText = m_byteStream.Substring(m_RXHostPosPointer, shortTxtLen);

                    for (int i = 0; i < moreLength; i++)
                        CurrentField.InnerText = CurrentField.InnerText + " ";

                }
                else
                    CurrentField.InnerText = m_byteStream.Substring(m_RXHostPosPointer, txtLen);

                m_RXHostPosPointer += txtLen;

                XmlNode xmlNode2 = DataNode.OwnerDocument.CreateElement(namedItem.InnerText);
                xmlNode2.InnerText = CurrentField.InnerText;
                result = xmlNode2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessCollection
        /// </summary>
        /// <param name="CurrentSelect">CurrentSelect</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <param name="DataNode">DataNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessCollection(XmlNode CurrentSelect, XmlNode MesgNode, XmlNode DataNode)
        {
            XmlNode result = null;
            checked
            {
                try
                {
                    XmlNode namedItem = CurrentSelect.Attributes.GetNamedItem("NumSubParts");
                    int num = int.Parse(namedItem.InnerText);
                    XmlNode namedItem2 = CurrentSelect.Attributes.GetNamedItem("ID");

                    for (int i = 0; i <= (num - 1); i++)
                    {
                        XmlNode xmlNode = MesgNode.OwnerDocument.CreateElement(namedItem2.InnerText);
                        if (this.m_RXHostPosPointer < this.m_RXHostMesgLength)
                        {
                            MesgNode.AppendChild(xmlNode);
                        }
                        IEnumerator enumerator2 = null;
                        try
                        {
                            enumerator2 = CurrentSelect.ChildNodes.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
                                this.ProcessNode(xmlNode2, xmlNode, DataNode);
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                ((IDisposable)enumerator2).Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return result;
            }
        }

        /// <summary>
        /// ProcessSelect
        /// </summary>
        /// <param name="CurrentSelect">CurrentSelect</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessSelect(XmlNode CurrentSelect, XmlNode MesgNode)
        {

            StringBuilder stringBuilder = new StringBuilder();
            XmlNode result;
            try
            {
                XmlNode namedItem = CurrentSelect.Attributes.GetNamedItem("switch");
                XmlNode xmlNode = MesgNode.SelectSingleNode(namedItem.InnerText);
                stringBuilder.Append("CASE[@*=\"");
                string switchVal = "";
                if (xmlNode == null)
                    if (namedItem.InnerText == "Flag2")
                        stringBuilder.Append(m_byteStream.Substring(75, 1));
                    else
                        stringBuilder.Append(xmlNode.InnerText);
                stringBuilder.Append("\"]");
                XmlNode xmlNode2 = CurrentSelect.SelectSingleNode(stringBuilder.ToString());
                if (xmlNode2 == null)
                {
                    xmlNode2 = CurrentSelect.SelectSingleNode("CASEELSE");
                }
                result = xmlNode2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessSelectInclude
        /// </summary>
        /// <param name="CurrentInclude">CurrentInclude</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <returns>xmlDocument</returns>
        private XmlNode ProcessSelectInclude(XmlNode CurrentInclude, XmlNode MesgNode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode result;
            try
            {
                XmlNode namedItem = CurrentInclude.Attributes.GetNamedItem("switch");
                XmlNode xmlNode = MesgNode.SelectSingleNode(namedItem.InnerText);
                string str = xmlNode.InnerText + ".xml";
                if (File.Exists(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], str)))
                {
                    xmlDocument.Load(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], str));
                }

                if (xmlDocument == null)
                {
                    throw new Exception("could not find " + str);
                }
                XmlNode xmlNode2 = xmlDocument.SelectSingleNode("//" + TXorRX);
                if (xmlNode2 == null)
                {
                    xmlNode2 = xmlDocument.SelectSingleNode("//" + TXorRX);
                    if (xmlNode2 == null)
                    {
                        throw new Exception("could not find TX/RX node");
                    }
                }

                result = xmlNode2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessInclude
        /// </summary>
        /// <param name="CurrentInclude">CurrentInclude</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessInclude(XmlNode CurrentInclude, XmlNode MesgNode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode result;
            try
            {
                if (File.Exists(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], CurrentInclude.InnerText)))
                {
                    xmlDocument.Load(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], CurrentInclude.InnerText));
                }

                if (xmlDocument == null)
                {
                    throw new Exception("could not find " + CurrentInclude.InnerText);
                }
                XmlNode xmlNode = xmlDocument.SelectSingleNode("//" + TXorRX);
                if (xmlNode == null)
                {
                    xmlNode = xmlDocument.SelectSingleNode("//" + TXorRX);
                    if (xmlNode == null)
                    {
                        throw new Exception("could not find TX/RX node");
                    }
                }

                result = xmlNode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion

        private void buttonCLearLog_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelErrorStatus.Text = "";
            toolStripStatusLabelSelectedText.Text = "";
            toolStripStatusLabelTransactionNumber.Text = "";
            try
            {
                DialogResult yesNo = MessageBox.Show("Do you want to clear logs from \"" + textBoxSystem.Text + "\" ?", "Event Viewer Visualizer", MessageBoxButtons.YesNo);
                if (yesNo == System.Windows.Forms.DialogResult.Yes)
                {
                    getEventLog(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelErrorStatus.Text = ex.Message.ToString();
            }

            listBoxEvents.Items.Clear();
            listBoxAllEvents.Items.Clear();
            textBoxDestination.Text = "";
            textBoxEventLog.Text = "";
            textBoxEventText.Text = "";
            toolStripStatusLabelSelectedText.Text = "Selected Text";
            toolStripStatusLabelTransactionNumber.Text = "Transaction Number";

        }

        private void textBoxTXNLocation_Click(object sender, EventArgs e)
        {

            //DialogResult result = folderBrowserDialogTXNLocation.ShowDialog();
            //if (result == System.Windows.Forms.DialogResult.OK)
            //    textBoxTXNLocation.Text = folderBrowserDialogTXNLocation.SelectedPath;
            //else
            //    textBoxTXNLocation.Text = "";
        }

        private void buttonApplySettingsFilter_Click(object sender, EventArgs e)
        {
            Forms.Settings childform = new Forms.Settings();
            childform.Show();
        }
        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.Nodes[x];
                    addTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = xmlNode.OuterXml.Trim();
        }

        private void textBoxDestination_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // MessageBox.Show(.ToString());
                int selectedLineIndex = Convert.ToInt32(textBoxDestination.GetLineFromCharIndex(textBoxDestination.SelectionStart));
                int index = textBoxEventLog.Text.IndexOf(":") + 1;
                if (selectedLineIndex == 3)
                {
                    textBoxEventLog.SelectionStart = 54 + index;
                    textBoxEventLog.SelectionLength = 6;
                    toolStripStatusLabelSelectedText.Text = textBoxEventLog.SelectionLength + " Character Selected from Position " + textBoxEventLog.SelectionStart;
                    textBoxEventLog.Focus();
                }
                if (selectedLineIndex > 3)
                {
                    int indexLoc = 0;
                    int length = 0;
                    getActualPositionOfElement(rxXMLDoc, selectedLineIndex, out indexLoc, out length, 1);
                    if (TXorRX == "TX")
                        index = index + 78;
                    if (TXorRX == "RX")
                        index = index + 80;
                    textBoxEventLog.SelectionStart = indexLoc + index;
                    textBoxEventLog.SelectionLength = length;
                    toolStripStatusLabelSelectedText.Text = "Position " + textBoxEventLog.SelectionStart + " to " + textBoxEventLog.SelectionLength + " Character Selected";
                    textBoxEventLog.Focus();
                }
            }
            catch { }

        }
        public void getActualPositionOfElement(XmlNode doc, int selectedIndex, out int indexLoc, out int length, int counterValue)
        {
            indexLoc = 0;
            length = 0;
            int counter = 0;
            XmlNodeList nodeList = doc.SelectSingleNode("//Message").ChildNodes;
            bool lastNodeStatus = false;
            //List<string> myList = new List<string>();
            for (counter = counterValue; counter < selectedIndex - 3; counter++)
            {
                if (counter > 0)
                {
                    XmlNode node = nodeList[counter];
                    if (node != null)
                    {
                        string nodeValue = node.InnerText;
                        indexLoc = indexLoc + nodeValue.Length;
                        //if (node.Name.Contains("Collection"))
                        //{
                        //    //string nodeValue = node.InnerText;
                        //    //indexLoc = indexLoc + nodeValue.Length;
                        //    int abc = 0;
                        //    int def = 0;
                        //    getActualPositionOfElementForCollection(node, selectedIndex - counter - 1, out abc, out def, 0, out lastNodeStatus);
                        //    indexLoc = indexLoc + abc;
                        //    length = def;
                        //}
                        //else
                        //{
                        //    string nodeValue = node.InnerText;
                        //    indexLoc = indexLoc + nodeValue.Length;
                        //}
                    }
                }

            }
            XmlNode nodeFinal = nodeList[counter];
            if (nodeFinal != null)
            {
                string finalNodeValue = nodeFinal.InnerText;
                //finalNodeValue = finalNodeValue.Remove('+');
                length = CountTotalChars(finalNodeValue);
            }
        }
        public void getActualPositionOfElementForCollection(XmlNode doc, int selectedIndex, out int indexLoc, out int length, int counterValue, out bool lastNodeStatus)
        {
            indexLoc = 0;
            length = 0;
            int counter = 0;
            XmlNodeList nodeList = doc.ChildNodes;
            bool status = false;
            //List<string> myList = new List<string>();
            for (counter = counterValue; counter < selectedIndex - 3; counter++)
            {
                XmlNode node = nodeList[counter];
                string nodeValue = node.InnerText;
                indexLoc = indexLoc + nodeValue.Length;

            }
            if (!status)
            {
                XmlNode nodeFinal = nodeList[counter];
                string finalNodeValue = nodeFinal.InnerText;
                length = CountTotalChars(finalNodeValue);
                lastNodeStatus = true;
            }
            else
                lastNodeStatus = false;
        }
        public int CountTotalChars(string strInput)
        {
            int intCount = 0;
            foreach (char ch in strInput)
            {
                intCount++;
            }
            return intCount;
        }

        private void checkBoxShowFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowFilter.Checked)
                groupBoxFilter.Visible = true;
            else
                groupBoxFilter.Visible = false;

        }
        public string applyFilters(string data)
        {
            string formattedString = data;
            if (!string.IsNullOrEmpty(formattedString))
                if (!string.IsNullOrEmpty(textBoxTeller.Text))
                    if (data.Contains(textBoxTeller.Text))
                        formattedString = data;
                    else
                        formattedString = string.Empty;

            if (!string.IsNullOrEmpty(formattedString))
                if (!string.IsNullOrEmpty(textBoxTXN.Text))
                    if (data.Contains(textBoxTXN.Text))
                        formattedString = data;
                    else
                        formattedString = string.Empty;

            if (!string.IsNullOrEmpty(formattedString))
                if (!string.IsNullOrEmpty(textBoxDBDetails.Text))
                    if (data.Contains(textBoxDBDetails.Text))
                        formattedString = data;
                    else
                        formattedString = string.Empty;



            return formattedString;
        }

        private void checkBoxTransactionView_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTransactionView.Checked)
            {
                checkBoxTransactionView.Checked = false;
                Forms.TransactionListView newView = new Forms.TransactionListView();
                newView.setData(transactionList);
                newView.setDbDetails(settingData.DBDetails);
                newView.Show();
            }
        }

        private void textBoxEventLog_TextChanged(object sender, EventArgs e)
        {
            //textBoxDestination.Text = "";
            //string message = textBoxEventLog.Text;
            //if (message.Contains("Teller"))
            //{
            //    textBoxEventLog.Text = message.Substring(message.IndexOf("Teller"), message.Length - message.IndexOf("Teller"));
            //    actualMessage = getActualMessage(textBoxEventLog.Text);
            //    if (actualMessage.Length > 60)
            //        transactionNo = actualMessage.Substring(54, 6);
            //    else
            //    {
            //        textBoxEventLog.Text = message;
            //        transactionNo = "";
            //    }

            //    getFormattedOutput(actualMessage, transactionNo);

            //    string Destination = XmlOperation.Beautify(rxXMLDoc);
            //    textBoxDestination.Text = Destination;

            //    toolStripStatusLabelTransactionNumber.Text = "Transaction Number: " + transactionNo + "  | Date Time: " + listBoxEvents.SelectedItem.ToString().Substring(11, 22);
            //    if (string.IsNullOrEmpty(Destination))
            //        toolStripStatusLabelErrorStatus.Text = "If you dont see anything on Visualizer, Please check the TXN path :)";
            //    else
            //        toolStripStatusLabelErrorStatus.Text = "";
            //}
        }

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAll.Checked)
                splitContainerEvents.Panel2Collapsed = false;
            else
                splitContainerEvents.Panel2Collapsed = true;
        }

        private void listBoxAllEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBoxAllEvents.SelectedIndex;
                textBoxEventText.Text = "";
                string message = Convert.ToString(allTransactionList[selectedIndex]);
                textBoxEventText.Text = message;
            }
            catch { }
        }

        private void checkBoxExportDb_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxExportDb.Checked)
            {
                checkBoxExportDb.Checked = false;
                Forms.ExportToDatabase newView = new Forms.ExportToDatabase();
                newView.setData(transactionList);
                newView.setDbDetails(settingData.DBDetails);
                newView.Show();
            }
        }

    }
}
