using System;
using System.Collections.Generic;
using Utility;

namespace Socket.ServerEvents
{
  public class UnknownEvent: IServerEvent
  {
    private readonly string message;
    public UnknownEvent(string message)
    {
      this.message = message;
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      return;
    }

    public void Call()
    {
      Debug.Log(message);
    }
  }
}