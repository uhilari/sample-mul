using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Commands;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Multiplica.ApiRest.Models;

namespace Multiplica.ApiRest.Handlers
{
  public class TimelogTypePutOneHandler : ICommandHandler<TimelogTypePutOneCommand>
  {
    private IGenericRepository _repository;

    public TimelogTypePutOneHandler(IGenericRepository repository)
    {
      _repository = repository.ArgNotNull();
    }

    public void Execute(TimelogTypePutOneCommand command)
    {
      command.ArgNotNull();
      var model = _repository.Get<TimelogTypeModel>(command.TimelogTypeId);
      model.TimelogType = command.TimelogType;
    }
  }
}