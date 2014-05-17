using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using StaffSalaries.Model.Employees;

namespace StaffSalaries.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Employee> FindBy(EmployeeQuery employeeQuery)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeesByEmployeeQuery", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@JobId", SqlDbType.Int).Value = employeeQuery.JobId;
                command.Parameters.Add("@SortExpression", SqlDbType.NVarChar, 50).Value = SortExpressionFromEmployeeQueryHelper.GetSortExpressionFrom(employeeQuery);
                command.Parameters.Add("@PageIndex", SqlDbType.Int).Value = employeeQuery.PageIndex;
                command.Parameters.Add("@PageSize", SqlDbType.Int).Value = employeeQuery.PageSize;

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    return GetEmployeesFromReader(reader);
                }
            }
        }

        public Employee FindBy(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeByEmployeeId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("EmployeeId", SqlDbType.Int).Value = employeeId;

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    return GetEmployeesFromReader(reader).FirstOrDefault();
                }
            }
        }

        public int Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employee.Id;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = employee.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = employee.LastName;
                command.Parameters.Add("@Salary", SqlDbType.Money).Value = employee.Salary;

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public int GetTotalNumberWith(int jobId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetTotalNumberOfEmployeesWithSpecifiedJobId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("JobId", SqlDbType.Int).Value = jobId;

                connection.Open();

                return (int) command.ExecuteScalar();
            }
        }

        private static IEnumerable<Employee> GetEmployeesFromReader(IDataReader dataReader)
        {
            List<Employee> employees = new List<Employee>();

            while (dataReader.Read())
            {
                employees.Add(new Employee
                {
                    Id = (int) dataReader["EmployeeId"],
                    FirstName = (string) dataReader["FirstName"],
                    LastName = (string) dataReader["LastName"],
                    Salary = (decimal) dataReader["Salary"]
                });
            }

            return employees;
        }
    }
}