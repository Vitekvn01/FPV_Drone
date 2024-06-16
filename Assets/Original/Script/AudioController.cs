using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : SingletonBase<AudioController>
{
    [SerializeField] private AudioSettings _audioSettings;

    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        _audioSettings.LoadAudioSettings();
    }

    void Start()
    {
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
