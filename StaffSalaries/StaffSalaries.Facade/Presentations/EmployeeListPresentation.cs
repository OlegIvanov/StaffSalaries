﻿using System.Collections.Generic;
using StaffSalaries.Facade.ViewModels;

namespace StaffSalaries.Facade.Presentations
{
    public class EmployeeListPresentation : BasePresentation
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
        public int TotalNumberOfEmployeesWithSpecifiedJob { get; set; }
    }
}