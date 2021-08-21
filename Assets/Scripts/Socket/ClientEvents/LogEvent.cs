using System.Collections.Generic;
using Utility.Binary;
using static Utility.Binary.BinUtil;
namespace Socket.Events
{
  public class LogEvent : ClientEvent
  {
    private string message;
    public LogEvent(string message)
    {
      EventName = "LOG   ";
      this.message = message;
    }
    public override List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      AddBytes(body, message);
      return body;
    }
  }
}