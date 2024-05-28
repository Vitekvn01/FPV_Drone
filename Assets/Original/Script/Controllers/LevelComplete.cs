using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : MonoBehaviour
{

    public static UnityEvent OnCompleteLevelEvent = new UnityEvent();
    void Update()
    {
        if (Enemy.ListEnemies.Count <= 0)
        {
            Debug.Log("Комплит");
            OnCompleteLevelEvent.Invoke();
        }
    }

}
