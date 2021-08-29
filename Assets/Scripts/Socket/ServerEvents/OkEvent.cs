using System;
using System.Collections.Generic;
using Socket.Demo;

namespace Socket.ServerEvents
{
  public class OkEvent: IServerEvent
  {
    private int playerNum;
    private GameManager gameMgr;

    public OkEvent(byte[] body)
    {
      playerNum = body[0];
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      gameMgr = (GameManager) options["gameManager"];
    }

    public void Call()
    {
      lock (gameMgr.IsOk)
      {
        gameMgr.IsOk[playerNum] = true;
      }
    }
  }
}