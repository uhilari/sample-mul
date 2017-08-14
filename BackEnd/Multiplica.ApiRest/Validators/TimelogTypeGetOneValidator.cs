using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Validators
{
  public class TimelogTypeGetOneValidator : ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel>
  {
    private ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel> _next;

    public TimelogTypeGetOneValidator(ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel> next)
    {
      _next = next.ArgNotNull();
    }

    public TimelogTypeModel Execute(TimelogTypeGetOneCommand command)
    {
      command.ArgNotNull();
      command.TimelogTypeId.IsPositive("timelogTypeId");
      return _next.Execute(command);
    }
  }
}