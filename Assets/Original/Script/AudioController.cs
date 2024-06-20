using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : SingletonBase<AudioController>
{
    [SerializeField] public AudioSettings AudioSettings;

    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        AudioSettings.LoadAudioSettings();
    }

    void Start()
    {
        AudioSettings.LoadAudioSettings();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.spatialBlend = 0;
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
