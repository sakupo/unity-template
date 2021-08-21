using System.Collections.Generic;

namespace Socket.Events
{
  public class ExitEvent : ClientEvent
  {
    public ExitEvent()
    {
      EventName = "EXIT  ";
    }
    public override List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}