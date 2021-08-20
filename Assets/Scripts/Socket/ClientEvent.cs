using System;
using System.Collections.Generic;

namespace Socket
{
  public abstract class ClientEvent
  {
    // must eventName.length == 6
    public string EventName { get; protected set; }
    public abstract List<byte> GetBytes();
  }
}