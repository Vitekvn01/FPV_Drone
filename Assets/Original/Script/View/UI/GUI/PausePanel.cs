using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _exitButton;

    private void Start()
    {
        gameObject.SetActive(false);
        _continueButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Continue"];
        _settingsButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Settings"];
        _restartButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Restart"];
        _exitButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Exit"];

    }

    public void ShowPausePanel()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AdsYandex.Instance.ShowFullScreenAds();
    }
}
