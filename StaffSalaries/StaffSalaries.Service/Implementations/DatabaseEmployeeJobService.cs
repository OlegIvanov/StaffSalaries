using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Service.Interfaces;
using StaffSalaries.Service.Messaging.EmployeeJobService;
using StaffSalaries.Model.Jobs;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Service.Implementations
{
    public class DatabaseEmployeeJobService : IEmployeeJobService
    {
        private IJobRepository _jobRepository;
        private IEmployeeRepository _employeeRepository;

        public DatabaseEmployeeJobService(IJobRepository jobRepository, IEmployeeRepository employeeRepository)
        {
            _jobRepository = jobRepository;
            _employeeRepository = employeeRepository;
        }

        public JobListResponse GetJobList()
        {
            JobListResponse jobListResponse = new JobListResponse();

            jobListResponse.Jobs = _jobRepository.FindAll();

            return jobListResponse;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            EmployeeListResponse employeeListResponse = new EmployeeListResponse();

            employeeListResponse.Employees = _employeeRepository.FindBy(employeeListRequest.EmployeeListQuery);
            employeeListResponse.TotalNumberOfEmployeesWithSpecifiedJob = _employeeRepository.GetTotalNumberWith(employeeListRequest.EmployeeListQuery.JobId);

            return employeeListResponse;
        }

        public EmployeeUpdateSalaryResponse EmployeeUpdateSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest)
        {
            EmployeeUpdateSalaryResponse employeeUpdateSalaryResponse = new EmployeeUpdateSalaryResponse();

            Employee employee = _employeeRepository.FindBy(employeeUpdateSalaryRequest.EmployeeId);
            employee.Salary = employeeUpdateSalaryRequest.Salary;
            _employeeRepository.Update(employee);

            return employeeUpdateSalaryResponse;
        }
    }
}
