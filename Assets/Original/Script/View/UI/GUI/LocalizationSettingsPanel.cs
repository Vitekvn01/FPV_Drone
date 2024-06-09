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
        _settingLocalizationText.text = _localizationData.Language.ToString();
    }

    public void SelectLanguage()
    {
        _localizationData.ChangeLanguage();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
