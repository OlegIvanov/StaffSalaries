using System;
using StaffSalaries.Service.DataContracts;

namespace StaffSalaries.Service
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