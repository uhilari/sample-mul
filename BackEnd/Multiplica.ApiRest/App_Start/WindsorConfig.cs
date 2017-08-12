using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Controllers;
using Multiplica.ApiRest.Dependency;
using Multiplica.ApiRest.Handlers;
using Multiplica.ApiRest.Models;
using Multiplica.ApiRest.Persist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.App_Start
{
  public static class WindsorConfig
  {
    public static IWindsorContainer Config()
    {
      var container = new WindsorContainer();

      container
        .Register(Component.For<NHibernate.ISessionFactory>().Instance(NHibernateConfig.ConfigSessionFactory()))
        .Register(Component.For<IAllTimelogTypeQuery>().ImplementedBy<AllTimelogTypeQuery>().LifestyleTransient())
        .Register(Component.For<ICommandManager>().ImplementedBy<CommandManager>().LifestyleSingleton())
        .Register(Component.For<IGenericRepository>().ImplementedBy<GenericRepository>().LifestyleTransient());

      container.Register(
        Component.For<ICommandHandler<TimelogTypeGetAllCommand, IEnumerable<TimelogTypeModel>>>().ImplementedBy<SessionHandlerDecorator<TimelogTypeGetAllCommand, IEnumerable<TimelogTypeModel>>>().LifestyleTransient(),
        Component.For<ICommandHandler<TimelogTypeGetAllCommand, IEnumerable<TimelogTypeModel>>>().ImplementedBy<TimelogTypeGetAllHandler>().LifestyleTransient()
      );

      container.Register(
        Component.For<ICommandHandler<TimelogTypePutOneCommand>>().ImplementedBy<SessionHandlerDecorator<TimelogTypePutOneCommand>>().LifestyleTransient(),
        Component.For<ICommandHandler<TimelogTypePutOneCommand>>().ImplementedBy<TimelogTypePutOneHandler>().LifestyleTransient()
      );

      container.Register(
        Component.For<ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel>>().ImplementedBy<SessionHandlerDecorator<TimelogTypeGetOneCommand, TimelogTypeModel>>().LifestyleTransient(),
        Component.For<ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel>>().ImplementedBy<TimelogTypeGetOneHandler>().LifestyleTransient()
      );

      container.Register(Component.For<TimelogTypeController>().LifestyleTransient());

      return container;
    }
  }
}