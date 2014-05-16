using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffSalaries.Model.Jobs
{
    public interface IJobRepository
    {
        IEnumerable<Job> FindAll();
    }
}
