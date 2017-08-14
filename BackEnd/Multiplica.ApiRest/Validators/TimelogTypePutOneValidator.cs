using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Validators
{
  public class TimelogTypePutOneValidator : ICommandHandler<TimelogTypePutOneCommand>
  {
    private ICommandHandler<TimelogTypePutOneCommand> _next;

    public TimelogTypePutOneValidator(ICommandHandler<TimelogTypePutOneCommand> next)
    {
      _next = next.ArgNotNull();
    }

    public void Execute(TimelogTypePutOneCommand command)
    {
      command.ArgNotNull();
      command.TimelogTypeId.IsPositive("timelogTypeId");
      command.TimelogType.NotEmpty("timelogType");
      _next.Execute(command);
    }
  }
}