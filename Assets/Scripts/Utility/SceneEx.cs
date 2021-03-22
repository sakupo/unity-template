using UnityEngine;

namespace Utility
{
  public abstract class SceneEx : MonoBehaviour
  {
    public SceneInfo SceneInfo { get; private set; }

    void Awake()
    {
    }

    public void OnLoad(SceneInfo sceneInfo)
    {
      this.SceneInfo = sceneInfo;
      OnLoad();
    }

    public virtual void OnLoad()
    {
      // 実装してもしなくても良い
    }
  }
}