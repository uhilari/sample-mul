using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Models;

namespace Multiplica.ApiRest.Handlers
{
  public class TimelogTypeGetOneHandler : ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel>
  {
    private IGenericRepository _repository;

    public TimelogTypeGetOneHandler(IGenericRepository repository)
    {
      _repository = repository.ArgNotNull();
    }

    public TimelogTypeModel Execute(TimelogTypeGetOneCommand command)
    {
      command.ArgNotNull();
      return _repository.Get<TimelogTypeModel>(command.TimelogTypeId);
    }
  }
}