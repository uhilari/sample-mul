using Moq;
using Multiplica.ApiRest.Commands;
using Multiplica.ApiRest.Contracts;
using Multiplica.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Multiplica.ApiRest.Validators
{
  public class TimelogTypePutOneValidatorTest
  {
    private TimelogTypePutOneValidator _validator;
    private Mock<ICommandHandler<TimelogTypePutOneCommand>> _next;

    public TimelogTypePutOneValidatorTest()
    {
      _next = new Mock<ICommandHandler<TimelogTypePutOneCommand>>();
      _validator = new TimelogTypePutOneValidator(_next.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_validator);
    }

    [Fact]
    public void Constructor_CommandNull()
    {
      Assert.Throws<ArgumentNullException>(() => new TimelogTypePutOneValidator(null));
    }

    [Fact]
    public void Execute_Ok()
    {
      _next.Setup(c => c.Execute(It.IsAny<TimelogTypePutOneCommand>()))
        .Verifiable();

      _validator.Execute(new TimelogTypePutOneCommand(2, "Tipo 2"));

      _next.VerifyAll();
    }

    [Fact]
    public void Execute_CommandNull()
    {
      Assert.Throws<ArgumentNullException>(() => _validator.Execute(null));
    }

    [Fact]
    public void Execute_IdZeroOrNegative()
    {
      Assert.Throws<InvalidCommandException>(() => _validator.Execute(new TimelogTypePutOneCommand(-2, "Tipo 2")));
    }

    [Fact]
    public void Execute_TypeNullOrEmpty()
    {
      Assert.Throws<InvalidCommandException>(() => _validator.Execute(new TimelogTypePutOneCommand(2, null)));
    }
  }
}
