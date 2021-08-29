using System;
using System.Collections.Generic;

namespace Socket.ServerEvents
{
  public class ConnectionCloseEvent: IServerEvent
  {
    private TcpConnector connector;
    public ConnectionCloseEvent(TcpConnector connector)
    {
      this.connector = connector;
    }

    public void SetOptions(Dictionary<string, Object> options)
    {
      return;
    }

    public void Call()
    {
      connector.Disconnect();
    }
  }
}