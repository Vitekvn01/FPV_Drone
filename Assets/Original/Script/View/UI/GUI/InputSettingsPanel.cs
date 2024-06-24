using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputSettingsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _settingInfoMovementText;
    [SerializeField] private TextMeshProUGUI _settingMovementText;

    [SerializeField] private TextMeshProUGUI _settingInfoInversionText;
    [SerializeField] private TextMeshProUGUI _settingInversionText;

    [SerializeField] private TextMeshProUGUI _settingSensetiveText;

    [SerializeField] private Slider _slider;

    [SerializeField] private InputSettings _inputSettings;

    private string _string;

    private void Start()
    {
        _settingInfoMovementText.text = LocalizationData.DictionaryLocalizationWords["Control mode"];
        _settingMovementText.text = LocalizationData.DictionaryLocalizationWords[_inputSettings.MovementType.ToString()]; ;

        _settingInfoInversionText.text = LocalizationData.DictionaryLocalizationWords["Tilt inversion"];
        if (_inputSettings.OnInversionJoystick == true)
        {
            _settingInversionText.text = LocalizationData.DictionaryLocalizationWords["On"];
        }
        else
        {
            _settingInversionText.text = LocalizationData.DictionaryLocalizationWords["Off"];
        }

        _settingSensetiveText.text = LocalizationData.DictionaryLocalizationWords["Input sensitivity"];
        _slider.value = PlayerPrefs.GetFloat("sensitivejoystick", 8);
    }


    public void SelectMovementType()
    {
        _inputSettings.SettingMovementType();
        _settingMovementText.text = LocalizationData.DictionaryLocalizationWords[_inputSettings.MovementType.ToString()];
        Debug.Log(_inputSettings.MovementType);
    }

    public void SelectInversionJoystick()
    {
        _inputSettings.SettingInversionJoystick();
        if (_inputSettings.OnInversionJoystick == true)
        {
            _settingInversionText.text = LocalizationData.DictionaryLocalizationWords["On"];
        }
        else
        {
            _settingInversionText.text = LocalizationData.DictionaryLocalizationWords["Off"];
        }
    }

    public void SelectSensetiveJoystick()
    {
        _inputSettings.SetSensetiveJoystick(_slider.value);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
