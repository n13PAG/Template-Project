using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PAG
{
    public class PreSceneLoad : MonoBehaviour
    {
        [SerializeField] private GameSceneSO _persistentScene;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private void LoadPersistentScene()
        {
           
        }
    }
}
