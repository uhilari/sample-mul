using Moq;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using Xunit;

namespace Multiplica.ApiRest.Handlers
{
  public class TimelogTypePutOneHandlerTest
  {
    private Mock<IGenericRepository> _repository;
    private TimelogTypePutOneHandler _handler;

    public TimelogTypePutOneHandlerTest()
    {
      _repository = new Mock<IGenericRepository>();
      _handler = new TimelogTypePutOneHandler(_repository.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_handler);
    }

    [Fact]
    public void Constructor_SessionFactoryNull()
    {
      Assert.Throws<ArgumentNullException>(() => new TimelogTypePutOneHandler(null));
    }

    [Fact]
    public void Execute_ChangeTypelogType()
    {
      var model = new TimelogTypeModel { TimelogTypeId = 2 };
      _repository.Setup(c => c.Get<TimelogTypeModel>(2))
        .Returns(model);

      _handler.Execute(new TimelogTypePutOneCommand(2, "Tipo22"));

      Assert.Equal("Tipo22", model.TimelogType);
    }

    [Fact]
    public void Execute_CommandNull()
    {
      Assert.Throws<ArgumentNullException>(() => _handler.Execute(null));
    }
  }
}
