using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class ErrorEvent : IClientEvent
  {
    public ErrorEvent()
    {
      EventName = "ERROR!";
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}