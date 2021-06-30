using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
  public abstract class CanvasEx : MonoBehaviour
  {

    protected virtual void Start()
    {
      InitAtStart();
    }

    public void ShowCanvas()
    {
      gameObject.SetActive(true);
      Init();
    }

    public void HideCanvas()
    {
      gameObject.SetActive(false);
    }

    protected virtual void Init()
    {
      /* do nothing */
    }

    protected virtual void InitAtStart()
    {
      /* do nothing */
    }

    public Canvas GetCanvas()
    {
      return gameObject.GetComponent<Canvas>();
    }

    public static Canvas GetCanvasFromScene(string sceneName)
    {
      var canvas = SceneManager.GetSceneByName(sceneName).GetRootGameObjects()
        .First(obj => obj.GetComponent<Canvas>() != null)
        .GetComponent<Canvas>();
      return canvas;
    }
  }
}