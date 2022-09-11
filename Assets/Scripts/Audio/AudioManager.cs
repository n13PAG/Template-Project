using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PAG
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Music Emmiters")]
        [SerializeField] private SoundSource _musicSource;

        [Header("SFX Emitters")]
        [SerializeField] private SoundSource _sfxSourcePrefab;
        [SerializeField] private int _sfxSourceCount = 10;
        private List<SoundSource> _sfxSourcePool = new List<SoundSource>();

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
            CreateSFXPool();

            _musicEventChannel.OnAudioCuePlayRequested += PlayMusicTrack;
            _musicEventChannel.OnAudioCueStopRequested += StopMusicTrack;
            _musicEventChannel.OnAudioCuePauseRequested += PauseMusicTrack;

            _sfxEventChannel.OnAudioCuePlayRequested += PlaySFX;
            _sfxEventChannel.OnAudioCueStopRequested += StopSFX;
            _sfxEventChannel.OnAudioCueFinishRequested += SFXFinished;
        }

        private void OnDestroy()
        {
            _musicEventChannel.OnAudioCuePlayRequested -= PlayMusicTrack;
            _musicEventChannel.OnAudioCueStopRequested -= StopMusicTrack;
            _musicEventChannel.OnAudioCuePauseRequested -= PauseMusicTrack;

            _sfxEventChannel.OnAudioCuePlayRequested -= PlaySFX;
            _sfxEventChannel.OnAudioCueStopRequested -= StopSFX;
            _sfxEventChannel.OnAudioCueFinishRequested -= SFXFinished;
        }

        #region SFX
        private void CreateSFXPool()
        {
            for (int i = 0; i < _sfxSourceCount; i++)
            {
                SoundSource source = Instantiate(_sfxSourcePrefab, transform);
                source.gameObject.SetActive(false);
                _sfxSourcePool.Add(source);
            }
        }

        private SoundSource GetFromSFXPool()
        {
            // Search for inactive source in pool
            SoundSource soundSource = null;
            foreach (SoundSource source in _sfxSourcePool)
            {
                if (!source.gameObject.activeInHierarchy)
                {
                    soundSource = source;
                }
            }

            // If inactive source is not found, add more sources to pool
            // Recursively perform call
            if (soundSource == null)
            {
                CreateSFXPool();
                return GetFromSFXPool();
            }

            // Enable source
            soundSource.gameObject.SetActive(true);

            return soundSource;
        }

        private void ReturnToPool(SoundSource source)
        {
            source.gameObject.SetActive(false);
            source.transform.SetParent(transform);
        }

        private void PlaySFX(AudioCueSO audioCueSO, AudioCue audioCue)
        {
            SoundSource source = GetFromSFXPool();
            source.SetChannel(_sfxEventChannel);

            if (audioCueSO._moveToSource)
            {
                source.transform.SetParent(audioCue.transform);
            }

            source.PlayAudio(audioCueSO);
        }

        private void StopSFX(AudioCueSO audioCue)
        {
            SoundSource soundSource = audioCue.GetSource();
            soundSource.StopAudio();
            ReturnToPool(soundSource);
            audioCue.ClearSource();
        }

        private void SFXFinished(AudioCueSO audioCue)
        {
            ReturnToPool(audioCue.GetSource());
            audioCue.ClearSource();
        }
        #endregion

        #region Music
        private void PlayMusicTrack(AudioCueSO audioCueSO, AudioCue audioCue)
        {
            _musicSource.PlayAudio(audioCueSO);
        }

        private void StopMusicTrack(AudioCueSO audioCue)
        {
            _musicSource.StopAudio();   
        }

        private void PauseMusicTrack()
        {
            _musicSource.PauseAudio();
        }

        private void MusicTrackFinished(AudioCueSO audioCue)
        {

        }
        #endregion

    }
}
