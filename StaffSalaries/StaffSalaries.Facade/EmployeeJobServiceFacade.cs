using StaffSalaries.Facade.Models;
using StaffSalaries.Facade.Presentations;
using StaffSalaries.Service;

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
            throw new System.NotImplementedException();
        }

        public EmployeeListPresentation GetEmployeeList(EmployeeListModel employeeListRequestModel)
        {
            throw new System.NotImplementedException();
        }

        public void EmployeeUpdateSalary(EmployeeUpdateSalaryModel employeeUpdateSalaryModel)
        {
            throw new System.NotImplementedException();
        }
    }
}