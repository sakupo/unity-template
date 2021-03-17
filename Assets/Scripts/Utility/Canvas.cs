using TMPro;
using UnityEngine;

namespace Utility
{
    public abstract class Canvas : MonoBehaviour
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
        protected abstract void Init();
    }
}