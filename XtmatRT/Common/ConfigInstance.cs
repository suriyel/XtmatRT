using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XtmatRT
{
    public static class ConfigInstance
    {
        private static Dictionary<string, string> m_InstanceDic;
        private static List<string> m_MethodDlls;

        public static Dictionary<string, string> InstanceDic
        {
            get { return m_InstanceDic ?? (m_InstanceDic = GetConfig()); }
        }

        public static List<string> MethodDlls
        {
            get { return m_MethodDlls ?? (m_MethodDlls = GetMethodDlls()); }
        }

        private static List<string> GetMethodDlls()
        {
            var xdoc = new XmlDocument();
            xdoc.Load("MethodDll.xml");
            return xdoc.SelectNodes("Root")[0].SelectNodes("Dll").Cast<XmlNode>().Select(xmlNode => xmlNode.InnerText).ToList();
        }

        private static Dictionary<string, string> GetConfig()
        {
            var xdoc = new XmlDocument();
            xdoc.Load("Config.xml");
            return xdoc.SelectNodes("Root")[0].ChildNodes.Cast<XmlNode>().ToDictionary(childNode => childNode.Name, childNode => childNode.Attributes["Value"].ToString());
        }
    }
}
