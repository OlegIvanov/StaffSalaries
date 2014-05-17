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
    public partial class EmployeeList : System.Web.UI.UserControl, IEmployeeListView
    {
        [Category("Config")]
        [Browsable(true)]
        [UrlProperty("*.xml")]
        public string XmlConfigFile { get; set; }

        private string _employeeListControlConfigurationKey = "Config";
        private string _sortByKey = "SortBy";
        private string _orderByKey = "OrderBy";

        private IEmployeeListPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new EmployeeListPresenter();

            Configuration config = (Configuration) ViewState[_employeeListControlConfigurationKey];
            if (config == null)
            {
                config = ConfigurationFactory.GetConfiguration(XmlConfigFile);
                ViewState[_employeeListControlConfigurationKey] = config;
            }

            ddlJobList.DataBound += new EventHandler(ddlJobList_DataBound);
            ddlJobList.SelectedIndexChanged += new EventHandler(ddlJobList_SelectedIndexChanged);

            gvEmployeeList.RowCommand += new GridViewCommandEventHandler(gvEmployeeList_RowCommand);
            gvEmployeeList.PageIndexChanging += new GridViewPageEventHandler(gvEmployeeList_PageIndexChanging);
            gvEmployeeList.RowEditing += new GridViewEditEventHandler(gvEmployeeList_RowEditing);
            gvEmployeeList.RowCancelingEdit += new GridViewCancelEditEventHandler(gvEmployeeList_RowCancelingEdit);
            gvEmployeeList.RowUpdating += new GridViewUpdateEventHandler(gvEmployeeList_RowUpdating);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Configuration config = (Configuration) ViewState[_employeeListControlConfigurationKey];

                gvEmployeeList.PageSize = config.PageSize;
                gvEmployeeList.Columns[2].Visible = config.IsEditable;

                ViewState[_sortByKey] = EmployeesSortBy.None;
                ViewState[_orderByKey] = EmployeesOrderBy.None;

                _presenter.DisplayJobList();
            }
        }

        protected void ddlJobList_DataBound(object sender, EventArgs e)
        {
            _presenter.DisplayEmployeeList();
        }

        protected void ddlJobList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropEditMode();
            DropPagination();

            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SortAndOrderByFullName")
                SortAndOrderBy(EmployeesSortBy.FullName);

            if (e.CommandName == "SortAndOrderBySalary")
                SortAndOrderBy(EmployeesSortBy.Salary);

            DropEditMode();
            DropPagination();

            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DropEditMode();

            gvEmployeeList.PageIndex = e.NewPageIndex;
        }

        protected void gvEmployeeList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployeeList.EditIndex = e.NewEditIndex;

            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DropEditMode();

            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            _presenter.UpdateEmployeeSalary();

            DropEditMode();

            _presenter.DisplayEmployeeList();
        }

        private void DropPagination()
        {
            gvEmployeeList.PageIndex = 0;
        }

        private void DropEditMode()
        {
            gvEmployeeList.EditIndex = -1;
        }

        private void SortAndOrderBy(EmployeesSortBy newSortBy)
        {
            EmployeesSortBy sortBy = (EmployeesSortBy) ViewState[_sortByKey];

            ViewState[_sortByKey] = newSortBy;

            ChangeColumnOrdering(sortBy != newSortBy);
        }

        private void ChangeColumnOrdering(bool hasChangedColumn)
        {
            EmployeesOrderBy orderBy = (EmployeesOrderBy) ViewState[_orderByKey];

            if (hasChangedColumn)
            {
                ViewState[_orderByKey] = EmployeesOrderBy.Ascending;
                return;
            }

            switch (orderBy)
            {
                case EmployeesOrderBy.None:
                    ViewState[_orderByKey] = EmployeesOrderBy.Ascending;
                    break;
                case EmployeesOrderBy.Ascending:
                    ViewState[_orderByKey] = EmployeesOrderBy.Descending;
                    break;
                case EmployeesOrderBy.Descending:
                    ViewState[_orderByKey] = EmployeesOrderBy.Ascending;
                    break;
            }
        }

        public int JobId
        {
            get { return int.Parse(ddlJobList.SelectedValue); }
        }

        public EmployeesSortBy SortBy
        {
            get { return (EmployeesSortBy) ViewState[_sortByKey]; }
        }

        public EmployeesOrderBy OrderBy
        {
            get { return (EmployeesOrderBy) ViewState[_orderByKey]; }
        }

        public int PageSize
        {
            get
            {
                Configuration config = (Configuration) ViewState[_employeeListControlConfigurationKey];
                return config.PageSize;
            }
        }

        public int PageIndex
        {
            get { return gvEmployeeList.PageIndex; }
        }

        public int EmployeeId
        {
            get
            {
                HiddenField hfEmployeeId =
                    (HiddenField) gvEmployeeList.Rows[gvEmployeeList.EditIndex].FindControl("hfEmployeeId");
                return int.Parse(hfEmployeeId.Value);
            }
        }

        public decimal Salary
        {
            get
            {
                TextBox tbSalary = (TextBox) gvEmployeeList.Rows[gvEmployeeList.EditIndex].FindControl("tbSalary");
                return decimal.Parse(tbSalary.Text);
            }
        }
    }
}