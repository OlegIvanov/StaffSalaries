using System.Collections.Generic;
using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Service.Messaging.EmployeeJobService
{
    public class JobListResponse
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}