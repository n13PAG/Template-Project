using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PAG
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Music Emmiters")]
        [SerializeField] private int _musicEmitterCount = 1;
        //private List

        [Header("Audio Channels")]
        [SerializeField] private AudioEventChannel _musicEventChannel;
        [SerializeField] private AudioEventChannel _sfxEventChannel;

        [Header("Audio control")]
        [SerializeField] private AudioMixer _audioMixer;
        [Range(0f, 1f)]
        [SerializeField] private float _masterVolume = 1f;
        [Range(0f, 1f)]
        [SerializeField] private float _musicVolume = 1f;
        [Range(0f, 1f)]
        [SerializeField] private float _sfxVolume = 1f;

        private void OnEnable()
        {
            //_sfxEventChannel.OnAudioCuePlayRequested += PlayAudioCue;
            //_sfxEventChannel.OnAudioCueStopRequested += StopAudioCue;
            //_sfxEventChannel.OnAudioCueFinishRequested += FinishAudioCue;

            //_musicEventChannel.OnAudioCuePlayRequested += PlayMusicTrack;
            //_musicEventChannel.OnAudioCueStopRequested += StopMusic;
        }

        private void OnDestroy()
        {
            //_musicEventChannel.OnAudioCuePlayRequested -= PlayMusicTrack;
            //_musicEventChannel.OnAudioCueStopRequested -= StopMusic;

            //_sfxEventChannel.OnAudioCuePlayRequested -= PlayAudioCue;
            //_sfxEventChannel.OnAudioCueStopRequested -= StopAudioCue;
            //_sfxEventChannel.OnAudioCueFinishRequested -= FinishAudioCue;
        }

        private void PlayMusicTrack(AudioCueSO audioCue, Vector3 position)
        {

        }
    }
}
