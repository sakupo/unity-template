using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class PongEvent : IClientEvent
  {
    private List<byte> pastPingTime;

    public PongEvent(List<byte> pastPingTime)
    {
      EventName = "PONG  ";
      this.pastPingTime = pastPingTime;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return pastPingTime;
    }
  }
}