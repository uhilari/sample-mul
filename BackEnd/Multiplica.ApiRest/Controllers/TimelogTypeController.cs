using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Multiplica.ApiRest.Controllers
{
  [RoutePrefix("v1/timelogtypes")]
  public class TimelogTypeController : ApiController
  {
    private Contracts.ICommandManager _commandManager;

    public TimelogTypeController(Contracts.ICommandManager commandManager)
    {
      _commandManager = commandManager;
    }

    [Route("")]
    public HttpResponseMessage GetAll()
    {
      return Request.Process(() => {
        var data = _commandManager.Handle<Commands.TimelogTypeGetAllCommand, IEnumerable<Models.TimelogTypeModel>>(new Commands.TimelogTypeGetAllCommand());
        return Request.Ok(data);
      });
    }

    [Route("{timelogTypeId}")]
    public HttpResponseMessage PutOne(int timelogTypeId, [FromBody]string timelogType)
    {
      return Request.Process(() =>
      {
        _commandManager.Handle(new Commands.TimelogTypePutOneCommand(timelogTypeId, timelogType));
        return Request.NoContent("The Timelog Type has been updated");
      });
    }

    [Route("{timelogTypeId}")]
    public HttpResponseMessage GetOne(int timelogTypeId)
    {
      return Request.Process(() =>
      {
        var data = _commandManager.Handle<Commands.TimelogTypeGetOneCommand, Models.TimelogTypeModel>(new Commands.TimelogTypeGetOneCommand(timelogTypeId));
        return Request.Ok(data);
      });
    }
  }
}