using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplica.ApiRest.Contracts
{
  public interface IGenericRepository
  {
    T Get<T>(int id);
  }
}
