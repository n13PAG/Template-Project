using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PAG
{
    [CreateAssetMenu(fileName ="AudioChannel", menuName ="Events/AudioChannel")]
    public class AudioEventChannel : ScriptableObject
    {
        public UnityEvent OnAudioCuePlayRequested;
        public UnityEvent OnAudioCueStopRequested;
        public UnityEvent OnAudioCueFinishRequested;

        public void RaisePlayEvent(AudioCueSO audioCue, Vector3 position)
        {

        }
    }
}
