
namespace StaffSalaries.Service.Messaging.EmployeeJobService
{
    public class EmployeeUpdateSalaryRequest
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
    }
}