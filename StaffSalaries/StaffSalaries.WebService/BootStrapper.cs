using System.Web.Configuration;
using StaffSalaries.Model.Employees;
using StaffSalaries.Model.Jobs;
using StaffSalaries.Repository.Repositories;
using StaffSalaries.Service;
using StructureMap;

namespace StaffSalaries.WebService
{
    public static class BootStrapper
    {
        private static IContainer _container;

        public static IContainer GetConfiguredContainer()
        {
            if (_container != null)
                return _container;

            string connectionString = WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString;

            _container = new Container();

            _container.Configure(x =>
            {
                x.For<IEmployeeJobService>().Use<DatabaseEmployeeJobService>();

                x.For<IJobRepository>().Use<JobRepository>().Ctor<string>().Is(connectionString);
                x.For<IEmployeeRepository>().Use<EmployeeRepository>().Ctor<string>().Is(connectionString);
            });

            return _container;
        }
    }
}