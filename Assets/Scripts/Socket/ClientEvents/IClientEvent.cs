using System.Collections.Generic;

namespace Socket
{
  public interface IClientEvent
  {
    // must eventName.length == 6
    public string EventName { get; }
    public List<byte> GetBytes();
  }
}