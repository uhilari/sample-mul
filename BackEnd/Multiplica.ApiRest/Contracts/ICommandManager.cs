using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplica.ApiRest.Contracts
{
  public interface ICommandManager
  {
    void Handle<TCommand>(TCommand command) where TCommand : Commands.Command;
    T Handle<TCommand, T>(TCommand command) where TCommand : Commands.Command<T>;
  }
}
