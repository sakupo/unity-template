using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Debug = Utility.Debug;

namespace Socket
{
  class TcpClient: MonoBehaviour
  {
    TcpConnector connector;
    private Parser parser;
    private Sender sender;

    void Start()
    {
      string addr = "127.0.0.1";
      int port = 31117;
      connector = new TcpConnector();
      connector.SetConnectInfo(addr, port);
      // 切断している場合は接続
      if (!connector.IsConnected)
      {
        connector.Connect();
      }
      parser = new Parser();
      sender = new Sender();
      Thread thread = new Thread(new ThreadStart(Receive));
      thread.Start();
    }

    public void Send(ClientEvent ev)
    {
      var data = sender.CreateBinary(ev);
      Send(data);
    }

    void Send(byte[] data)
    {
      // 接続している場合
      if (connector.IsConnected)
      {
        connector.Send(data);
      }
    }

    void Receive()
    {
      while (connector.IsConnected)
      {
        try
        {
          // 受信データの解析処理
          ServerEvent serverEvent = parser.ReadAndParse(connector);
          serverEvent.Call();
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