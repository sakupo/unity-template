using System;
using System.Collections.Generic;
using Utility;

namespace Socket.ServerEvents
{
  public class WelcomeEvent : IServerEvent
  {
    public void SetOptions(Dictionary<string, Object> options)
    {
      return;
    }

    public void Call()
    {
      Debug.Log("Welcome!");
    }
  }
}