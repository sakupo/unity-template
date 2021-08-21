using System.Collections.Generic;

namespace Socket.Events
{
  public class ErrorEvent : ClientEvent
  {
    public override List<byte> GetBytes()
    {
      throw new System.NotImplementedException();
    }
  }
}