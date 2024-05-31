using UnityEngine;
using UnityEngine.UIElements;

public class CompletePanel : MonoBehaviour
{

    [SerializeField] private GameObject _winButton;

    [SerializeField] private GameObject _loseButton;
    void Start()
    {
        _winButton.SetActive(false);
        _loseButton.SetActive(false);
        LevelController.OnLevelPassedEvent.AddListener(ShowWinPanel);
        LevelController.OnLevelLoseEvent.AddListener(ShowLosePanel);
    }

    private void ShowWinPanel()
    {
        _winButton.SetActive(true);
    }


    private void ShowLosePanel()
    {
        _loseButton.SetActive(true);
    }
}
