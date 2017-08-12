using Moq;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using Xunit;

namespace Multiplica.ApiRest.Handlers
{
  public class TimelogTypeGetOneHandlerTest
  {
    private TimelogTypeGetOneHandler _handler;
    private Mock<IGenericRepository> _repository;

    public TimelogTypeGetOneHandlerTest()
    {
      _repository = new Mock<IGenericRepository>();
      _handler = new TimelogTypeGetOneHandler(_repository.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_handler);
    }

    [Fact]
    public void Constructor_SessionFactoryNull()
    {
      Assert.Throws<ArgumentNullException>(() => new TimelogTypeGetOneHandler(null));
    }

    [Fact]
    public void Execute_Ok()
    {
      _repository.Setup(c => c.Get<TimelogTypeModel>(2))
        .Returns(new TimelogTypeModel { TimelogTypeId = 2, TimelogType = "Model2", Budget = 3 });

      var timelogType = _handler.Execute(new TimelogTypeGetOneCommand(2));

      Assert.NotNull(timelogType);
      Assert.Equal(2, timelogType.TimelogTypeId);
    }

    [Fact]
    public void Execute_CommandNull()
    {
      Assert.Throws<ArgumentNullException>(() => _handler.Execute(null));
    }
  }
}
