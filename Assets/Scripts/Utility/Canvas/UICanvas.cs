using Root;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Utility
{
  public class UICanvas : CanvasEx
  {
    [Inject] private ISceneManagerEx sm;

    protected override void Start()
    {
      ChangeCamera();
      InitAtStart();
    }

    protected void ChangeCamera()
    {
      // 親シーン(Root)のルートキャンバスを取得する
      var rootScene = sm.GetScene<RootScene>();
      var rootCanvas = rootScene.rootCanvas.GetCanvas();

      // 自身のシーン(Additive)のルートキャンバスを取得する
      var thisCanvas = GetCanvas();

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