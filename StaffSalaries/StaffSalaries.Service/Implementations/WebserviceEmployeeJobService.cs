using System;
using StaffSalaries.Service.Interfaces;
using StaffSalaries.Service.Messaging.EmployeeJobService;

namespace StaffSalaries.Service.Implementations
{
    public class WebserviceEmployeeJobService : IEmployeeJobService
    {
        public JobListResponse GetJobList()
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