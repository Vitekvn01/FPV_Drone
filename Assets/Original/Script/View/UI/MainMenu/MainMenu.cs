using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _collectionPanel;
    [SerializeField] private GameObject _inputSettingsPanel;
    [SerializeField] private GameObject _audioSettingsPanel;

    [Header("Buttons")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _levelButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _collectionButton;
    [SerializeField] private GameObject _exitButton;


    private int levelIndex;
    void Start()
    {
        _levelButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Levels"];
        _playButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Play"];
        _collectionButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Collection"];
        _settingsButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Settings"];
        _exitButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Exit"];
        levelIndex = 0;
/*        PlayerPrefs.SetInt("FirstStartPlaySettings", 0);*/
    }

    public void PlayButton()
    {
        if ((PlayerPrefs.GetInt("FirstStartPlaySettings", 0) == 0))
        {
            AllPanelSetActiveFalse();
            UIController.Instance.FirstStartSettingsSetActive();
        }
        else
        {
            LevelData.SetCurrentLevel(LevelController.Instance.GetLastUnlockLevel());
            Debug.Log(LevelData.CurrentLevel);
            SceneManager.LoadScene(LevelController.Instance.LevelData.LastUnlockLevel + 1); // массив сцен больше чем массив левелс потому что меню под индексом 0 в нём 
            AdsYandex.Instance.ShowFullScreenAds();
        }

    }
    public void SettingsButton()
    {
        AllPanelSetActiveFalse();
        _settingsPanel.SetActive(true);
        _inputSettingsPanel.SetActive(true);
        _audioSettingsPanel.SetActive(true);
    }

    public void LevelButton()
    {
        AllPanelSetActiveFalse();
        _levelPanel.SetActive(true);
    }

    public void CollectionButton()
    {
        AllPanelSetActiveFalse();
        _collectionPanel.SetActive(true);
        _collectionPanel.GetComponent<CollectionPanel>().StartCollectionButton();

    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void AllPanelSetActiveFalse()
    {
        _settingsPanel.SetActive(false);
        _inputSettingsPanel.SetActive(false);
        _audioSettingsPanel.SetActive(false);
        _levelPanel.SetActive(false);
        _collectionPanel.SetActive(false);
    }



}
