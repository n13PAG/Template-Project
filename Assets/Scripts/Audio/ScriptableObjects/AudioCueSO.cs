using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PAG
{
    [CreateAssetMenu(fileName ="AudioCue", menuName ="Audio/Audio Cue")]
    public class AudioCueSO : ScriptableObject
    {
        public enum AudioType { Music, SFX};
        public AudioType _audioType;

        private SoundSource _currentSource;
        public SoundSource GetSource()
        {
            return _currentSource;
        }
        public void SetSoundSource(SoundSource source)
        {
            _currentSource = source;
        }

        public void ClearSource()
        {
            _currentSource = null;
        }

        [Header("Clip")]
        public AudioClip _audioClip;

        [Header("Audio Data")]
        [Range(0, 256)]
        public int _priority = 128;
        [Range(0, 1)]
        public float _volume = 1;
        [Range(0, 1)]
        public float _pitch = 1;
        public bool looping = false;

        [Header("Audio Location")]
        public bool _moveToSource;
    }
}
