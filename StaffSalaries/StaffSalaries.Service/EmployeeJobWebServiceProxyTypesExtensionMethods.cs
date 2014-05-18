using System;
using System.Collections.Generic;
using StaffSalaries.Model.Employees;
using StaffSalaries.Model.Jobs;
using StaffSalaries.Service.DataContracts;
using EJ = EmployeeJobWebServiceProxyTypesNamespace;

namespace StaffSalaries.Service
{
    public static class EmployeeJobWebServiceProxyTypesExtensionMethods
    {
        public static JobListResponse ConvertToJobListResponse(this EJ.JobListResponse jobListResponseProxy)
        {
            Job[] jobs = jobListResponseProxy.Jobs.ConvertToJobArray();

            return new JobListResponse
            {
                Jobs = jobs,
            };
        }

        public static Job[] ConvertToJobArray(this EJ.Job[] jobProxyArray)
        {
            List<Job> jobs = new List<Job>();

            foreach (EJ.Job job in jobProxyArray)
            {
                jobs.Add(job.ConvertToJob());
            }

            return jobs.ToArray();
        }

        public static Job ConvertToJob(this EJ.Job jobProxy)
        {
            return new Job
            {
                Id = jobProxy.Id,
                Name = jobProxy.Name
            };
        }

        public static EJ.EmployeeListRequest ConvertToEmployeeListRequestProxy(this EmployeeListRequest employeeListRequest)
        {
            EJ.EmployeeQuery employeeQueryProxy = employeeListRequest.EmployeeListQuery.ConvertToEmployeeQueryProxy();

            return new EJ.EmployeeListRequest
            {
                EmployeeListQuery = employeeQueryProxy
            };
        }

        public static EJ.EmployeeQuery ConvertToEmployeeQueryProxy(this EmployeeQuery employeeQuery)
        {
            return new EJ.EmployeeQuery
            {
                JobId = employeeQuery.JobId,
                SortBy = employeeQuery.SortBy.ConvertToEmployeesSortByProxy(),
                OrderBy = employeeQuery.OrderBy.ConvertToEmployeesOrderByProxy(),
                PageSize = employeeQuery.PageSize,
                PageIndex = employeeQuery.PageIndex
            };
        }

        public static EJ.EmployeesSortBy ConvertToEmployeesSortByProxy(this EmployeesSortBy employeesSortBy)
        {
            switch (employeesSortBy)
            {
                case EmployeesSortBy.None:
                    return EJ.EmployeesSortBy.None;
                case EmployeesSortBy.FullName:
                    return EJ.EmployeesSortBy.FullName;
                case EmployeesSortBy.Salary:
                    return EJ.EmployeesSortBy.Salary;
                default:
                    throw new ArgumentOutOfRangeException("employeesSortBy");
            }
        }

        public static EJ.EmployeesOrderBy ConvertToEmployeesOrderByProxy(this EmployeesOrderBy employeesOrderBy)
        {
            switch (employeesOrderBy)
            {
                case EmployeesOrderBy.None:
                    return EJ.EmployeesOrderBy.None;
                case EmployeesOrderBy.Ascending:
                    return EJ.EmployeesOrderBy.Ascending;
                case EmployeesOrderBy.Descending:
                    return EJ.EmployeesOrderBy.Descending;
                default:
                    throw new ArgumentOutOfRangeException("employeesOrderBy");
            }
        }

        public static EmployeeListResponse ConvertToEmployeeListResponse(this EJ.EmployeeListResponse employeeListResponseProxy)
        {
            Employee[] employees = employeeListResponseProxy.Employees.ConvertToEmployeeArray();

            return new EmployeeListResponse
            {
                Employees = employees,
                TotalNumberOfEmployeesWithSpecifiedJob = employeeListResponseProxy.TotalNumberOfEmployeesWithSpecifiedJob
            };
        }

        public static Employee[] ConvertToEmployeeArray(this EJ.Employee[] employeeProxyArray)
        {
            List<Employee> employees = new List<Employee>();

            foreach (EJ.Employee employeeProxy in employeeProxyArray)
            {
                employees.Add(employeeProxy.ConvertToEmployee());
            }

            return employees.ToArray();
        }

        public static Employee ConvertToEmployee(this EJ.Employee employeeProxy)
        {
            return new Employee
            {
                Id = employeeProxy.Id,
                FirstName = employeeProxy.FirstName,
                LastName = employeeProxy.LastName,
                Salary = employeeProxy.Salary
            };
        }

        public static EJ.EmployeeUpdateSalaryRequest ConvertToEmployeeUpdateSalaryRequestProxy(this EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest)
        {
            return new EJ.EmployeeUpdateSalaryRequest
            {
                EmployeeId = employeeUpdateSalaryRequest.EmployeeId,
                Salary = employeeUpdateSalaryRequest.Salary
            };
        }

        public static EmployeeUpdateSalaryResponse ConvertToEmployeeUpdateSalaryResponse(this EJ.EmployeeUpdateSalaryResponse employeeUpdateSalaryResponse)
        {
            return new EmployeeUpdateSalaryResponse();
        }
    }
}