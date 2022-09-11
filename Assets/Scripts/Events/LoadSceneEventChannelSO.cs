using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PAG
{
    [CreateAssetMenu(fileName = "LoadSceneEventChannel", menuName = "Events/Load Scene Event Channel")]
    public class LoadSceneEventChannelSO : ScriptableObject
    {
        public UnityAction<GameSceneSO> OnEventRaised;

        public void RaiseEvent(GameSceneSO gameScene)
        {
            OnEventRaised?.Invoke(gameScene);
        }
    }
}
