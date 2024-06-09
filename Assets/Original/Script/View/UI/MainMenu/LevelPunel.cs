using UnityEngine;

public class LevelPunel : MonoBehaviour
{
    [SerializeField] private GameObject LevelSelectPrefab;

    [SerializeField] private LevelData _levelData;

    void Start()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < _levelData.Levels.Length; i++)
        {
            LevelSelectionButton _levelSeletionButton = Instantiate(LevelSelectPrefab, gameObject.transform).GetComponent<LevelSelectionButton>();

            _levelSeletionButton.SetLevelProperty(_levelData.Levels[i]);
        }
    }
}
