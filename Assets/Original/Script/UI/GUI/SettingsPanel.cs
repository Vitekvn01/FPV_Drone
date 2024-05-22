using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    /*[SerializeField] private AudioMixer am;*/

    [SerializeField] private TextMeshProUGUI _settingMovementText;

    [SerializeField] private TextMeshProUGUI _settingInversionText;

    [SerializeField] private TextMeshProUGUI _settingSensetiveText;

    [SerializeField] private Slider _slider;

    [SerializeField] private InputSettings _inputSettings;

    private void Start()
    {
        gameObject.SetActive(false);
        _settingMovementText.text = "Режим управления: " + _inputSettings.MovementType.ToString();
        _settingInversionText.text = "Инверсия наклона: " + _inputSettings.OnInversionJoystick.ToString();
        _settingSensetiveText.text = "Чувствительность ввода";
        _slider.value = _inputSettings.SensitiveJoystick;
    }


    public void SelectMovementType()
    {
        _inputSettings.SettingMovementType();
        _settingMovementText.text = "Режим управления: " + _inputSettings.MovementType.ToString();
        Debug.Log(_inputSettings.MovementType);
    }

    public void SelectInversionJoystick()
    {
        _inputSettings.SettingInversionJoystick();
        _settingInversionText.text = "Инверсия наклона: " + _inputSettings.OnInversionJoystick.ToString();
    }

    /*    public void AudioVolume(float sliderValue)
        {
            am.SetFloat("MasterVolume", sliderValue);
        }*/

    public void SelectSensetiveJoystick()
    {
        _inputSettings.SetSensetiveJoystick(_slider.value);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
