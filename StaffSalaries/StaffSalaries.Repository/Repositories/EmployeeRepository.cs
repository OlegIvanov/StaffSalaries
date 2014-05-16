using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee FindBy(int employeeId)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberWith(int jobId)
        {
            throw new NotImplementedException();
        }
    }
}
