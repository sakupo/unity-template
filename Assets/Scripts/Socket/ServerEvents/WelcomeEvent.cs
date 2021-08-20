using Utility;

namespace Socket.ServerEvents
{
  public class WelcomeEvent: ServerEvent
  {
    public override void Call()
    {
      Debug.Log("Welcome!");
    }
  }
}