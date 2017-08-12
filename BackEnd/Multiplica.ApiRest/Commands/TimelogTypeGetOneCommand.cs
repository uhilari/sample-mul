using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Commands
{
  public class TimelogTypeGetOneCommand: Command<Models.TimelogTypeModel>
  {
    public TimelogTypeGetOneCommand(int timelogTypeId)
    {
      TimelogTypeId = timelogTypeId;
    }

    public int TimelogTypeId { get; }
  }
}