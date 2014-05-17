using System.Collections.Generic;
using StaffSalaries.Facade.ViewModels;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Facade.Mappers
{
    public static class EmployeeMapperExtensionMethods
    {
        public static IEnumerable<EmployeeViewModel> ConvertToEmployeeListViewModel(this IEnumerable<Employee> employees)
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in employees)
            {
                employeeViewModels.Add(employee.ConvertToEmployeeViewModel());
            }

            return employeeViewModels;
        }

        public static EmployeeViewModel ConvertToEmployeeViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id.ToString(),
                FullName = string.Format("{0} {1}", employee.LastName, employee.FirstName),
                Salary = string.Format("{0:0.00}", employee.Salary)
            };
        }
    }
}