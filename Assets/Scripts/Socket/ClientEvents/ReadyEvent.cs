using System;
using System.Collections.Generic;

namespace Socket.Events
{
  public class ReadyEvent : ClientEvent
  {
    private int randomNum;
    public ReadyEvent(int randomNum)
    {
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