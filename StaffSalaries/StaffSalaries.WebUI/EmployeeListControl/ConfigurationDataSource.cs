using System.Xml.Serialization;

namespace StaffSalaries.WebUI.EmployeeListControl
{
    public class ConfigurationDataSource
    {
        [XmlAttribute("type")]
        public ConfigurationDataSourceType Type { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }
    }
}