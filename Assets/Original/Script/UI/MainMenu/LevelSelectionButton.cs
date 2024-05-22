using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private LevelProperties _levelProperties;
    [SerializeField] private TextMeshProUGUI _levelTitle;
    [SerializeField] private Image _previewImage;

    private void Start()
    {
/*        if (_levelProperties == null) return;

        _previewImage.sprite = _levelProperties.PreviewImage;
        _levelTitle.text = _levelProperties.Title;*/
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelProperties.SceneName);
    }

    public void SetLevelProperty(LevelProperties levelProperties)
    {
        _levelProperties = levelProperties;
        _previewImage.sprite = _levelProperties.PreviewImage;
        _levelTitle.text = _levelProperties.Title;
    }
}


