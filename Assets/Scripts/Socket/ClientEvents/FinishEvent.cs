using System.Collections.Generic;

namespace Socket.Events
{
  public class FinishEvent : ClientEvent
  {
    public FinishEvent()
    {
      EventName = "FINISH";
    }
    public override List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}