using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalizationSettingsPanel : MonoBehaviour
{
    [SerializeField] private LocalizationData _localizationData;
    [SerializeField] private TextMeshProUGUI _settingInfoLocalizationText;
    [SerializeField] private TextMeshProUGUI _settingLocalizationText;

    private void Start()
    {
        _settingInfoLocalizationText.text = LocalizationData.DictionaryLocalizationWords["Language"];
    }

    private void Update()
    {
        switch (UIController.Instance.LocalizationData.Language)
        {
            case LanguageLocalization.Russian:
                _settingLocalizationText.text = "Русский";
                break;
            case LanguageLocalization.German:
                _settingLocalizationText.text = "Deutsch";
                break;
            case LanguageLocalization.Turkish:
                _settingLocalizationText.text = "Türkçe";
                break;
            case LanguageLocalization.English:
                _settingLocalizationText.text = "English";
                break;

        }

    }

    public void SelectLanguage()
    {
        _localizationData.ChangeLanguage();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
