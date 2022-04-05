using Autofac;
using Autofac.Integration.WebApi;
using MyDatabase;
using Persistance_UnitOfWork;
using SpacePro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SpaceRestApi.App_Start
{
    public class ContainerConfig 
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}