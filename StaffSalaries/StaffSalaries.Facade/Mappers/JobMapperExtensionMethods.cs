using System.Collections.Generic;
using StaffSalaries.Facade.ViewModels;
using StaffSalaries.Model.Jobs;

namespace StaffSalaries.Facade.Mappers
{
    public static class JobMapperExtensionMethods
    {
        public static IEnumerable<JobViewModel> ConvertToJobListViewModel(this IEnumerable<Job> jobs)
        {
            List<JobViewModel> jobViewModels = new List<JobViewModel>();

            foreach (Job job in jobs)
            {
                jobViewModels.Add(job.ConvertToJobViewModel());
            }

            return jobViewModels;
        }

        public static JobViewModel ConvertToJobViewModel(this Job job)
        {
            return new JobViewModel
                {
                    Id = job.Id.ToString(),
                    Name = job.Name
                };
        }
    }
}