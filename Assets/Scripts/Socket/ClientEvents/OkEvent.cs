using System;
using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class OkEvent : IClientEvent
  {
    private byte playerNum;

    public OkEvent(byte playerNum)
    {
      EventName = "OKAY  ";
      this.playerNum = playerNum;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(playerNum));
      return body;
    }
  }
}