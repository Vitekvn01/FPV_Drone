using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    private LevelProperties _levelProperties;
    [SerializeField] private TextMeshProUGUI _levelTitle;
    [SerializeField] private TextMeshProUGUI _selectButtonText;
    [SerializeField] private Image _previewImage;
    [SerializeField] private Image _levelLockIcon;
    private void Start()
    {
        _selectButtonText.text = LocalizationData.DictionaryLocalizationWords["Play"];
        _levelLockIcon.gameObject.SetActive(false);
        if (_levelProperties.LevelLock == true)
        {
            _levelLockIcon.gameObject.SetActive(true);
        }
    }

    public void LoadLevel()
    {
        if (_levelProperties.LevelLock != true)
        {
            if ((PlayerPrefs.GetInt("FirstStartPlaySettings", 0) == 0))
            {
                UIController.Instance.FirstStartSettingsSetActive();
            }
            else
            {
                LevelData.SetCurrentLevel(_levelProperties);
                SceneManager.LoadScene(_levelProperties.SceneName);
            }

        }
    }

    public void SetLevelProperty(LevelProperties levelProperties)
    {
        _levelProperties = levelProperties;
        _previewImage.sprite = _levelProperties.PreviewImage;
        _levelTitle.text = LocalizationData.DictionaryLocalizationWords[_levelProperties.Title.ToString()];
    }
}


