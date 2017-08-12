using Multiplica.ApiRest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiplica.ApiRest.Models;
using NHibernate;

namespace Multiplica.ApiRest.Persist
{
  public class AllTimelogTypeQuery : BaseHibernate, IAllTimelogTypeQuery
  {
    public AllTimelogTypeQuery(ISessionFactory sessionFactory) : base(sessionFactory) { }

    public IEnumerable<TimelogTypeModel> Execute()
    {
      var cr = Session.CreateCriteria<TimelogTypeModel>();
      return cr.List<TimelogTypeModel>();
    }
  }
}
