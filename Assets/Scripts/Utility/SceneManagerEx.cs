using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
  public class SceneManagerEx : MonoBehaviour
  {
    public static SceneManagerEx Instance { get; private set; }
    [SerializeField] GameObject goLoadingBarrier;

    void Awake()
    {
      if (Instance != null)
      {
        Destroy(gameObject);
        return;
      }

      DontDestroyOnLoad(gameObject);
      Instance = this;
      goLoadingBarrier.SetActive(false);
    }

    public async UniTask LoadSceneAsync<T>(SceneInfo options = null, LoadSceneMode mode = LoadSceneMode.Additive)
      where T : SceneEx
    {
      goLoadingBarrier.SetActive(true);
      String sceneName = "Scenes/" + typeof(T).Name;
      await SceneManager.LoadSceneAsync(sceneName, mode);
      goLoadingBarrier.SetActive(false);
      var nextScene = FindObjectOfType<T>();
      if (nextScene is null)
        throw new System.Exception(sceneName + " is Null");

      nextScene.OnLoad(options);
    }

    public async UniTask UnloadSceneAsync<T>() where T : SceneEx
    {
      String sceneName = "Scenes/" + typeof(T).Name;
      await SceneManager.UnloadSceneAsync(sceneName);
    }
  }
}