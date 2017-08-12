using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest
{
  public static class Extensions
  {
    public static T ArgNotNull<T>(this T obj)
    {
      if (object.ReferenceEquals(obj, null))
        throw new ArgumentNullException();
      return obj;
    }
  }
}