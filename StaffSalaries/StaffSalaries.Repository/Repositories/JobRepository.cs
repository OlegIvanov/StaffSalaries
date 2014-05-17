using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}