using System;
using System.Collections.Generic;
using static Utility.Binary.BinUtil;

namespace Socket.ClientEvents
{
  public class HelloEvent : IClientEvent
  {
    public string UserName { get; private set; }
    public byte[] Options { get; private set; }

    public HelloEvent(string userName, byte[] options)
    {
      EventName = "HELLO ";
      UserName = userName;
      Options = options;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      body.Add(Convert.ToByte(UserName.Length));
      AddBytes(body, UserName);
      AddBytes(body, Options);
      return body;
    }
  }
}