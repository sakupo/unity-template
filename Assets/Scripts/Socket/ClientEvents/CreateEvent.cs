using System;
using System.Collections.Generic;

namespace Socket.Events
{
  public class CreateEvent : ClientEvent
  {
    private int battleType = 0;
    private int num = 0;

    public CreateEvent(int battleType, int num)
    {
      EventName = "CREATE";
      this.battleType = battleType;
      this.num = num;
    }
    public override List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(battleType));
      body.Add(Convert.ToByte(num));
      return body;
    }
  }
}