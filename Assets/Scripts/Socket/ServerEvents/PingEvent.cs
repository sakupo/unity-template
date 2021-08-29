using System;
using System.Collections.Generic;

namespace Socket.ServerEvents
{
  public class PingEvent: IServerEvent
  {
    public PingEvent(byte[] body)
    {
      
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      return;
    }

    public void Call()
    {
      return;
    }
  }
}