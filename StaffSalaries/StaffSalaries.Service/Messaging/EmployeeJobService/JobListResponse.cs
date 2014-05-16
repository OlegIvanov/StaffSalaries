using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Service.Messaging.EmployeeJobService
{
    public class JobListResponse
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}
