using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Service.Messaging.EmployeeJobService;

namespace StaffSalaries.Service.Interfaces
{
    public interface IEmployeeJobService
    {
        JobListResponse GetJobList(JobListRequest jobListRequest);
        EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest);
        EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest);
    }
}
