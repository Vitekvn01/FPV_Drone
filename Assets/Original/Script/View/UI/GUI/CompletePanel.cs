using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CompletePanel : MonoBehaviour
{
    [Header("Ïîáåäà")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _textWinButton;
    [SerializeField] private TextMeshProUGUI _textNextLevelButton;
    [SerializeField] private TextMeshProUGUI _textExitWinButton;
    [Header("Ïðîèãðûø")]
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _textLoseButton;
    [SerializeField] private TextMeshProUGUI _textRestartButton;
    [SerializeField] private TextMeshProUGUI _textExitLoseButton;

    [Header("Êîí÷èëèñü äðîíû")]
    [SerializeField] private GameObject _nullCountDronePanel;
    [SerializeField] private TextMeshProUGUI _nullDroneText;
    [SerializeField] private TextMeshProUGUI _textRewardButton;
    [SerializeField] private TextMeshProUGUI _textÑontinueButton;



    void Start()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        _nullCountDronePanel.SetActive(false);
        LevelController.OnLevelPassedEvent.AddListener(ShowWinPanel);
        LevelController.OnLevelLoseEvent.AddListener(ShowLosePanel);
        PlayerController.OnOverCountDroneEvent.AddListener(ShowNullDronePanel);
    }

    private void Update()
    {
        if (PlayerController.Instance.CountDrone    != 0)
        {
            _nullCountDronePanel.SetActive(false);
        }
    }

    private void ShowWinPanel()
    {
        _textWinButton.text = LocalizationData.DictionaryLocalizationWords["Win"];
        _textNextLevelButton.text = LocalizationData.DictionaryLocalizationWords["Next level"];
        _textExitWinButton.text = LocalizationData.DictionaryLocalizationWords["Exit"];
        _winPanel.SetActive(true);
    }


    private void ShowLosePanel()
    {
        _textLoseButton.text = LocalizationData.DictionaryLocalizationWords["Lose"];
        _textRestartButton.text = LocalizationData.DictionaryLocalizationWords["Restart"];
        _textExitLoseButton.text = LocalizationData.DictionaryLocalizationWords["Exit"];
        _losePanel.SetActive(true);
    }

    private void ShowNullDronePanel()
    {
        AudioController.Instance.AudioSettings.EffectSoundOff();
        _nullDroneText.text = LocalizationData.DictionaryLocalizationWords["The drones are over"];
        _textRewardButton.text = LocalizationData.DictionaryLocalizationWords["Get more for watching"];
        _textÑontinueButton.text = LocalizationData.DictionaryLocalizationWords["Continue"];
        _nullCountDronePanel.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(LevelData.CurrentLevel.NextSceneName);
        LevelData.SetCurrentLevel(LevelData.CurrentLevel.NextLevelProperties);
        AdsYandex.Instance.ShowFullScreenAds();
    }

    public void LevelLose()
    {
        LevelController.OnLevelLoseEvent.Invoke();
        _nullCountDronePanel.SetActive(false);
    }

    public void ShowReward()
    {
        AdsYandex.Instance.ShowReawardAds();
    }

    public void ShowFullScreen()
    {
        AdsYandex.Instance.ShowFullScreenAds();
    }
}
