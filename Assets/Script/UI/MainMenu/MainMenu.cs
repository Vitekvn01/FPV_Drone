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
        SceneManager.LoadScene(levelIndex);
    }
    public void SettingsButton()
    {
        _settingsPanel.SetActive(true);
    }

    public void levelButton()
    {
        _levelPanel.SetActive(true);
    }


}
