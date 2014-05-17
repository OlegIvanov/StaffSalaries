using System.Collections.Generic;

namespace StaffSalaries.Model.Employees
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> FindBy(EmployeeQuery employeeQuery);
        Employee FindBy(int employeeId);
        int Update(Employee employee);
        int GetTotalNumberWith(int jobId);
    }
}