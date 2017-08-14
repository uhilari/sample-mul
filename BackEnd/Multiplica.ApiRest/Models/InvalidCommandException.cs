using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiplica.ApiRest.Models
{

  [Serializable]
  public class InvalidCommandException : Exception
  {
    public InvalidCommandException() { }
    public InvalidCommandException(string message) : base(message) { }
    public InvalidCommandException(string message, Exception inner) : base(message, inner) { }
    protected InvalidCommandException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }
}