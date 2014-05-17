using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Service.Messaging.EmployeeJobService
{
    public class EmployeeListResponse
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int TotalNumberOfEmployeesWithSpecifiedJob { get; set; }
    }
}