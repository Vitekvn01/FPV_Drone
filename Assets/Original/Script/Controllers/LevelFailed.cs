using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class LevelFailed : LevelCondition
{
    public enum FailedType
    {
        Timer,
        Trigger
    }
    [SerializeField] private FailedType failedType;

    [SerializeField] private float _timer;

    public static UnityEvent<float> OnEventTimer = null; 

    [SerializeField] private float _radius;
    private SphereCollider _trigger;

    private void Awake()
    {

    }
    void Start()
    {
        if (FailedType.Timer == failedType)
        {
            OnEventTimer = new UnityEvent<float>();
        }
        _trigger = gameObject.AddComponent<SphereCollider>();
        _trigger.radius = _radius;
        _trigger.isTrigger = true;
    }

    private void Update()
    {
        if (FailedType.Timer == failedType)
        {
            _timer -= Time.deltaTime;
            OnEventTimer.Invoke(_timer);
            if (_timer <= 0)
            {
                OnFailedLevelEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (FailedType.Trigger == failedType)
        {
            if (other.gameObject.transform.root.GetComponentInParent<Enemy>() != null)
            {
                Debug.Log("Other" + other.name);
                OnFailedLevelEvent.Invoke();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, _radius);
    }


}
