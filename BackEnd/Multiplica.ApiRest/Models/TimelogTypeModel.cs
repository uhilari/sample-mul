using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Models
{
  public class TimelogTypeModel
  {
    public virtual int TimelogTypeId { get; set; }
    public virtual string TimelogType { get; set; }
    public virtual int Budget { get; set; }
  }
}