using UnityEngine;
namespace Utility
{
    public abstract class Scene : MonoBehaviour
    {
        public SceneInfo SceneInfo  { get; private set; } 
        public static Scene Instance { get; private set; } = null;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
        
        public void OnLoad(SceneInfo sceneInfo)
        {
            this.SceneInfo = sceneInfo;
            OnLoad();
        }

        public virtual void OnLoad()
        {
            // 実装してもしなくても良い
        }

    }
}