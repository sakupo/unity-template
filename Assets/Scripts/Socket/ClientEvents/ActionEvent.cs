using System;
using System.Collections.Generic;
using PlasticGui;
using Utility.Binary;

namespace Socket.Events
{
  public class ActionEvent : ClientEvent
  {
    private int startFrame;
    private int bufferSize;
    private byte actions;
    public ActionEvent(byte actions, int bufferSize, int startFrame)
    {
      EventName = "ACTION";
      this.startFrame = startFrame;
      this.bufferSize = bufferSize;
      this.actions = actions;
    }
    public override List<byte> GetBytes()
    {
      List<byte> body = new List<byte>();
      BinUtil.AddBytes(body, startFrame);
      body.Add(Convert.ToByte(bufferSize));
      body.Add(0);
      body.Add(actions);
      return body;
    }
  }
}