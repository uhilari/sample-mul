using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplica.ApiRest.Contracts
{
  public interface IAllTimelogTypeQuery
  {
    IEnumerable<Models.TimelogTypeModel> Execute();
  }
}
