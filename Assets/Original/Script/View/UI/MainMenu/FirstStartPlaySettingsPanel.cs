using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstStartPlaySettingsPanel : MonoBehaviour
{
    [SerializeField] private InputSettings _inputSettings;
    [SerializeField] private TextMeshProUGUI _settingInfoControlModeText;
    [SerializeField] private TextMeshProUGUI _settingControlModeText;

    private void Start()
    {
        gameObject.SetActive(false);
        _settingControlModeText.text = LocalizationData.DictionaryLocalizationWords[_inputSettings.MovementType.ToString()];
        _settingInfoControlModeText.text = LocalizationData.DictionaryLocalizationWords["Select control mode"];
    }


    public void SelectMovementType()
    {
        _inputSettings.SettingMovementType();
        _settingControlModeText.text = LocalizationData.DictionaryLocalizationWords[_inputSettings.MovementType.ToString()];
        Debug.Log(_inputSettings.MovementType);
    }

    public void ClosePanel()
    {
        InputSettings.FirstStartPlaySettings();
        gameObject.SetActive(false);
    }

}
