using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplica.ApiRest.Contracts
{
  public interface ICommandHandler<TCommand> where TCommand: Commands.Command
  {
    void Execute(TCommand command);
  }

  public interface ICommandHandler<TCommand, T> where TCommand: Commands.Command<T>
  {
    T Execute(TCommand command);
  }
}
