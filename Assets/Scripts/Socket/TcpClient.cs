using System;
using System.Threading;
using TMPro;
using UnityEngine;
using Debug = Utility.Debug;

namespace Socket
{
  public class TcpClient: MonoBehaviour
  {
    public TcpConnector Connector { get; private set; }
    private Parser parser;
    private Sender sender;
    [SerializeField] private ServerEventManager serverEventManager; 
    /// <summary>
    /// for debug text
    /// </summary>
    [SerializeField] private TextMeshPro tmpro;

    void Start()
    {
      string addr = "127.0.0.1";
      int port = 31117;
      Connector = new TcpConnector();
      Connector.SetConnectInfo(addr, port);
      Connector.Connect();
      parser = new Parser();
      sender = new Sender();
      Thread thread = new Thread(Receive);
      thread.Start();
    }

    private void Update()
    {
      serverEventManager.CallEvents();
    }

    public void Send(IClientEvent ev)
    {
      var data = sender.CreateBinary(ev);
      Send(data);
    }

    void Send(byte[] data)
    {
      // 接続している場合
      if (Connector.IsConnected)
      {
        Connector.Send(data);
      }
    }

    void Receive()
    {
      while (Connector.IsConnected)
      {
        try
        {
          // 受信データの解析処理
          IServerEvent serverEvent = parser.ReadAndParse(this); 
          serverEventManager.AddEvent(serverEvent);
        }
        catch (Exception ex)
        {
          // 例外の内容に応じた処理を行う
          Debug.Log(ex.Message);
        }
      }
    }
  }
}