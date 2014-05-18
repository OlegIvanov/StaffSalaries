using StaffSalaries.Model.Employees;

namespace StaffSalaries.Service.DataContracts
{
    public class EmployeeListResponse
    {
        public Employee[] Employees { get; set; }
        public int TotalNumberOfEmployeesWithSpecifiedJob { get; set; }
    }
}