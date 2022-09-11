using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class AudioCue : MonoBehaviour
    {
        [Header("Audio Cue Data")]
        [SerializeField] private AudioCueSO _audioCue;
        [SerializeField] private bool _playOnStart;

        [Header("Audio Channel")]
        [SerializeField] private AudioEventChannel _audioChannel;

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
            //StopAudioCue();
        }
        private IEnumerator PlayDelayed()
        {
            //The wait allows the AudioManager to be ready for play requests
            yield return new WaitForSeconds(1f);

            //This additional check prevents the AudioCue from playing if the object is disabled or the scene unloaded
            //This prevents playing a looping AudioCue which then would be never stopped
            //if (_playOnStart)
                //PlayAudioCue();
        }
    }
}
