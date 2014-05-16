using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
