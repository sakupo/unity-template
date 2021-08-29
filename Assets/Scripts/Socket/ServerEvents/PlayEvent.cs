using System;
using System.Collections.Generic;
using Socket.Demo;
using UnityEngine;
using Object = System.Object;

namespace Socket.ServerEvents
{
  public class PlayEvent: IServerEvent
  {
    private Int64 randomNum;
    private GameManager gameMgr;

    public PlayEvent(byte[] body)
    {
      randomNum = BitConverter.ToInt64(body, 0);
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      gameMgr = (GameManager) options["gameManager"];
    }

    public void Call()
    {
      gameMgr.phase = gameMgr.phase + 1;
      gameMgr.RandomNum = randomNum;
      Debug.Log(randomNum);
    }
  }
}