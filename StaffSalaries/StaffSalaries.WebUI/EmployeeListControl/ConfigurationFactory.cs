using System.IO;
using System.Web;
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
                XmlSerializer deserializer = new XmlSerializer(typeof (Configuration));
                return (Configuration) deserializer.Deserialize(textReader);
            }
        }
    }
}