using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public UnityEvent destroyObject;
    protected bool IsAlive = true;

    protected virtual void Start()
    {
        destroyObject.AddListener(LevelState.SubtractTarget);
    }
    public virtual void DestroyEnemy()
    {
        destroyObject.Invoke();
    }


}
