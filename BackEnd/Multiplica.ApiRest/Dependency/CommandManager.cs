using Castle.MicroKernel;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Dependency
{
  public class CommandManager: ICommandManager
  {
    private IKernel _kernel;

    public CommandManager(IKernel kernel)
    {
      _kernel = kernel;
    }

    public void Handle<TCommand>(TCommand command) where TCommand : Command
    {
      var handler = _kernel.Resolve<ICommandHandler<TCommand>>();
      handler.Execute(command);
    }

    public T Handle<TCommand, T>(TCommand command) where TCommand : Command<T>
    {
      var handler = _kernel.Resolve<ICommandHandler<TCommand, T>>();
      return handler.Execute(command);
    }
  }
}