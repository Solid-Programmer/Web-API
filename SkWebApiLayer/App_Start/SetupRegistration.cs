using System;
using System.Configuration;
using Autofac;
using SkSampleContractsLayer.Contracts.Interfaces;
using SkSampleDataAccessLayer.DataAccess;
using SkSampleDataAccessLayer.DataAccess.Interfaces;
using SkSampleDataAccessLayer.DataAccess.Repositories;
using SkSampleDataAccessLayer.Implementations;

namespace SkWebApiLayer
{
    public static class SetupRegistration
    {
        internal static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<SkAppContext>()
                .InstancePerRequest()
                .UsingConstructor(typeof(string))
                .WithParameter("connectName", ConfigurationManager.ConnectionStrings["SampleAppConnection"].ConnectionString);

            containerBuilder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();

            containerBuilder.RegisterType<DepartmentRepository>()
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .PropertiesAutowired();

            containerBuilder.RegisterType<EmployeeRepository>()
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .PropertiesAutowired();

            containerBuilder.RegisterType<SkAppService>()
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}