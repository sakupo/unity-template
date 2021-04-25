using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
  public class SceneManagerEx : MonoBehaviour
  {
    public static SceneManagerEx Instance { get; private set; }
    private HashSet<SceneEx> activeScenes = new HashSet<SceneEx>();
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

    private void Start()
    {
      // 初期シーンの登録
      if (activeScenes.Count == 0)
      {
        var scenes = Resources.FindObjectsOfTypeAll<SceneEx>();
        foreach (var scene in scenes)
        {
          activeScenes.Add(scene);
        }
      }
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
      activeScenes.Add(nextScene);
      nextScene.OnLoad(options);
    }

    public async UniTask UnloadSceneAsync<T>() where T : SceneEx
    {
      String sceneName = "Scenes/" + typeof(T).Name;
      var scene = GetScene<T>();
      if (scene is null) return;
      if (activeScenes.Contains(scene))
      {
        await SceneManager.UnloadSceneAsync(sceneName);
        activeScenes.Remove(scene);
      }
    }

    public T GetScene<T>() where T : SceneEx
    {
      foreach (var scene in activeScenes)
      {
        if (scene is T)
        {
          return (T) scene;
        } 
      }
      return null;
    }
  }
}