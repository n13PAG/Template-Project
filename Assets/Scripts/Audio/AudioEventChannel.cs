using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PAG
{
    [CreateAssetMenu(fileName ="AudioChannel", menuName ="Events/AudioChannel")]
    public class AudioEventChannel : ScriptableObject
    {
        public UnityAction<AudioCueSO, AudioCue> OnAudioCuePlayRequested;
        public UnityAction<AudioCueSO> OnAudioCueStopRequested;
        public UnityAction<AudioCueSO> OnAudioCueFinishRequested;
        public UnityAction OnAudioCuePauseRequested;

        public void RaisePlayEvent(AudioCueSO audioCueSO, AudioCue audioCue)
        {
            OnAudioCuePlayRequested?.Invoke(audioCueSO, audioCue);
        }

        public void RaiseStopEvent(AudioCueSO audioCue)
        {
            OnAudioCueStopRequested?.Invoke(audioCue);
        }

        public void RaiseFinishEvent(AudioCueSO audioCue)
        {
            OnAudioCueFinishRequested?.Invoke(audioCue);
        }

        public void RaisePauseEvent()
        {
            OnAudioCuePauseRequested?.Invoke();
        }
    }
}
