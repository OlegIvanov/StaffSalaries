using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Repository.Repositories
{
    public class JobRepository : IJobRepository
    {
        private string _connectionString;

        public JobRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Job> FindAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllJobs", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    return GetJobsFromReader(reader);
                }
            }
        }

        private static IEnumerable<Job> GetJobsFromReader(IDataReader dataReader)
        {
            List<Job> jobs = new List<Job>();

            while (dataReader.Read())
            {
                jobs.Add(new Job
                {
                    Id = (int) dataReader["JobId"],
                    Name = (string) dataReader["JobName"]
                });
            }

            return jobs;
        }
    }
}