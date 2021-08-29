using System;
using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class ReadyEvent : IClientEvent
  {
    private byte playerNum;
    public ReadyEvent(byte playerNum)
    {
      EventName = "READY ";
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