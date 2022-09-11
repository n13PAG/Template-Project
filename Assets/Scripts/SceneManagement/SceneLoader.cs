using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PAG
{
    public class SceneLoader : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private LoadSceneEventChannelSO _loadSceneEventChannel;

        
        private GameSceneSO _loadedScene;
        private AsyncOperation _loadingOperation;
        private AsyncOperation _unLoadingOperation;
        private bool _isLoading;
        private bool _isUnloading;

        private void Start()
        {
        }

        private void OnEnable()
        {
            _loadSceneEventChannel.OnEventRaised += LoadLevel;
        }

        private void OnDisable()
        {
            _loadSceneEventChannel.OnEventRaised += LoadLevel;
        }

        private void LoadLevel(GameSceneSO gameScene)
        {
            if (!_isLoading)
                StartCoroutine(LoadScene(gameScene));
        }

        private IEnumerator LoadScene(GameSceneSO gameScene)
        {
            _isLoading = true;
            _loadingOperation = SceneManager.LoadSceneAsync(gameScene.SceneName, LoadSceneMode.Additive);

            while (!_loadingOperation.isDone)
            {
                yield return null;
            }

            _loadingOperation = null;
            _isLoading = false;

            StartCoroutine(UnLoadScene());
        }

        private IEnumerator UnLoadScene()
        {
            if (_loadedScene != null)
            {
                _isUnloading = true;

                 _unLoadingOperation = SceneManager.UnloadSceneAsync(_loadedScene.SceneName);

                while (!_unLoadingOperation.isDone)
                {
                    yield return null;
                }

                _unLoadingOperation = null;
                _isUnloading = false;
            }
        }
    }
}
