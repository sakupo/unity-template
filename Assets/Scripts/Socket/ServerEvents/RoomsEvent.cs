using System;
using System.Collections.Generic;
using System.Text;
using Socket.Demo;
using TMPro;
using UnityEngine;
using Utility;
using Utility.Binary;
using Object = System.Object;

namespace Socket.ServerEvents
{
  public class RoomsEvent: IServerEvent
  {
    private TextMeshPro tmpro;
    private GameObject roomsView;
    private List<GameRoom> rooms = new List<GameRoom>();
    private GameObject roomsViewItemPrefab;
    private TcpClient tcpClient;

    public RoomsEvent(byte[] body, TcpClient tcpClient)
    {
      this.tcpClient = tcpClient;
      int pos = 0;
      int roomCount = Convert.ToInt32(body[pos++]);
      for (int i = 0; i < roomCount; i++)
      {
        int roomId = Convert.ToInt32(body[pos++]);
        int memberCount = Convert.ToInt32(body[pos++]);
        List<Player> members = new List<Player>();
        for (int memberIndex = 0; memberIndex < memberCount; memberIndex++)
        {
          byte userNameLen = body[pos++];
          string userName = BinUtil.BytesToString(body, pos, userNameLen);
          pos += userNameLen;
          var options = new byte[]{body[pos], body[pos+1], body[pos+2]};
          pos += 3;
          members.Add(new Player(userName, options));
        }
        byte battleType = body[pos++];
        byte num = body[pos++];
        rooms.Add(new GameRoom(roomId, members, battleType, num));
      }
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      tmpro = options["state"] as TextMeshPro;
      roomsView = options["roomsView"] as GameObject;
      roomsViewItemPrefab = options["roomsViewItemPrefab"] as GameObject;
    }

    public void Call()
    {
      tmpro.text = "ROOMS";
      foreach (var t in roomsView.GetComponentsInChildrenWithoutSelf<Transform>())
      {
        UnityEngine.Object.Destroy(t.gameObject);
      }
      var sb = new StringBuilder();
      foreach (var gameRoom in rooms)
      {
        sb.Append(gameRoom.RoomId + "/")
          .Append(gameRoom.Members[0].UserName + "/")
          .Append(gameRoom.BattleType + "/")
          .Append(gameRoom.Num+"\n");
        GameObject roomsViewItem = UnityEngine.Object.Instantiate(roomsViewItemPrefab, roomsView.transform);
        var roomsViewItemTmpro = roomsViewItem.GetComponentInChildren<TextMeshProUGUI>();
        var roomViewItemSendButton = roomsViewItem.GetComponent<TcpDataSendButton>();
        roomViewItemSendButton.TcpClient = tcpClient;
        roomViewItemSendButton.roomId = gameRoom.RoomId;
        roomsViewItemTmpro.text = sb.ToString();
      }
    }
  }
}