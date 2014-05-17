using System.Xml.Serialization;

namespace StaffSalaries.WebUI.EmployeeListControl
{
    [XmlRoot("Config")]
    public class Configuration
    {
        [XmlElement("DataSource")]
        public ConfigurationDataSource DataSource { get; set; }

        [XmlElement("PageSize")]
        public int PageSize { get; set; }

        [XmlElement("IsEditable")]
        public bool IsEditable { get; set; }
    }
}