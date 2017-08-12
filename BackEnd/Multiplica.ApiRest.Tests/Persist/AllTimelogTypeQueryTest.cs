using Moq;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Multiplica.ApiRest.Persist
{
  public class AllTimelogTypeQueryTest
  {
    private Mock<ISession> _session;
    private Mock<ISessionFactory> _sessionFactory;
    private IAllTimelogTypeQuery _query;

    public AllTimelogTypeQueryTest()
    {
      _session = new Mock<ISession>();
      _sessionFactory = new Mock<ISessionFactory>();
      _sessionFactory.Setup(c => c.GetCurrentSession()).Returns(_session.Object);
      _query = new AllTimelogTypeQuery(_sessionFactory.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_query);
    }

    [Fact]
    public void Constructor_SessionFactoryNull()
    {
      Assert.Throws<ArgumentNullException>(() => new AllTimelogTypeQuery(null));
    }

    [Fact]
    public void Execute_Ok()
    {
      var cr = new Mock<ICriteria>();
      _session.Setup(c => c.CreateCriteria<TimelogTypeModel>()).Returns(cr.Object);
      cr.Setup(c => c.List<TimelogTypeModel>())
        .Returns(new List<TimelogTypeModel>
        {
          new TimelogTypeModel{ TimelogTypeId = 2 },
          new TimelogTypeModel{ TimelogTypeId = 4 }
        });

      var lst = _query.Execute();

      Assert.NotNull(lst);
      Assert.Equal(2, lst.Count());
    }
  }
}
