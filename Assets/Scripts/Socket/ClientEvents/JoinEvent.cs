using System;
using System.Collections.Generic;

namespace Socket.Events
{
  public class JoinEvent : ClientEvent
  {
    private int roomId = 0;

    public JoinEvent(int roomId)
    {
      EventName = "JOIN  ";
      this.roomId = roomId;
    }
    public override List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(roomId));
      return body;
    }
  }
}