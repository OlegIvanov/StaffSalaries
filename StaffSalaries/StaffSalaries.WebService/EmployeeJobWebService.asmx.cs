using System.Web.Services;
using StaffSalaries.Service;
using StaffSalaries.Service.DataContracts;

namespace StaffSalaries.WebService
{
    /// <summary>
    /// Summary description for EmployeeJobWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeJobWebService : System.Web.Services.WebService, IEmployeeJobService
    {
        private IEmployeeJobService _employeeJobService;

        public EmployeeJobWebService(IEmployeeJobService employeeJobService)
        {
            _employeeJobService = employeeJobService;
        }

        [WebMethod]
        public JobListResponse GetJobList()
        {
            return _employeeJobService.GetJobList();
        }

        [WebMethod]
        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            return _employeeJobService.GetEmployeeList(employeeListRequest);
        }

        [WebMethod]
        public EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest)
        {
            return _employeeJobService.EmployeeUpdateSalary(employeeUpdateSalaryRequest);
        }
    }
}