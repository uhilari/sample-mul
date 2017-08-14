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
  public class TimelogTypeGetOneValidatorTest
  {
    private TimelogTypeGetOneValidator _validator;
    private Mock<ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel>> _next;

    public TimelogTypeGetOneValidatorTest()
    {
      _next = new Mock<ICommandHandler<TimelogTypeGetOneCommand, TimelogTypeModel>>();
      _validator = new TimelogTypeGetOneValidator(_next.Object);
    }

    [Fact]
    public void Constructor_Ok()
    {
      Assert.NotNull(_validator);
    }

    [Fact]
    public void Constructor_NextNull()
    {
      Assert.Throws<ArgumentNullException>(() => new TimelogTypeGetOneValidator(null));
    }

    [Fact]
    public void Execute_Ok()
    {
      var timelogType = new TimelogTypeModel { TimelogTypeId = 2 };
      _next.Setup(c => c.Execute(It.IsAny<TimelogTypeGetOneCommand>()))
        .Returns(timelogType);

      var result = _validator.Execute(new TimelogTypeGetOneCommand(2));

      Assert.Equal(timelogType, result);
    }

    [Fact]
    public void Execute_CommandNull()
    {
      Assert.Throws<ArgumentNullException>(() => _validator.Execute(null));
    }

    [Fact]
    public void Execute_IdZeroOrNegative()
    {
      Assert.Throws<InvalidCommandException>(() => _validator.Execute(new TimelogTypeGetOneCommand(-2)));
    }
  }
}
