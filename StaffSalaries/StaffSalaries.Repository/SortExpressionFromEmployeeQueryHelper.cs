using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Repository
{
    public static class SortExpressionFromEmployeeQueryHelper
    {
        public static string GetSortExpressionFrom(EmployeeQuery employeeQuery)
        {
            string expression = string.Empty;

            if (employeeQuery.SortBy == EmployeesSortBy.None ||
                employeeQuery.OrderBy == EmployeesOrderBy.None)
                return expression;

            switch (employeeQuery.SortBy)
            {
                case EmployeesSortBy.FullName:
                    expression += "FullName";
                    break;
                case EmployeesSortBy.Salary:
                    expression += "Salary";
                    break;
            }

            switch (employeeQuery.OrderBy)
            {
                case EmployeesOrderBy.Ascending:
                    expression += "Ascending";
                    break;
                case EmployeesOrderBy.Descending:
                    expression += "Descending";
                    break;
            }

            return expression;
        }
    }
}
