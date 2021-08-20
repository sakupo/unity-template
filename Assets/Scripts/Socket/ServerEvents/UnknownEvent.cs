using Utility;

namespace Socket.ServerEvents
{
  public class UnknownEvent: ServerEvent
  {
    private readonly string message;
    public UnknownEvent(string message)
    {
      this.message = message;
    }
    public override void Call()
    {
      Debug.Log(message);
    }
  }
}