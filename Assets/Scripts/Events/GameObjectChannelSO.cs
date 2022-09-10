using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PAG
{
    [CreateAssetMenu(fileName = "GameObjectEventChannel", menuName = "Events/GameObject Event Channel")]
    public class GameObjectChannelSO : ScriptableObject
    {
        public UnityAction<GameObject> OnEventRaised;

        public void RaiseEvent(GameObject obj)
        {
            OnEventRaised?.Invoke(obj);
        }
    }
}
