using UnityEngine.PlayerLoop;

namespace Socket.Demo
{
  public interface ISyncGame
  {
    void UpdateGame(GameManager gameMgr, byte[,] actionBuffers);
  }
}