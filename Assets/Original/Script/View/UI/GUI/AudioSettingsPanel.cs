using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusicValue;

    [SerializeField] private Slider _sliderEffectValue;

    [SerializeField] private AudioSettings _audioSettings;
    void Start()
    {
        gameObject.SetActive(false);
        _sliderMusicValue.minValue = -80;
        _sliderMusicValue.maxValue = 20;
        _sliderMusicValue.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        _sliderEffectValue.minValue = -80;
        _sliderEffectValue.maxValue = 20;
        _sliderEffectValue.value = PlayerPrefs.GetFloat("EffectVolume", 0);
    }

    public void SelectMusicVolume()
    {
        _audioSettings.SetMusicVolume(_sliderMusicValue.value);
    }

    public void SelectEffectVolume()
    {
        _audioSettings.SetEffectVolume(_sliderEffectValue.value);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
