using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelCondition : MonoBehaviour
{
    public static UnityEvent OnCompleteLevelEvent = new UnityEvent();
    public static UnityEvent OnFailedLevelEvent = new UnityEvent();
    protected virtual void Start()
    {
        OnFailedLevelEvent.AddListener(DebugEvent);

        if (OnFailedLevelEvent != null)
        {
            Debug.Log("OnFailedLevelEvent != null");
        }
;
    }

    private void Update()
    {
        if (OnFailedLevelEvent != null)
        {
            Debug.Log("OnFailedLevelEvent != null");
        }
    }

    public void DebugEvent()
    {
        Debug.Log("OnFailedLevelEvent");
    }
}
