using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Service.Interfaces;

namespace StaffSalaries.Facade
{
    public class EmployeeJobServiceFacade
    {
        private IEmployeeJobService _employeeJobService;

        public EmployeeJobServiceFacade(IEmployeeJobService employeeJobService)
        {
            _employeeJobService = employeeJobService;
        }
    }
}
