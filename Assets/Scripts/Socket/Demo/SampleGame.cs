using TMPro;
using UnityEngine;

namespace Socket.Demo
{
  public class SampleGame: MonoBehaviour, ISyncGame
  {
    [SerializeField] private GameManager gameMgr;
    [SerializeField] private TextMeshPro tmpro;

    private void Start()
    {
      tmpro.text = "";
    }

    public void UpdateGame(GameManager gameMgr, byte[,] actions)
    {
      for (int i = 0; i < gameMgr.totalNoOfPlayer; i++)
      {
        for (int j = 0; j < gameMgr.bufferSize; j++)
        {
          if (actions[i, j] == 0) break;
          switch (actions[i, j])
          {
            case 1:
              tmpro.text += (i + 1)+"Pw\n";
              break;
            case 3:
              tmpro.text += (i + 1)+"Ps\n";
              break;
          }
        }
      }
    }

    public void OnUpPressed()
    {
      gameMgr.OnAnyKeyPressed(1);
    }

    public void OnDownPressed()
    {
      gameMgr.OnAnyKeyPressed(3);
    }
  }
}