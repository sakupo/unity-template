using System;
using System.Collections.Generic;
using System.Linq;
using Socket.Demo;
using UnityEngine;
using Object = System.Object;

namespace Socket.ServerEvents
{
  public class ActionEvent : IServerEvent
  {
    private int frame;
    private int bufferSize;
    private int playerNum;
    private byte[] actions;
    private GameManager gameMgr;
    private byte[,] actionBuffers;

    public ActionEvent(byte[] body)
    {
      int pos = 0;
      frame = BitConverter.ToInt32(body, pos);
      pos += 4;
      bufferSize = body[pos++];
      playerNum = body[pos++];
      actions = new byte[bufferSize];
      for (int i = 0; i < bufferSize; i++)
      {
        if (body[pos] != 0) Debug.Log(body[pos]);
        actions[i] = body[pos++];
      }
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      gameMgr = (GameManager)options["gameManager"];
    }

    public void Call()
    {
      for (int i = 0; i < bufferSize; i++)
      {
        gameMgr.ActionBuffers[playerNum, i] = actions[i];
      }

      gameMgr.latestFrames[playerNum] = frame;
      gameMgr.latestFrame = gameMgr.latestFrames.Min();
    }
  }
}