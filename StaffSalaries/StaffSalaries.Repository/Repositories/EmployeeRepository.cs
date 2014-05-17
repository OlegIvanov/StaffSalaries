using System;
using System.Collections.Generic;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> FindBy(EmployeeQuery employeeQuery)
        {
            throw new NotImplementedException();
        }

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