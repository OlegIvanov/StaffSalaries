using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffSalaries.Facade;
using StaffSalaries.Facade.ViewModels;
using StaffSalaries.Model.Employees;
using StaffSalaries.Presentation;
using StaffSalaries.WebUI.EmployeeListControl;

namespace StaffSalaries.WebUI
{
    public partial class EmployeeList : UserControl, IEmployeeListView
    {
        [Category("Config")]
        [Browsable(true)]
        [UrlProperty("*.xml")]
        public string XmlConfigFile { get; set; }

        private readonly string _configKey = "Config";

        private readonly string _sortByKey = "SortBy";
        private readonly string _orderByKey = "OrderBy";

        private readonly string _pageIndexKey = "PageIndex";
        private readonly string _totalNumberOfRowsKey = "TotalNumberOfRows";

        private IEmployeeListPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            Configuration config = (Configuration) ViewState[_configKey];
            if (config == null)
            {
                config = ConfigurationFactory.GetConfiguration(XmlConfigFile);
                ViewState[_configKey] = config;
            }

            _presenter = new EmployeeListPresenter(this, EmployeeListControlDataSourceResolverFactory.GetConfiguredIoCContainer(config).GetInstance<IEmployeeJobServiceFacade>());

            ddlJobList.DataBound += ddlJobList_DataBound;
            ddlJobList.SelectedIndexChanged += ddlJobList_SelectedIndexChanged;

            gvEmployeeList.RowCommand += gvEmployeeList_RowCommand;
            gvEmployeeList.RowEditing += gvEmployeeList_RowEditing;
            gvEmployeeList.RowCancelingEdit += gvEmployeeList_RowCancelingEdit;
            gvEmployeeList.RowUpdating += gvEmployeeList_RowUpdating;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Configuration config = (Configuration) ViewState[_configKey];

                gvEmployeeList.PageSize = config.PageSize;
                gvEmployeeList.Columns[2].Visible = config.IsEditable;

                ViewState[_sortByKey] = EmployeesSortBy.None;
                ViewState[_orderByKey] = EmployeesOrderBy.None;
                ViewState[_pageIndexKey] = 0;

                _presenter.DisplayJobList();
            }

            CreatePagingControl();
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
            if (e.CommandName == "SortAndOrderByFullName" ||
                e.CommandName == "SortAndOrderBySalary")
            {
                switch (e.CommandName)
                {
                    case "SortAndOrderByFullName":
                    {
                        SortAndOrderBy(EmployeesSortBy.FullName);
                        break;
                    }
                    case "SortAndOrderBySalary":
                    {
                        SortAndOrderBy(EmployeesSortBy.Salary);
                        break;
                    }
                }

                DropEditMode();
                DropPagination();

                _presenter.DisplayEmployeeList();
            }
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
            ViewState[_pageIndexKey] = 0;
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
                {
                    ViewState[_orderByKey] = EmployeesOrderBy.Ascending;
                    break;
                }
                case EmployeesOrderBy.Ascending:
                {
                    ViewState[_orderByKey] = EmployeesOrderBy.Descending;
                    break;
                }
                case EmployeesOrderBy.Descending:
                {
                    ViewState[_orderByKey] = EmployeesOrderBy.Ascending;
                    break;
                }
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
                Configuration config = (Configuration) ViewState[_configKey];
                return config.PageSize;
            }
        }

        public int PageIndex
        {
            get { return (int) ViewState[_pageIndexKey]; }
        }

        public int EmployeeId
        {
            get
            {
                HiddenField hfEmployeeId = (HiddenField) gvEmployeeList.Rows[gvEmployeeList.EditIndex].FindControl("hfEmployeeId");
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

        public IEnumerable<JobViewModel> JobList
        {
            set
            {
                ddlJobList.DataSource = value;
                ddlJobList.DataBind();
            }
        }

        public void DisplayEmployeeList(IEnumerable<EmployeeViewModel> employeeList, int totalNumberOfEmployeesWithSpecifiedJob)
        {
            gvEmployeeList.DataSource = employeeList;
            gvEmployeeList.DataBind();

            ViewState[_totalNumberOfRowsKey] = totalNumberOfEmployeesWithSpecifiedJob;

            CreatePagingControl();
        }

        private void CreatePagingControl()
        {
            int totalNumberOfRows = (int) ViewState[_totalNumberOfRowsKey];
            int pageIndex = (int) ViewState[_pageIndexKey];

            if (totalNumberOfRows > 0 && PageSize > 0)
            {
                int numberOfPages = totalNumberOfRows / PageSize;
                if (totalNumberOfRows % PageSize > 0)
                    numberOfPages++;

                pPagination.Controls.Clear();

                Literal lPagesLabel = new Literal();
                lPagesLabel.Text = "Pages:&nbsp;";

                pPagination.Controls.Add(lPagesLabel);

                for (int i = 0; i < numberOfPages; i++)
                {
                    LinkButton lbPage = new LinkButton();
                    lbPage.ID = "lbPage_" + i.ToString();
                    lbPage.Text = (i + 1).ToString();
                    lbPage.CommandArgument = i.ToString();
                    lbPage.Click += lbPage_Click;

                    pPagination.Controls.Add(lbPage);

                    Literal lSpace = new Literal();
                    lSpace.Text = "&nbsp;";

                    pPagination.Controls.Add(lSpace);

                    if (i == pageIndex)
                    {
                        lbPage.ForeColor = ColorTranslator.FromHtml("#000000");
                        lbPage.Font.Underline = false;
                    }
                }
            }
        }

        protected void lbPage_Click(object sender, EventArgs e)
        {
            LinkButton lbPage = (LinkButton) sender;
            ViewState[_pageIndexKey] = int.Parse(lbPage.CommandArgument);

            DropEditMode();

            _presenter.DisplayEmployeeList();
        }
    }
}