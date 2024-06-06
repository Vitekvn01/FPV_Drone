using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class AudioSettings : ScriptableObject
{
    [SerializeField] private AudioMixer MusicMixer;

    [SerializeField] private AudioMixer EffectMixer;

    public void LoadAudioSettings()
    {
        SetEffectVolume(PlayerPrefs.GetFloat("EffectVolume", 0));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0));
    }

    public void SetEffectVolume(float Value)
    {
        EffectMixer.SetFloat("MasterVolume", Value);
        PlayerPrefs.SetFloat("EffectVolume", Value);
    }

    public void SetMusicVolume(float Value)
    {
        MusicMixer.SetFloat("MasterVolume", Value);
        PlayerPrefs.SetFloat("MusicVolume", Value);
    }
}
