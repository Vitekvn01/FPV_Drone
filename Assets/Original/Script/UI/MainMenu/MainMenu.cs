using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _settingsPanel;

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
        _levelPanel.SetActive(false);
    }

    public void LevelButton()
    {
        _levelPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }



}
