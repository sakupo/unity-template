using System.Collections.Generic;
using UnityEngine;

namespace Socket.ClientEvents
{
  public class XRoomsEvent: IClientEvent
  {
    public XRoomsEvent()
    {
      EventName = "XROOMS";
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}