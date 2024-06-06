using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : LevelCondition
{
    
    void Update()
    {
        if (Enemy.ListEnemies.Count <= 0)
        {
            Debug.Log("Комплит");
            OnCompleteLevelEvent.Invoke();
        }
    }

}
