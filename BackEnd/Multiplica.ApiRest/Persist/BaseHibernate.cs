using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Persist
{
  public abstract class BaseHibernate
  {
    private ISessionFactory _sessionFactory;
    private ISession _session = null;

    public BaseHibernate(ISessionFactory sessionFactory)
    {
      _sessionFactory = sessionFactory.ArgNotNull();
    }

    protected ISession Session
    {
      get
      {
        if (_session == null)
          _session = _sessionFactory.GetCurrentSession();
        return _session;
      }
    }
  }
}