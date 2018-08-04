using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using SkSampleContractsLayer.Contracts.Interfaces;
using SkSampleDataAccessLayer.DataAccess;
using SkSampleDataAccessLayer.DataAccess.Interfaces;
using SkSampleDataAccessLayer.DataAccess.Repositories;
using SkSampleDataAccessLayer.Implementations;
using SkWebApiLayer.Controllers;

namespace SkWebApiLayer
{
    public static class AutofacDiBootstrapper
    {
        public static void Bootstrap()
        {
            var containerBuilder = new ContainerBuilder();
            SetupRegistration.Bootstrap(containerBuilder);
            containerBuilder.RegisterApiControllers(typeof(EmployeeController).Assembly);
            var container = containerBuilder.Build();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}
