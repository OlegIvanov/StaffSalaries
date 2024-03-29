﻿namespace StaffSalaries.Model.Employees
{
    public class EmployeeQuery
    {
        public int JobId { get; set; }
        public EmployeesSortBy SortBy { get; set; }
        public EmployeesOrderBy OrderBy { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}