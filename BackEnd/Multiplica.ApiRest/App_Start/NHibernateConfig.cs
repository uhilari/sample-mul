using Multiplica.ApiRest.Maps;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.App_Start
{
  public static class NHibernateConfig
  {
    public static ISessionFactory ConfigSessionFactory()
    {
      var cfg = new Configuration();
      cfg.DataBaseIntegration(db =>
      {
        db.Dialect<NHibernate.Dialect.MsSql2008Dialect>();
        db.ConnectionStringName = "BaseDatos";
      });
      cfg.CurrentSessionContext<CallSessionContext>();

      var mapper = new ModelMapper();
      mapper.AddMapping<TimelogTypeMap>();
      cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

      return cfg.BuildSessionFactory();
    }
  }
}