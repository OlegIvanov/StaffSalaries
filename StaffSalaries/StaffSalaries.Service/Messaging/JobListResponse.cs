using System.Collections.Generic;
using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Service.Messaging
{
    public class JobListResponse
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}