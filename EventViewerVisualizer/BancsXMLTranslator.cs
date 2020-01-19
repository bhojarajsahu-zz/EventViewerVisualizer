using Framework.Logging;
using FrameWork.CobolLibrary;
using FrameWork.WorkFlowModel;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace FrameWork.Plugin
{
    /// <summary>
    /// BancsXMLTranslator used for XMl translator
    /// </summary>
    public class BancsXMLTranslator
    {
        private static readonly ILog log = LogManager.GetLog(typeof(BancsXMLTranslator));
        private bool m_bAddIncludes = false;
        private int m_RXHostPosPointer = 80;
        private int m_RXHostMesgLength = 0;
        private string m_byteStream = null;
        private SettingsModel m_Settings = null;
        private CobolFormatLibrary cobolLibrary = new CobolFormatLibrary();

        /// <summary>
        /// XML to byte translator
        /// </summary>
        /// <param name="settings">Settings Model</param>
        public BancsXMLTranslator()
        {

        }

        /// <summary>
        /// Process XML
        /// </summary>
        /// <param name="transactionDefinition">transactionDefinition</param>
        /// <param name="responseByteStream">responseByteStream</param>
        /// <param name="outputXml">outputXml</param>
        /// <returns>XML Document</returns>
        public XmlDocument ProcessRXXML(XmlDocument transactionDefinition, string responseByteStream, XmlDocument outputXml)
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

            XmlNode node = transactionDefinition.SelectSingleNode("/GROUP/RX");
            IEnumerator enumerator = null;
            try
            {
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
                enumerator = node.ChildNodes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XmlNode tranNode = (XmlNode)enumerator.Current;
                    this.ProcessNode(tranNode, xmlElement, xmlElement);
                }
            }
            catch (Exception ex)
            {
                log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
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
            m_byteStream = string.Empty;
            XmlNode node = headerDoc.SelectSingleNode("//GROUP[@ID='FNSTransactions73.CFNSHost']/TX");
            XmlNode inputNode = inputDataDoc.SelectSingleNode("/TX");
            IEnumerator enumerator = null;
            IEnumerator enumerator1 = null;
            IEnumerator enumerator2 = null;
            try
            {
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
                enumerator = node.ChildNodes.GetEnumerator();
                enumerator1 = inputNode.ChildNodes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator1.MoveNext();
                    XmlNode tranNode = (XmlNode)enumerator.Current;
                    m_byteStream += this.ProcessTXField(tranNode, (XmlNode)enumerator1.Current);
                }

                node = transactionDoc.SelectSingleNode("/GROUP/TX");

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
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
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
                        log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                        log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                        log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                    log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
                XmlNode namedItem = CurrentField.Attributes.GetNamedItem("ID");
                XmlNode formatItem = CurrentField.Attributes.GetNamedItem("Format");
                XmlNode offsetItem = CurrentField.Attributes.GetNamedItem("Offset");

                if (offsetItem != null)
                {
                    int offset = Convert.ToInt32(offsetItem.InnerText);
                    m_RXHostPosPointer += offset;
                }
                int txtLen = cobolLibrary.GetFormatStringLength(formatItem.InnerText);
                CurrentField.InnerText = m_byteStream.Substring(m_RXHostPosPointer, txtLen);
                m_RXHostPosPointer += txtLen;

                XmlNode xmlNode2 = DataNode.OwnerDocument.CreateElement(namedItem.InnerText);
                xmlNode2.InnerText = CurrentField.InnerText;
                result = xmlNode2;
            }
            catch (Exception ex)
            {
                log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
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
                    log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                            log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                    log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
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
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
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
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
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
                XmlNode xmlNode2 = xmlDocument.SelectSingleNode("//RX");
                if (xmlNode2 == null)
                {
                    xmlNode2 = xmlDocument.SelectSingleNode("//TX");
                    if (xmlNode2 == null)
                    {
                        throw new Exception("could not find TX/RX node");
                    }
                }

                result = xmlNode2;
            }
            catch (Exception ex)
            {
                log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
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
                log.Info(this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name + " Entered");
                if (File.Exists(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], CurrentInclude.InnerText)))
                {
                    xmlDocument.Load(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], CurrentInclude.InnerText));
                }

                if (xmlDocument == null)
                {
                    throw new Exception("could not find " + CurrentInclude.InnerText);
                }
                XmlNode xmlNode = xmlDocument.SelectSingleNode("//RX");
                if (xmlNode == null)
                {
                    xmlNode = xmlDocument.SelectSingleNode("//TX");
                    if (xmlNode == null)
                    {
                        throw new Exception("could not find TX/RX node");
                    }
                }

                result = xmlNode;
            }
            catch (Exception ex)
            {
                log.Fatal("In Method " + MethodBase.GetCurrentMethod().Name + " - " + ex, ex.Message);
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}