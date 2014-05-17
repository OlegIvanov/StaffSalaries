using System.Collections.Generic;
using StaffSalaries.Facade.ViewModels;

namespace StaffSalaries.Facade.Presentations
{
    public class JobListPresentation
    {
        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
}