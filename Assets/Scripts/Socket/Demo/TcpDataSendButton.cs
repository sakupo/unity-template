using System;
using System.Collections.Generic;
using System.IO;
using Socket.ClientEvents;
using TMPro;
using UnityEditor;
using UnityEngine;
using Debug = Utility.Debug;

namespace Socket.Demo
{
  public class TcpDataSendButton : MonoBehaviour
  {
    private TextMeshProUGUI textObj;
    [SerializeField] private string eventName = "hello";
    [SerializeField] private string userName = "";
    [SerializeField] private byte[] options = new byte[3];
    [SerializeField] private int battleType = 0;
    [SerializeField] private int num = 0;
    [SerializeField] private TcpClient tcpClient;
    [SerializeField] private byte playerNum = 0;
    public TcpClient TcpClient
    {
      get => tcpClient;
      set
      {
        if (tcpClient == null)
        {
          tcpClient = value;
        }
      }
    }

    public int roomId= 0;
    [SerializeField] private int randomNum;
    [SerializeField] private byte[] action = new byte[16];

    private void Start()
    {
      textObj = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClick()
    {
      IClientEvent ev;
      switch (eventName)
      {
        case "hello":
          ev = new HelloEvent(userName, options);
          eventName = (userName == "client1") ? "create" : "rooms";
          break;
        case "seeya":
          ev = new ConnectionCloseEvent();
          break;
        case "rooms":
          ev = new RoomsEvent();
          eventName = "ok";
          break;
        case "xrooms":
          ev = new XRoomsEvent();
          break;
        case "create":
          ev = new CreateEvent(battleType, num);
          eventName = "ok";
          break;
        case "join":
          ev = new JoinEvent(roomId);
          break;
        case "exit":
          ev = new ExitEvent();
          break;
        case "pong":
          ev = new PongEvent(new List<byte>());
          break;
        case "ready":
          ev = new ReadyEvent(playerNum);
          break;
        case "ok":
          ev = new OkEvent(playerNum);
          break;
        case "action":
          ev = new ActionEvent(action, 16, 0);
          break;
        case "finish":
          ev = new FinishEvent();
          break;
        case "next":
          ev = new NextEvent(randomNum);
          break;
        case "log":
          ev = new LogEvent("log");
          break;
        case "error":
          ev = new ErrorEvent();
          break;
        default:
          return;
      }
      tcpClient.Send(ev);
    }
  }
}