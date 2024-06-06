using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _collectionPanel;
    [SerializeField] private GameObject _inputSettingsPanel;
    [SerializeField] private GameObject _audioSettingsPanel;

    private int levelIndex;
    void Start()
    {
        levelIndex = 0;
    }

    public void PlayButton()
    {
        if (LevelData.CurrentLevel != null)
        {
            SceneManager.LoadScene(LevelData.CurrentLevel.SceneName);
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SettingsButton()
    {

        _settingsPanel.SetActive(true);
        _inputSettingsPanel.SetActive(true);
        _audioSettingsPanel.SetActive(true);
        _levelPanel.SetActive(false);
        _collectionPanel.SetActive(false);
    }

    public void LevelButton()
    {
        _levelPanel.SetActive(true);
        _settingsPanel.SetActive(false);
        _collectionPanel.SetActive(false);
    }

    public void CollectionButton()
    {
        _settingsPanel.SetActive(false);
        _levelPanel.SetActive(false);
        _collectionPanel.SetActive(true);
        _collectionPanel.GetComponent<CollectionPanel>().StartCollectionButton();

    }
    public void ExitButton()
    {
        Application.Quit();
    }



}
