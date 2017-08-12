using Moq;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace Multiplica.ApiRest.Controllers
{
  public class TimelogTypeControllerTest
  {
    private TimelogTypeController _controller;
    private Mock<ICommandManager> _commandManager;

    public TimelogTypeControllerTest()
    {
      _commandManager = new Mock<ICommandManager>();
      _controller = new TimelogTypeController(_commandManager.Object);
      _controller.Request = new HttpRequestMessage();
      _controller.Configuration = new HttpConfiguration();
    }

    private void EsError(Func<HttpResponseMessage> fnc)
    {
      var res = fnc();
      Assert.Equal(HttpStatusCode.InternalServerError, res.StatusCode);
    }

    [Fact]
    public void GetAll_Ok()
    {
      _commandManager
        .Setup(c => c.Handle<TimelogTypeGetAllCommand, IEnumerable<TimelogTypeModel>>(It.IsAny<TimelogTypeGetAllCommand>()))
        .Returns(new Models.TimelogTypeModel[] { new TimelogTypeModel { TimelogTypeId = 3, TimelogType = "Tipo3", Budget = 2 } });

      var response = _controller.GetAll();

      TimelogTypeModel[] model;
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.True(response.TryGetContentValue(out model));
      Assert.Equal(1, model.Length);
    }

    [Fact]
    public void GetAll_Error()
    {
      _commandManager
        .Setup(c => c.Handle<TimelogTypeGetAllCommand, IEnumerable<TimelogTypeModel>>(It.IsAny<TimelogTypeGetAllCommand>()))
        .Throws(new Exception());

      EsError(() => _controller.GetAll());
    }

    [Fact]
    public void PutOne_Ok()
    {
      _commandManager
        .Setup(c => c.Handle(It.IsAny<TimelogTypePutOneCommand>()))
        .Verifiable();



      var response = _controller.PutOne(2, "TipoA");

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal("The Timelog Type has been updated", response.ReasonPhrase);
      _commandManager.VerifyAll();
    }

    [Fact]
    public void PutOne_Error()
    {
      _commandManager
        .Setup(c => c.Handle(It.IsAny<TimelogTypePutOneCommand>()))
        .Throws(new Exception());

      EsError(() => _controller.PutOne(2, "TipoB"));
    }

    [Fact]
    public void GetOne_Ok()
    {
      _commandManager
        .Setup(c => c.Handle<TimelogTypeGetOneCommand, TimelogTypeModel>(It.IsAny<TimelogTypeGetOneCommand>()))
        .Returns(new TimelogTypeModel { TimelogTypeId = 3, TimelogType = "Tipo3", Budget = 2 });

      var response = _controller.GetOne(2);

      TimelogTypeModel model;
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.True(response.TryGetContentValue(out model));
      Assert.Equal(3, model.TimelogTypeId);
    }

    [Fact]
    public void GetOne_Error()
    {
      _commandManager
        .Setup(c => c.Handle<TimelogTypeGetOneCommand, TimelogTypeModel>(It.IsAny<TimelogTypeGetOneCommand>()))
        .Throws(new Exception());

      EsError(() => _controller.GetOne(4));
    }
  }
}
