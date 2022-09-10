using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PAG
{
    [CreateAssetMenu(fileName ="AudioCue", menuName ="Audio/Audio Cue")]
    public class AudioCueSO : ScriptableObject
    {
        public bool looping = false;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private float _volume = 1;
        [SerializeField] private float _pitch = 1;
        [SerializeField] private AudioMixer _mixer;
    }
}
