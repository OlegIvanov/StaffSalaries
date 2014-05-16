using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffSalaries.Model.Employees
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
