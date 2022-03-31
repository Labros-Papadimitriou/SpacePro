using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using MyDatabase;
using Persistance_UnitOfWork;
using Persistance_UnitOfWork.IRepositories;
using Persistance_UnitOfWork.Repositories;
using SpacePro.AutoMapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.App_Start
{
    public class ContainerConfig : MvcApplication
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.Register(x => new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>())).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
           .As<IMapper>()
           .InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}