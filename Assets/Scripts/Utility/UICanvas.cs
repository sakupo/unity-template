using System;
using System.Linq;
using Cysharp.Threading.Tasks.Triggers;
using Root;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Utility
{
  public class UICanvas : CanvasEx
  {
    private void Start()
    {
      ChangeCamera("RootScene");
    }

    protected void ChangeCamera(String toSceneName)
    {
      // 親シーン(Root)のルートキャンバスを取得する
      var rootCanvas = RootScene.Instance.rootCanvas.GetCanvas();

      // 自身のシーン(Additive)のルートキャンバスを取得する
      var thisCanvas = GetComponent<Canvas>();

      // 自身のシーン(Additive)のルートキャンバスのUIカメラを削除する
      if (thisCanvas.worldCamera != null)
      {
        Destroy(thisCanvas.worldCamera.gameObject);
        thisCanvas.worldCamera = null;
      }

      // 自身のシーン(Additive)のルートキャンバスのUIカメラを親シーン(Root)のカメラに置き換える
      thisCanvas.worldCamera = rootCanvas.worldCamera;
    }

    protected void CreateEventSystem()
    {
      // EventSystem シングルトンインスタンスが存在しない場合，
      // EventSystemの動的生成
      if (EventSystem.current == null)
      {
        var instance = new GameObject("EventSystem");
        EventSystem.current = instance.AddComponent<EventSystem>();

        // InputModuleの追加
        instance.AddComponent<StandaloneInputModule>();
      }
    }
  }
}