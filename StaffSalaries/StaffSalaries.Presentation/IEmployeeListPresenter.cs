using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffSalaries.Presentation
{
    public interface IEmployeeListPresenter
    {
        void DisplayJobList();
        void DisplayEmployeeList();
        void UpdateEmployeeSalary();
    }
}
