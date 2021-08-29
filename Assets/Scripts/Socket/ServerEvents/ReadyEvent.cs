using System;
using System.Collections.Generic;
using Socket.Demo;

namespace Socket.ServerEvents
{
  public class ReadyEvent : IServerEvent
  {
    private int playerNum;
    private GameManager gameMgr;

    public ReadyEvent(byte[] body)
    {
      playerNum = body[0];
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      gameMgr = (GameManager)options["gameManager"];
    }

    public void Call()
    {
      gameMgr.phase = gameMgr.phase + 1;
    }
  }
}