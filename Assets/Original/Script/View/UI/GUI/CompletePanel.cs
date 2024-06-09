using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CompletePanel : MonoBehaviour
{

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _textWinButton;
    [SerializeField] private TextMeshProUGUI _textNextLevelButton;
    [SerializeField] private TextMeshProUGUI _textExitWinButton;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _textLoseButton;
    [SerializeField] private TextMeshProUGUI _textRestartButton;
    [SerializeField] private TextMeshProUGUI _textExitLoseButton;
    void Start()
    {


        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        LevelController.OnLevelPassedEvent.AddListener(ShowWinPanel);
        LevelController.OnLevelLoseEvent.AddListener(ShowLosePanel);
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
}
