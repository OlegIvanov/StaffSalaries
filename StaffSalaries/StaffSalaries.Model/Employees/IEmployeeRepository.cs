using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffSalaries.Model.Employees
{
    public interface IEmployeeRepository
    {
        Employee FindBy(int employeeId);
        int Update(Employee employee);
        int GetTotalNumberWith(int jobId);
    }
}
