using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    [CreateAssetMenu(fileName ="GameScene", menuName ="Scenes/GameScene")]
    public class GameSceneSO : ScriptableObject 
    {
        public enum SceneType
        {
            Persistent,
            Menu,
            Level,
            SubLevel,
            Load
        }
        public string SceneName;
        public bool hasCustomLoadingScreen;
        public string LoadingSceneName;
    }
}
