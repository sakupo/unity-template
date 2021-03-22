using UnityEngine;
using Utility;

namespace Root
{
  public class RootScene : SceneEx
  {
    [field: SerializeField] public CanvasEx rootCanvas { get; private set; }
    public static RootScene Instance { get; private set; } = null;

    void Awake()
    {
      if (Instance != null)
      {
        Destroy(gameObject);
        return;
      }

      Instance = this;
    }
  }
}