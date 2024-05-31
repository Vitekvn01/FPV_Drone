using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : SingletonBase<LevelController>
{
    [SerializeField] private LevelData _levelData;

    public LevelData LevelSystem => _levelData;

    public static UnityEvent OnLevelPassedEvent = new UnityEvent();

    public static UnityEvent OnLevelLoseEvent = new UnityEvent();

    protected override void Awake()
    {
        base.Awake();
        _levelData.LoadLevelsUnlock();
    }
    private void Start()
    {
        Time.timeScale = 1;
        if (LevelComplete.OnCompleteLevelEvent != null)
        {
            LevelComplete.OnCompleteLevelEvent.AddListener(LevelPassed);
        }
        if (PlayerController.OnOverCountDroneEvent != null)
        {
            PlayerController.OnOverCountDroneEvent.AddListener(LevelLose);
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
