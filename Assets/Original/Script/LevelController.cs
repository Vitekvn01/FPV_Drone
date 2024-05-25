using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonBase<LevelController>
{
    [SerializeField] private LevelData _levelData;

    public LevelData LevelSystem => _levelData;

    protected override void Awake()
    {
        base.Awake();
        _levelData.LoadLevelsUnlock();
    }
    private void Start()
    {
        if (LevelComplete.OnCompleteLevelEvent != null)
        {
            LevelComplete.OnCompleteLevelEvent.AddListener(Win);
        }
             
    }

    private void Win()
    {

        _levelData.NextLevelUnlock();
        Debug.Log("Победа");
        LevelComplete.OnCompleteLevelEvent.RemoveListener(Win);
    }
}
