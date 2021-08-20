namespace Socket.ServerEvents
{
  public class ConnectionCloseEvent: ServerEvent
  {
    private TcpConnector connector;
    public ConnectionCloseEvent(TcpConnector connector)
    {
      this.connector = connector;
    }

    public override void Call()
    {
      connector.Disconnect();
    }
  }
}