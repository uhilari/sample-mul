using Multiplica.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Validators
{
  public static class ValidatorHelper
  {
    public static void IsPositive(this int nro, string field)
    {
      if (nro <= 0)
        throw new InvalidCommandException(string.Format("'{0}' must be positive", field));
    }

    public static void NotEmpty(this string str, string field)
    {
      if (string.IsNullOrEmpty(str))
        throw new InvalidCommandException(string.Format("'{0}' cannot empty", field));
    }
  }
}