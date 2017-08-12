using Multiplica.ApiRest.Contracts;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Persist
{
  public class GenericRepository: BaseHibernate, IGenericRepository
  {
    public GenericRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

    public T Get<T>(int id)
    {
      T entity = Session.Get<T>(id);
      if (entity == null)
        throw new InvalidOperationException();
      return entity;
    }
  }
}