using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Models;
using System.Collections.Generic;

namespace Multiplica.ApiRest.Handlers
{
  public class TimelogTypeGetAllHandler : ICommandHandler<TimelogTypeGetAllCommand, IEnumerable<TimelogTypeModel>>
  {
    private IAllTimelogTypeQuery _query;

    public TimelogTypeGetAllHandler(IAllTimelogTypeQuery query)
    {
      _query = query.ArgNotNull();
    }

    public IEnumerable<TimelogTypeModel> Execute(TimelogTypeGetAllCommand command)
    {
      command.ArgNotNull();
      return _query.Execute();
    }
  }
}