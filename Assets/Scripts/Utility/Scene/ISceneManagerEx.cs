using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Utility
{
  public interface ISceneManagerEx
  {
    public UniTask LoadSceneAsync<T>(SceneInfo options = null, LoadSceneMode mode = LoadSceneMode.Additive)
      where T : SceneEx;

    public UniTask UnloadSceneAsync<T>() where T : SceneEx;
    public T GetScene<T>() where T : SceneEx;
    public void SetScene<T>() where T : SceneEx;
  }
}