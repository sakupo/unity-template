using System;
using System.Collections.Generic;

namespace Socket.Events
{
  public class NextEvent : ClientEvent
  {
    private int randomNum;

    public NextEvent(int randomNum)
    {
      EventName = "NEXT  ";
      this.randomNum = randomNum;
    }
    public override List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(randomNum));
      return body;
    }
  }
}