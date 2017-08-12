using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Commands
{
  public class TimelogTypePutOneCommand: Command
  {
    public TimelogTypePutOneCommand(int timelogTypeId, string timelogType)
    {
      TimelogTypeId = timelogTypeId;
      TimelogType = timelogType;
    }

    public int TimelogTypeId { get; }
    public string TimelogType { get; }
  }
}