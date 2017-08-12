using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Maps
{
  public class TimelogTypeMap: ClassMapping<Models.TimelogTypeModel>
  {
    public TimelogTypeMap()
    {
      Table("TimelogTypes");
      Id(c => c.TimelogTypeId, m => m.Column("Id"));
      Property(c => c.TimelogType);
      Property(c => c.Budget);
    }
  }
}