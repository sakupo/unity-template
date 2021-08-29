using System.Collections.Generic;
using static Utility.Binary.BinUtil;

namespace Socket.ClientEvents
{
  public class LogEvent : IClientEvent
  {
    private string message;

    public LogEvent(string message)
    {
      EventName = "LOG   ";
      this.message = message;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      AddBytes(body, message);
      return body;
    }
  }
}