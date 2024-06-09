using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _inputSettingsPanel;

    [SerializeField] private GameObject _audioSettingsPanel;

    [SerializeField] private TextMeshProUGUI _textInputSettingsButton;

    [SerializeField] private TextMeshProUGUI _textAudioSettingsButton;

    private void Start()
    {
        _inputSettingsPanel.SetActive(false);
        _audioSettingsPanel.SetActive(false);
        gameObject.SetActive(false);
        _textInputSettingsButton.text = LocalizationData.DictionaryLocalizationWords["Control settings"];
        _textAudioSettingsButton.text = LocalizationData.DictionaryLocalizationWords["Sound settings"];
    }

    public void InputSettingsButton()
    {
        _inputSettingsPanel.SetActive(true);
    }

    public void AudioSettingsButton()
    {
        _audioSettingsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

}
