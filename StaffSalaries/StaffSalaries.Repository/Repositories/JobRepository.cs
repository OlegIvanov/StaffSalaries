using System;
using System.Collections.Generic;
using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Repository.Repositories
{
    public class JobRepository : IJobRepository
    {
        public IEnumerable<Job> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}