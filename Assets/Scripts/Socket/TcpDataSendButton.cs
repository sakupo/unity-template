using System;
using System.IO;
using Socket.Events;
using TMPro;
using UnityEditor;
using UnityEngine;
using Debug = Utility.Debug;

namespace Socket
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
    [SerializeField] private int roomId= 0;
    [SerializeField] private int randomNum;
    [SerializeField] private byte action;

    private void Start()
    {
      textObj = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClick()
    {
      ClientEvent ev;
      switch (eventName)
      {
        case "hello":
          ev = new HelloEvent(userName, options);
          break;
        case "create":
          ev = new CreateEvent(battleType, num);
          break;
        case "join":
          ev = new JoinEvent(roomId);
          break;
        case "exit":
          ev = new ExitEvent();
          break;
        case "ready":
          ev = new ReadyEvent(randomNum);
          break;
        case "ok":
          ev = new OkEvent(randomNum);
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