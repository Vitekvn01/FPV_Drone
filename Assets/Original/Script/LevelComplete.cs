using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : MonoBehaviour
{
    private bool _win = false;

    public static UnityEvent OnCompleteLevelEvent = new UnityEvent();
    void Update()
    {
        if (Enemy.ListEnemies.Count <= 0)
        {
            _win = true;
            Debug.Log("Комплит");
            OnCompleteLevelEvent.Invoke();
        }
    }

}
