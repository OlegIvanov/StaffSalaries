using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffSalaries.Model.Employees
{
    public class EmployeeQuery
    {
        public int JobId { get; set; }
        public string SortExpression { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
