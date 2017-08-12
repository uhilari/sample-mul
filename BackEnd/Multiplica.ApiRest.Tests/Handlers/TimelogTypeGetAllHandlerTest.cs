using Moq;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using System.Linq;
using Xunit;

namespace Multiplica.ApiRest.Handlers
{
  public class TimelogTypeGetAllHandlerTest
  {
    private TimelogTypeGetAllHandler _handler;
    private Mock<IAllTimelogTypeQuery> _query;

    public TimelogTypeGetAllHandlerTest()
    {
      _query = new Mock<IAllTimelogTypeQuery>();
      _handler = new TimelogTypeGetAllHandler(_query.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_handler);
    }

    [Fact]
    public void Constructor_QueryNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        new TimelogTypeGetAllHandler(null);
      });
    }

    [Fact]
    public void Execute_Ok()
    {
      _query.Setup(c => c.Execute())
        .Returns(() => new TimelogTypeModel[]
        {
          new TimelogTypeModel{ TimelogTypeId=2, TimelogType="Tipo2", Budget=5 },
          new TimelogTypeModel{ TimelogTypeId=3, TimelogType="Tipo3", Budget=7 },
        });

      var data = _handler.Execute(new TimelogTypeGetAllCommand());

      Assert.NotNull(data);
      Assert.Equal(2, data.Count());
    }

    [Fact]
    public void Execute_CommandNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        _handler.Execute(null);
      });
    }
  }
}
