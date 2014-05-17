namespace StaffSalaries.Service.DataContracts
{
    public class EmployeeUpdateSalaryRequest
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
    }
}