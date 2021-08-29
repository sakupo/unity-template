using System.Collections.Generic;

namespace Socket.ClientEvents
{
  public class FinishEvent : IClientEvent
  {
    public FinishEvent()
    {
      EventName = "FINISH";
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      return new List<byte>();
    }
  }
}