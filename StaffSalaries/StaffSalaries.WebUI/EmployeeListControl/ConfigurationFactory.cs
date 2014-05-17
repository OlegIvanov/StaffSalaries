using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Serialization;

namespace StaffSalaries.WebUI.EmployeeListControl
{
    public static class ConfigurationFactory
    {
        public static Configuration GetConfiguration(string xmlConfigFile)
        {
            string absolutePhysycalFilePath = HttpContext.Current.Server.MapPath(xmlConfigFile);
     
            using (TextReader textReader = new StreamReader(absolutePhysycalFilePath))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
                return (Configuration)deserializer.Deserialize(textReader);
            }
        }
    }
}