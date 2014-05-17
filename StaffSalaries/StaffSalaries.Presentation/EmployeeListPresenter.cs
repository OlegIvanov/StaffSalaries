using StaffSalaries.Facade;
using StaffSalaries.Facade.Models;
using StaffSalaries.Facade.Presentations;

namespace StaffSalaries.Presentation
{
    public class EmployeeListPresenter : IEmployeeListPresenter
    {
        private IEmployeeListView _employeeListView;
        private IEmployeeJobServiceFacade _employeeJobServiceFacade;

        public EmployeeListPresenter(IEmployeeListView employeeListView, IEmployeeJobServiceFacade employeeJobServiceFacade)
        {
            _employeeListView = employeeListView;
            _employeeJobServiceFacade = employeeJobServiceFacade;
        }

        public void DisplayJobList()
        {
            JobListPresentation jobListPresentation = _employeeJobServiceFacade.GetJobList();

            _employeeListView.JobList = jobListPresentation.Jobs;
        }

        public void DisplayEmployeeList()
        {
            EmployeeListModel employeeListModel = new EmployeeListModel
            {
                JobId = _employeeListView.JobId,
                SortBy = _employeeListView.SortBy,
                OrderBy = _employeeListView.OrderBy,
                PageSize = _employeeListView.PageSize,
                PageIndex = _employeeListView.PageIndex
            };

            EmployeeListPresentation employeeListPresentation = _employeeJobServiceFacade.GetEmployeeList(employeeListModel);

            _employeeListView.DisplayEmployeeList(employeeListPresentation.Employees, employeeListPresentation.TotalNumberOfEmployeesWithSpecifiedJob);
        }

        public void UpdateEmployeeSalary()
        {
            EmployeeUpdateSalaryModel employeeUpdateSalaryModel = new EmployeeUpdateSalaryModel
            {
                EmployeeId = _employeeListView.EmployeeId,
                Salary = _employeeListView.Salary
            };

            _employeeJobServiceFacade.EmployeeUpdateSalary(employeeUpdateSalaryModel);
        }
    }
}