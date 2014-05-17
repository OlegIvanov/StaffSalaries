﻿using System.Collections.Generic;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Service.Messaging.EmployeeJobService
{
    public class EmployeeListResponse
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int TotalNumberOfEmployeesWithSpecifiedJob { get; set; }
    }
}