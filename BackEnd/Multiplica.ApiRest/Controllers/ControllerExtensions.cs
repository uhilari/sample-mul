using Multiplica.ApiRest.Models;
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
      Func<HttpStatusCode, string, HttpResponseMessage> genResp = (c, m) =>
      {
        var resp = request.CreateResponse(c);
        resp.ReasonPhrase = m;
        return resp;
      };

      try
      {
        return fnc();
      }
      catch(InvalidCommandException ex)
      {
        return genResp(HttpStatusCode.BadRequest, ex.Message);
      }
      catch (NotFoundException ex)
      {
        return genResp(HttpStatusCode.NotFound, ex.Message);
      }
      catch (Exception ex)
      {
        return genResp(HttpStatusCode.InternalServerError, ex.Message);
      }
    }
  }
}