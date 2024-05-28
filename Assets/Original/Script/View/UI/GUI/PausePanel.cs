using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        gameObject.SetActive(false);
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
    }
}
