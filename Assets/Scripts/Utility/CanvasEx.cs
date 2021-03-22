using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Utility
{
  public abstract class CanvasEx : MonoBehaviour
  {
    public TextMeshProUGUI title;

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

    public Canvas GetCanvas()
    {
      return gameObject.GetComponent<Canvas>();
    }
  }
}