using System;
using Socket.Events;
using TMPro;
using UnityEngine;
using Debug = Utility.Debug;

namespace Socket
{
  public class TcpDataSendButton : MonoBehaviour
  {
    private TextMeshProUGUI textObj;
    [SerializeField] private string userName = "";
    [SerializeField] private byte[] options = new byte[3];
    [SerializeField] private TcpClient tcpClient;
    private void Start()
    {
      textObj = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClick()
    {
      ClientEvent ev;
      switch (textObj.text)
      {
        case "hello":
          ev = new HelloEvent(userName, options);
          break;
        default:
          return;
      }
      tcpClient.Send(ev);
    }
  }
}