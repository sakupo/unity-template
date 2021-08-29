using System;
using System.Collections.Generic;

namespace Socket.ServerEvents
{
  public class StartEvent: IServerEvent
  {
    public StartEvent(byte[] body)
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