using UnityEngine;
using UnityEngine.SceneManagement;

namespace PAG
{
    public class PersistentSceneLoader : MonoBehaviour
    {
#if UNITY_EDITOR

        [SerializeField] private GameSceneSO _persistentSceneSO;
        [SerializeField] private VoidEventChannelSO _onPersistentSceneReadyChannel;
        private bool _loadPersistentScene = true;

        private void Awake()
        {
            int sceneCount = SceneManager.sceneCount;

            for (int i = 0; i < sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == _persistentSceneSO.SceneName)
                {
                    _loadPersistentScene = false;
                }
            }

            if (_loadPersistentScene)
                // Load Persistent scene
                SceneManager.LoadSceneAsync(_persistentSceneSO.SceneName, LoadSceneMode.Additive).completed += PresistentSceneLoader_completed;
        }

        private void PresistentSceneLoader_completed(AsyncOperation obj)
        {
            _onPersistentSceneReadyChannel.OnEventRaised?.Invoke();
        }

#endif
    }
}
