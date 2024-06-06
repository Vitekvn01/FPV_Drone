using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelCondition : MonoBehaviour
{
    public static UnityEvent OnCompleteLevelEvent = new UnityEvent();
    public static UnityEvent OnFailedLevelEvent = new UnityEvent();
    void Start()
    {
        PlayerController.OnOverCountDroneEvent.AddListener(OnFailedLevelEvent.Invoke);
    }
}
