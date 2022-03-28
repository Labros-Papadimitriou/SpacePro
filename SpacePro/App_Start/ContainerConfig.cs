using Autofac;
using Autofac.Integration.Mvc;
using MyDatabase;
using Persistance_UnitOfWork;
using Persistance_UnitOfWork.IRepositories;
using Persistance_UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.App_Start
{
    public class ContainerConfig:MvcApplication
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}