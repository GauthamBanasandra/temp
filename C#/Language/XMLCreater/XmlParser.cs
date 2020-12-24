using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLCreator
{
    public class XmlParser
    {
        public static string ExtractCompatibilityReportPath(string xmlStr)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlStr);
            var node = xmlDocument.GetElementsByTagName("compatibility-pdf-path");
            return node[0].InnerText;
        }
    }
}
