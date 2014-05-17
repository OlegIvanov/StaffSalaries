using StaffSalaries.Facade.Models;
using StaffSalaries.Facade.Presentations;

namespace StaffSalaries.Facade
{
    public interface IEmployeeJobServiceFacade
    {
        JobListPresentation GetJobList();
        EmployeeListPresentation GetEmployeeList(EmployeeListModel employeeListModel);
        void EmployeeUpdateSalary(EmployeeUpdateSalaryModel employeeUpdateSalaryModel);
    }
}