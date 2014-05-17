using System.Collections.Generic;

namespace StaffSalaries.Model.Jobs
{
    public interface IJobRepository
    {
        IEnumerable<Job> FindAll();
    }
}