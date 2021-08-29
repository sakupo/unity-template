namespace Socket.Demo
{
  public class Player
  {
    public readonly string UserName;
    public readonly byte[] Options;

    public Player(string userName, byte[] options)
    {
      UserName = userName;
      Options = options;
    }
  }
}