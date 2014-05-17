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