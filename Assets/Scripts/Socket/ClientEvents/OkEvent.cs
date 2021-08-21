using System;
using System.Collections.Generic;

namespace Socket.Events
{
  public class OkEvent : ClientEvent
  {
    private int randomNum;

    public OkEvent(int randomNum)
    {
      EventName = "OKEY  ";
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