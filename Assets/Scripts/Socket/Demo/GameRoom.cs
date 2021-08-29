using System.Collections.Generic;

namespace Socket.Demo
{
  public class GameRoom
  {
    public readonly int RoomId;
    public readonly List<Player> Members;
    public readonly byte BattleType;
    public readonly byte Num;

    public GameRoom(int roomId, List<Player> members, byte battleType, byte num)
    {
      RoomId = roomId;
      Members = members;
      BattleType = battleType;
      Num = num;
    }
  }
}