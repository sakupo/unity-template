using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class ConnectionCloseEvent : IClientEvent
  {
    public ConnectionCloseEvent()
    {
      EventName = "SEEYA ";
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}