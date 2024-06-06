using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    public UnityEvent OnDestroyEntityEvent = new UnityEvent();

    public void OnDestroy()
    {
        OnDestroyEntityEvent.Invoke();
    }
}
