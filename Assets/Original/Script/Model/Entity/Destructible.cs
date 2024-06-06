using UnityEngine;
using UnityEngine.Events;

public abstract class Destructible : Entity
{
    public UnityEvent OnDeadEvent;
    protected bool IsAlive = true;

    public virtual void Dead()
    {
        if (IsAlive)
        {
            OnDeadEvent.Invoke();
            IsAlive = false;
        }
    }


}
