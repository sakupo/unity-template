using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class ExitEvent : IClientEvent
  {
    public ExitEvent()
    {
      EventName = "EXIT  ";
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}