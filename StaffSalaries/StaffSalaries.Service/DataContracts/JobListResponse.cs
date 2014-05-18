using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Service.DataContracts
{
    public class JobListResponse
    {
        public Job[] Jobs { get; set; }
    }
}