using UnityEngine;

namespace PAG
{
    public class GameManager : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannelSO _onSceneReadyChannel;
        [SerializeField] private VoidEventChannelSO _onPersistentSceneReadyChannel;

        private void OnEnable()
        {
            _onPersistentSceneReadyChannel.OnEventRaised += SceneStartUp;
        }

        private void OnDisable()
        {
            _onPersistentSceneReadyChannel.OnEventRaised -= SceneStartUp;
        }

        private void SceneStartUp()
        {
            _onSceneReadyChannel.OnEventRaised?.Invoke();
        }
    }
}
