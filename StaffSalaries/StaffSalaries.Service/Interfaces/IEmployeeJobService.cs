using StaffSalaries.Service.Messaging;

namespace StaffSalaries.Service.Interfaces
{
    public interface IEmployeeJobService
    {
        JobListResponse GetJobList();
        EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest);
        EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest);
    }
}