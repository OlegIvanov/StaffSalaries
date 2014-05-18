using EJ = EmployeeJobWebServiceProxyTypesNamespace;
using EmployeeListRequest = StaffSalaries.Service.DataContracts.EmployeeListRequest;
using EmployeeListResponse = StaffSalaries.Service.DataContracts.EmployeeListResponse;
using EmployeeUpdateSalaryRequest = StaffSalaries.Service.DataContracts.EmployeeUpdateSalaryRequest;
using EmployeeUpdateSalaryResponse = StaffSalaries.Service.DataContracts.EmployeeUpdateSalaryResponse;
using JobListResponse = StaffSalaries.Service.DataContracts.JobListResponse;

namespace StaffSalaries.Service
{
    public class WebserviceEmployeeJobService : IEmployeeJobService
    {
        private EJ.EmployeeJobWebService _webServiceProxy;

        public WebserviceEmployeeJobService(string webServiceUrl)
        {
            _webServiceProxy = new EJ.EmployeeJobWebService();
            _webServiceProxy.Url = webServiceUrl;
        }

        public JobListResponse GetJobList()
        {
            return _webServiceProxy.GetJobList().ConvertToJobListResponse();
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            EJ.EmployeeListRequest employeeListRequestProxy = employeeListRequest.ConvertToEmployeeListRequestProxy();

            return _webServiceProxy.GetEmployeeList(employeeListRequestProxy).ConvertToEmployeeListResponse();
        }

        public EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest)
        {
            EJ.EmployeeUpdateSalaryRequest employeeUpdateSalaryRequestProxy = employeeUpdateSalaryRequest.ConvertToEmployeeUpdateSalaryRequestProxy();

            return _webServiceProxy.EmployeeUpdateSalary(employeeUpdateSalaryRequestProxy).ConvertToEmployeeUpdateSalaryResponse();
        }
    }
}