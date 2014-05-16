using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Service.Interfaces;
using StaffSalaries.Service.Messaging.EmployeeJobService;

namespace StaffSalaries.Service.Implementations
{
    public class DatabaseEmployeeJobService : IEmployeeJobService
    {
        public JobListResponse GetJobList(JobListRequest jobListRequest)
        {
            throw new NotImplementedException();
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            throw new NotImplementedException();
        }

        public EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest)
        {
            throw new NotImplementedException();
        }
    }
}
