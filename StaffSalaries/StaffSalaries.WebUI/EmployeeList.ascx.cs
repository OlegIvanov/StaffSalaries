using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using StaffSalaries.WebUI.EmployeeListControl;
using StaffSalaries.Presentation;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.WebUI
{
    public partial class EmployeeList : System.Web.UI.UserControl
    {
        [Category("Config")]
        [Browsable(true)]
        [UrlProperty("*.xml")]
        public string XmlConfigFile { get; set; }

        private string _employeeListControlConfigurationKey = "Config";
        private string _sortByColumnKey = "SortBy";
        private string _orderByColumnKey = "OrderBy";

        private IEmployeeListPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            Configuration config = (Configuration)ViewState[_employeeListControlConfigurationKey];
            if (config == null)
            {
                config = ConfigurationFactory.GetConfiguration(XmlConfigFile);
                ViewState[_employeeListControlConfigurationKey] = config;
            }

            _presenter = new EmployeeListPresenter();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                Configuration config = (Configuration)ViewState[_employeeListControlConfigurationKey];

                gwEmployeeList.PageSize = config.PageSize;
                gwEmployeeList.Columns[2].Visible = config.IsEditable;

                ViewState[_sortByColumnKey] = EmployeesSortBy.None;
                ViewState[_orderByColumnKey] = EmployeesOrderBy.None;
            }
        }
    }
}