using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace EventViewerVisualizer
{
    static class XmlOperation
    {
        public static string Beautify(XmlDocument doc)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };
                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    doc.Save(writer);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string LoadFileToXML(string fileLoc, out XmlDocument outDoc)
        {
            string Destination = string.Empty;
            try
            {
                XmlDocument newDocument = new XmlDocument();
                string xmlText = File.ReadAllText(fileLoc);
                if (xmlText.Contains("xml version"))
                {
                    int position = xmlText.IndexOf("\r\n");
                    position += 2;
                    xmlText = xmlText.Remove(0, position);

                    //XmlDocument newDocument = new XmlDocument();
                    newDocument.LoadXml(xmlText);
                    Destination = XmlOperation.Beautify(newDocument);

                }
                outDoc = newDocument;
                return Destination;
            }
            catch
            {
                outDoc = null;
                return null;
            }
        }
    }
}
