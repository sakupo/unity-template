using System;
using System.Collections.Generic;
using Utility.Binary;

namespace Socket.ClientEvents
{
  public class ActionEvent : IClientEvent
  {
    private int startFrame;
    private int bufferSize;
    private byte[] actions;

    public ActionEvent(byte[] actions, int bufferSize, int startFrame)
    {
      EventName = "ACTION";
      this.startFrame = startFrame;
      this.bufferSize = bufferSize;
      this.actions = actions;
    }

    public string EventName { get; }

    public List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      BinUtil.AddBytes(body, startFrame);
      body.Add(Convert.ToByte(bufferSize));
      body.Add(0);
      foreach (var action in actions)
      {
        body.Add(action);
      }

      return body;
    }
  }
}