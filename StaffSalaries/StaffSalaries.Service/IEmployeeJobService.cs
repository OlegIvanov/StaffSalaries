using StaffSalaries.Service.DataContracts;

namespace StaffSalaries.Service
{
    public interface IEmployeeJobService
    {
        JobListResponse GetJobList();
        EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest);
        EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest);
    }
}