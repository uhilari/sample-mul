using Moq;
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
  public class GenericRepositoryTest
  {
    private GenericRepository _repository;
    private Mock<ISession> _session;
    private Mock<ISessionFactory> _sessionFactory;

    public GenericRepositoryTest()
    {
      _session = new Mock<ISession>();
      _sessionFactory = new Mock<ISessionFactory>();
      _sessionFactory.Setup(c => c.GetCurrentSession())
        .Returns(_session.Object);
      _repository = new GenericRepository(_sessionFactory.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_repository);
    }

    [Fact]
    public void Constructor_SessionFactoryNull()
    {
      Assert.Throws<ArgumentNullException>(() => new GenericRepository(null));
    }

    [Fact]
    public void Get_Ok()
    {
      _session.Setup(c => c.Get<TimelogTypeModel>(2))
        .Returns(new TimelogTypeModel { TimelogTypeId = 2 });

      var model = _repository.Get<TimelogTypeModel>(2);

      Assert.NotNull(model);
      Assert.Equal(2, model.TimelogTypeId);
    }

    [Fact]
    public void Get_ReturnNull()
    {
      Assert.Throws<InvalidOperationException>(() => _repository.Get<TimelogTypeModel>(3));
    }
  }
}
