using System.Collections.Generic;
using UnityEngine;

namespace Socket.ClientEvents
{
  public class RoomsEvent: IClientEvent
  {
    public RoomsEvent()
    {
      EventName = "ROOMS ";
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}