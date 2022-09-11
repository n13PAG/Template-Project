using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class Initializer : MonoBehaviour
    {
        public static Initializer Instance;

        [Header("Event Channels")]
        [SerializeField] private LoadSceneEventChannelSO _loadSceneEventChannel;

        [Header("Startup Scene")]
        [SerializeField] private GameSceneSO _startUpScene;

        private bool _startUpLoaded = false;
    }
}
