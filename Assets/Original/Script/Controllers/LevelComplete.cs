using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : LevelCondition
{
    private bool IsInvokeEvent = false;
    protected override void Start()
    {
        base.Start();
        IsInvokeEvent = false;
    }

    void Update()
    {
        if (!IsInvokeEvent)
        {
            if (Enemy.ListEnemies.Count <= 0)
            {
                Debug.Log("Комплит");
                OnCompleteLevelEvent.Invoke();
                IsInvokeEvent = true;
            }
        }

    }

}
