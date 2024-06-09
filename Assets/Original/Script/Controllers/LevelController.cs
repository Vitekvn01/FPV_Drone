using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : SingletonBase<LevelController>
{
    [SerializeField] private LevelData _levelData;

    public LevelData LevelData => _levelData;

    public static UnityEvent OnLevelPassedEvent = new UnityEvent();

    public static UnityEvent OnLevelLoseEvent = new UnityEvent();

    protected override void Awake()
    {
        base.Awake();
        _levelData.LoadLevelsUnlock();
    }
    private void Start()
    {
        
        Debug.Log(LevelData.CurrentLevel);
        Time.timeScale = 1;
        if (LevelCondition.OnCompleteLevelEvent != null)
        {
            LevelCondition.OnCompleteLevelEvent.AddListener(LevelPassed);
            Debug.Log("subsriptingEvent");
        }
        if (LevelCondition.OnFailedLevelEvent != null)
        {
            LevelCondition.OnFailedLevelEvent.AddListener(LevelLose);
        }
        
    }

    private void LevelPassed()
    {
        _levelData.NextLevelUnlock();
        Debug.Log("Победа");
        OnLevelPassedEvent.Invoke();
    }

    private void LevelLose()
    {
        Time.timeScale = 0;
        OnLevelLoseEvent.Invoke();
    }

}
