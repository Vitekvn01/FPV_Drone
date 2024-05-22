using UnityEngine;
using UnityEngine.Events;

public abstract class Destructible : MonoBehaviour
{
    public UnityEvent OnDeadEvent;
    protected bool IsAlive = true;

    protected virtual void Start()
    {
        OnDeadEvent.AddListener(LevelState.SubtractTarget);
    }
    public virtual void Dead()
    {
        IsAlive = false;
        OnDeadEvent.Invoke();
    }


}
