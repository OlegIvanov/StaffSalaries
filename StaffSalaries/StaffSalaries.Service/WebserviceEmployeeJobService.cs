using System;
using StaffSalaries.Service.DataContracts;

namespace StaffSalaries.Service
{
    public class WebserviceEmployeeJobService : IEmployeeJobService
    {
        private string _webServiceUrl;

        public WebserviceEmployeeJobService(string webServiceUrl)
        {
            _webServiceUrl = webServiceUrl;
        }

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