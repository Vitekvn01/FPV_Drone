using UnityEngine;

public class LevelPunel : MonoBehaviour
{
    [SerializeField] private GameObject LevelSelectPrefab;

    [SerializeField] private LevelProperties[] _levels;



    void Start()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < _levels.Length; i++)
        {
            LevelSelectionButton _levelSeletionButton = Instantiate(LevelSelectPrefab, gameObject.transform).GetComponent<LevelSelectionButton>();
            _levelSeletionButton.SetLevelProperty(_levels[i]);
        }
    }
}
