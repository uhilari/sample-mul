using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Multiplica.IntegrationTest
{
  public class TimelogTypeControllerTest: IDisposable
  {
    private IWindsorContainer _container;
    private ApiRest.Controllers.TimelogTypeController _controller;

    public TimelogTypeControllerTest()
    {
      _container = ApiRest.App_Start.WindsorConfig.Config();
      _controller = _container.Resolve<ApiRest.Controllers.TimelogTypeController>();
      _controller.Request = new System.Net.Http.HttpRequestMessage();
      _controller.Configuration = new System.Web.Http.HttpConfiguration();
    }

    public void Dispose()
    {
      _controller.Dispose();
      _container.Dispose();
    }

    [Fact]
    public void CreateController_Ok()
    {
      Assert.NotNull(_controller);
    }

    [Fact]
    public void GetAll_Ok()
    {
      var resp = _controller.GetAll();

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public void GetOne_Ok()
    {
      var resp = _controller.GetOne(3);

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public void GetOne_400()
    {
      var resp = _controller.GetOne(-3);

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.BadRequest, resp.StatusCode);
    }

    [Fact]
    public void GetOne_404()
    {
      var resp = _controller.GetOne(30);

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
    }

    [Fact]
    public void PutOne_Ok()
    {
      var resp = _controller.PutOne(3, "Tipo 3");

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public void PutOne_400_Id()
    {
      var resp = _controller.PutOne(-3, "Tipo 30");

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.BadRequest, resp.StatusCode);
    }

    [Fact]
    public void PutOne_400_Type()
    {
      var resp = _controller.PutOne(3, "");

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.BadRequest, resp.StatusCode);
    }

    [Fact]
    public void PutOne_404()
    {
      var resp = _controller.PutOne(30, "Tipo 30");

      Assert.NotNull(resp);
      Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
    }
  }
}
