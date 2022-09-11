using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class SoundSource : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioEventChannel _audioEventChannel;
        private AudioCueSO _audioCueSO;
        public void SetChannel(AudioEventChannel channel)
        {
            _audioEventChannel = channel;
        }
        private bool hasStoppedPlaying = false;
        private bool isPaused = false;

        private void OnEnable()
        {
            if (_audioSource == null)
                _audioSource = GetComponent<AudioSource>();

            hasStoppedPlaying = false;
        }

        private void Update()
        {
            if (!_audioSource.isPlaying && !hasStoppedPlaying)
            {
                hasStoppedPlaying = true;
                _audioEventChannel.RaiseFinishEvent(_audioCueSO);
            }
        }

        public void PlayAudio(AudioCueSO audioCueSO)
        {
            // Set AudioSource Settings
            _audioSource.priority = audioCueSO._priority;
            _audioSource.volume = audioCueSO._volume;
            _audioSource.pitch = audioCueSO._pitch;
            _audioSource.loop = audioCueSO.looping;

            _audioCueSO = audioCueSO;

            audioCueSO.SetSoundSource(this);

            switch (audioCueSO._audioType)
            {
                case AudioCueSO.AudioType.Music:

                    if (!isPaused)
                    {
                        _audioSource.clip = audioCueSO._audioClip;
                    }

                    _audioSource.Play();
                    isPaused = false;

                    break;
                case AudioCueSO.AudioType.SFX:

                    // Play SFX
                    _audioSource.PlayOneShot(audioCueSO._audioClip);

                    break;
            }
        }

        public void PauseAudio()
        {
            if (!_audioSource.isPlaying)
            {
                Debug.LogWarning("Calling to pause an audio source that is not playing");
                return;
            }

            _audioSource.Pause();
            isPaused = true;
        }

        public void StopAudio()
        {
            if (!_audioSource.isPlaying)
            {
                Debug.LogWarning("Calling to stop an audio source that is not playing");
                return;
            }

            _audioSource.Stop();
        }
    }
}
