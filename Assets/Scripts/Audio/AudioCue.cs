using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class AudioCue : MonoBehaviour
    {
        [Header("Audio Cue Data")]
        [SerializeField] private AudioCueSO _audioCue;
        [SerializeField] private bool _playOnStart = false;

        [Header("Audio Channel")]
        [SerializeField] private AudioEventChannel _audioEventChannel;

        private void Start()
        {
            if (_playOnStart)
            {
                StartCoroutine(PlayDelayed());
            }
        }

        private void OnDisable()
        {
            _playOnStart = false;
        }
        private IEnumerator PlayDelayed()
        {
            //The wait allows the AudioManager to be ready for play requests
            yield return new WaitForSeconds(1f);

            //This additional check prevents the AudioCue from playing if the object is disabled or the scene unloaded
            //This prevents playing a looping AudioCue which then would be never stopped
            if (_playOnStart)
                PlayAudioCue();
        }

        [ContextMenu("Play Audio Cue")]
        public void PlayAudioCue()
        {
            _audioEventChannel.RaisePlayEvent(_audioCue, this);
        }

        [ContextMenu("Stop Audio Cue")]
        public void StopAudioCue()
        {
            _audioEventChannel.RaiseStopEvent(_audioCue);
        }

        [ContextMenu("Pause Audio Cue")]
        public void PauseAudioCue()
        {
            _audioEventChannel.RaisePauseEvent();
        }
    }
}
