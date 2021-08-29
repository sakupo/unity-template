using System;
using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class NextEvent : IClientEvent
  {
    private int randomNum;

    public NextEvent(int randomNum)
    {
      EventName = "NEXT  ";
      this.randomNum = randomNum;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(randomNum));
      return body;
    }
  }
}