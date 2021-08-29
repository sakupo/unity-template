using UnityEngine;
using UnityEngine.EventSystems;

namespace Utility
{
  public class ButtonEx : MonoBehaviour
  {
    [SerializeField] ButtonController buttonController;

    public void OnClick(BaseEventData data)
    {
      if (buttonController == null)
      {
        throw new System.Exception("ButtonEx controller is not set.");
      }

      Debug.Log("Clicked");
      buttonController.OnClick(gameObject.name);
    }
  }
}