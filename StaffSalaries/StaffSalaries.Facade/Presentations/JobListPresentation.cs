using System.Collections.Generic;
using StaffSalaries.Facade.ViewModels;

namespace StaffSalaries.Facade.Presentations
{
    public class JobListPresentation : BasePresentation
    {
        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
}