using System;
using System.Collections.Generic;
using Socket.Demo;
using TMPro;
using Utility.Binary;

namespace Socket.ServerEvents
{
  public class Room1Event : IServerEvent
  {
    private TextMeshPro tmpro;
    private GameRoom roomInfo;
    byte myNumber;
    private TcpClient tcpClient;
    private GameManager gameMgr;

    public Room1Event(byte[] body)
    {
      int pos = 0;
      int roomId = Convert.ToInt32(body[pos++]);
      int memberCount = Convert.ToInt32(body[pos++]);
      List<Player> members = new List<Player>();
      for (int memberIndex = 0; memberIndex < memberCount; memberIndex++)
      {
        byte userNameLen = body[pos++];
        string userName = BinUtil.BytesToString(body, pos, userNameLen);
        pos += userNameLen;
        var options = new byte[] { body[pos], body[pos + 1], body[pos + 2] };
        pos += 3;
        members.Add(new Player(userName, options));
      }

      byte battleType = body[pos++];
      byte num = body[pos++];
      roomInfo = new GameRoom(roomId, members, battleType, num);
      myNumber = body[pos++];
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      tmpro = options["state"] as TextMeshPro;
      tcpClient = options["client"] as TcpClient;
      gameMgr = options["gameManager"] as GameManager;
    }

    public void Call()
    {
      tmpro.text = myNumber.ToString();
      gameMgr.PlayerNum = myNumber;
      /*if (roomInfo.Members.Count == 2)
      {
        var ev = new ClientEvents.ReadyEvent(0);
        tcpClient.Send(ev);
      }*/
    }
  }
}