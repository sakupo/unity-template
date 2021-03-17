using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneManagerEx : MonoBehaviour {
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

        public async UniTask LoadSceneAsync<T> (SceneInfo options = null, LoadSceneMode mode = LoadSceneMode.Single)
            where T : Scene { 
            goLoadingBarrier.SetActive(true);
            await SceneManager.LoadSceneAsync("Scenes/"+typeof(T).Name, mode);
            goLoadingBarrier.SetActive(false);
            var nextScene = FindObjectOfType<T>();
            if(nextScene is null)
                throw new System.Exception(typeof(T).Name + " is Null");

            nextScene.OnLoad(options);
        }
    }
}