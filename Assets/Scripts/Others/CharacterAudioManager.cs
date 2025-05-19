
using UnityEngine;

public class CharacterAudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField]
    AudioClip[] _audioClips;
    public AudioClip[] AudioClips { get { return _audioClips; } }

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip, bool loop, float volume, float pitch)
    {
        _audioSource.clip = clip;
        _audioSource.loop = loop;
        _audioSource.volume = volume;
        _audioSource.pitch = pitch;

        _audioSource.Play();
    }    
    public void StopSound()
    {
        _audioSource.Stop();
    }
}
