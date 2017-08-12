using Multiplica.ApiRest.Contracts;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Persist
{
  public class SessionHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : Commands.Command
  {
    private ISessionFactory _sessionFactory;
    private ICommandHandler<TCommand> _next;

    public SessionHandlerDecorator(ISessionFactory sessionFactory, ICommandHandler<TCommand> next)
    {
      _sessionFactory = sessionFactory;
      _next = next;
    }

    public void Execute(TCommand command)
    {
      using(var session = _sessionFactory.OpenSession())
      {
        CurrentSessionContext.Bind(session);
        _next.Execute(command);
        session.Flush();
        CurrentSessionContext.Unbind(_sessionFactory);
      }
    }
  }

  public class SessionHandlerDecorator<TCommand, T> : ICommandHandler<TCommand, T>
    where TCommand: Commands.Command<T>
  {
    private ISessionFactory _sessionFactory;
    private ICommandHandler<TCommand, T> _next;

    public SessionHandlerDecorator(ISessionFactory sessionFactory, ICommandHandler<TCommand, T> next)
    {
      _sessionFactory = sessionFactory;
      _next = next;
    }

    public T Execute(TCommand command)
    {
      T result = default(T);
      using (var session = _sessionFactory.OpenSession())
      {
        CurrentSessionContext.Bind(session);
        result = _next.Execute(command);
        CurrentSessionContext.Unbind(_sessionFactory);
      }
      return result;
    }
  }
}