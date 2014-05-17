using StaffSalaries.Model.Employees;

namespace StaffSalaries.Facade.Models
{
    public class EmployeeListModel
    {
        public int JobId { get; set; }
        public EmployeesSortBy SortBy { get; set; }
        public EmployeesOrderBy OrderBy { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}