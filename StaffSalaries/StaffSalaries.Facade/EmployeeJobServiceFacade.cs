using StaffSalaries.Facade.Mappers;
using StaffSalaries.Facade.Models;
using StaffSalaries.Facade.Presentations;
using StaffSalaries.Model.Employees;
using StaffSalaries.Service;
using StaffSalaries.Service.DataContracts;

namespace StaffSalaries.Facade
{
    public class EmployeeJobServiceFacade : IEmployeeJobServiceFacade
    {
        private IEmployeeJobService _employeeJobService;

        public EmployeeJobServiceFacade(IEmployeeJobService employeeJobService)
        {
            _employeeJobService = employeeJobService;
        }

        public JobListPresentation GetJobList()
        {
            JobListPresentation jobListPresentation = new JobListPresentation();

            JobListResponse jobListResponse = _employeeJobService.GetJobList();

            jobListPresentation.Jobs = jobListResponse.Jobs.ConvertToJobListViewModel();

            return jobListPresentation;
        }

        public EmployeeListPresentation GetEmployeeList(EmployeeListModel employeeListModel)
        {
            EmployeeListPresentation employeeListPresentation = new EmployeeListPresentation();

            EmployeeListRequest employeeListRequest = new EmployeeListRequest();

            EmployeeQuery employeeQuery = new EmployeeQuery
                {
                    JobId = employeeListModel.JobId,
                    SortBy = employeeListModel.SortBy,
                    OrderBy = employeeListModel.OrderBy,
                    PageSize = employeeListModel.PageSize,
                    PageIndex = employeeListModel.PageIndex
                };

            employeeListRequest.EmployeeListQuery = employeeQuery;

            EmployeeListResponse employeeListResponse = _employeeJobService.GetEmployeeList(employeeListRequest);

            employeeListPresentation.Employees = employeeListResponse.Employees.ConvertToEmployeeListViewModel();
            employeeListPresentation.TotalNumberOfEmployeesWithSpecifiedJob =
                employeeListResponse.TotalNumberOfEmployeesWithSpecifiedJob;

            return employeeListPresentation;
        }

        public EmployeeUpdateSalaryPresentation EmployeeUpdateSalary(EmployeeUpdateSalaryModel employeeUpdateSalaryModel)
        {
            EmployeeUpdateSalaryPresentation employeeUpdateSalaryPresentation = new EmployeeUpdateSalaryPresentation();

            EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest = new EmployeeUpdateSalaryRequest
                {
                    EmployeeId = employeeUpdateSalaryModel.EmployeeId,
                    Salary = employeeUpdateSalaryModel.Salary
                };

            EmployeeUpdateSalaryResponse employeeUpdateSalaryResponse =
                _employeeJobService.EmployeeUpdateSalary(employeeUpdateSalaryRequest);

            return employeeUpdateSalaryPresentation;
        }
    }
}