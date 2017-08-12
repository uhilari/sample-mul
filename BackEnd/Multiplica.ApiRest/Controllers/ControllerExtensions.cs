using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Multiplica.ApiRest.Controllers
{
  public static class ControllerExtensions
  {
    public static HttpResponseMessage Ok<S>(this HttpRequestMessage request, S data)
    {
      var resp = request.CreateResponse(HttpStatusCode.OK, data);
      resp.ReasonPhrase = "Success";
      return resp;
    }

    public static HttpResponseMessage NoContent(this HttpRequestMessage request, string msg)
    {
      var resp = request.CreateResponse(HttpStatusCode.OK);
      resp.ReasonPhrase = msg;
      return resp;
    }

    public static HttpResponseMessage Process(this HttpRequestMessage request, Func<HttpResponseMessage> fnc)
    {
      try
      {
        return fnc();
      }
      catch (Exception ex)
      {
        var resp = request.CreateResponse(HttpStatusCode.InternalServerError);
        resp.ReasonPhrase = ex.Message;
        return resp;
      }
    }
  }
}