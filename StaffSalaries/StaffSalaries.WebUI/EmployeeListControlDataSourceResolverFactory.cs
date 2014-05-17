using System.Web.Configuration;
using StaffSalaries.Facade;
using StaffSalaries.Model.Employees;
using StaffSalaries.Model.Jobs;
using StaffSalaries.Repository.Repositories;
using StaffSalaries.Service;
using StaffSalaries.WebUI.EmployeeListControl;
using StructureMap;

namespace StaffSalaries.WebUI
{
    public static class EmployeeListControlDataSourceResolverFactory
    {
        public static IContainer GetConfiguredIoCContainer(Configuration configuration)
        {
            IContainer container = new Container();

            switch (configuration.DataSource.Type)
            {
                case ConfigurationDataSourceType.Database:
                {
                    string connectionString = WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString;

                    container.Configure(x =>
                    {
                        x.For<IEmployeeJobServiceFacade>().Use<EmployeeJobServiceFacade>();

                        x.For<IEmployeeJobService>().Use<DatabaseEmployeeJobService>();

                        x.For<IJobRepository>().Use<JobRepository>().Ctor<string>().Is(connectionString);
                        x.For<IEmployeeRepository>().Use<EmployeeRepository>().Ctor<string>().Is(connectionString);
                    });

                    break;
                }

                case ConfigurationDataSourceType.Webservice:
                {
                    container.Configure(x =>
                    {
                        x.For<IEmployeeJobServiceFacade>().Use<EmployeeJobServiceFacade>();

                        x.For<IEmployeeJobService>().Use<WebserviceEmployeeJobService>().Ctor<string>(configuration.DataSource.Url);
                    });

                    break;
                }
            }

            return container;
        }
    }
}