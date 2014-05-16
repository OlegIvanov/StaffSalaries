using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffSalaries.Service.Messaging.EmployeeJobService
{
    public class EmployeeUpdateSalaryRequest
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
    }
}
