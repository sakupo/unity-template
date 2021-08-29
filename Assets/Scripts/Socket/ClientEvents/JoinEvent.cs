using System;
using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class JoinEvent : IClientEvent
  {
    private int roomId = 0;

    public JoinEvent(int roomId)
    {
      EventName = "JOIN  ";
      this.roomId = roomId;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(roomId));
      return body;
    }
  }
}