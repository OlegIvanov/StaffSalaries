﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Presentation
{
    public interface IEmployeeListView
    {
        int JobId { get; }
        EmployeesSortBy SortBy { get; }
        EmployeesOrderBy OrderBy { get; }
        int PageSize { get; }
        int PageIndex { get; }
        int EmployeeId { get; }
        decimal Salary { get; }
    }
}
