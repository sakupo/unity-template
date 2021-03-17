using UnityEngine;
using UnityEngine.EventSystems;

namespace Utility
{
    public class Button : MonoBehaviour
    {

        [SerializeField]
        ButtonController buttonController;

        public void OnClick(BaseEventData data)
        {
            if (buttonController == null)
            {
                throw new System.Exception("Button controller is not set.");
            }
            Debug.Log("Clicked");
            buttonController.OnClick(gameObject.name);
        }
    }
}