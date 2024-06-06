
using UnityEngine;
using UnityEngine.Events;
using static LevelFailed;

public class LevelBoundary : SingletonBase<LevelBoundary>
{
    private Drone _drone;

    [SerializeField] private float _timeDead;

    private float _timer;

    public float Timer => _timer;

    private bool _isTimerDead = false;

    public bool IsTimerDead => _isTimerDead;

    [SerializeField] private float _radius;
    private SphereCollider _trigger;

    private void Start()
    {
        _trigger = gameObject.AddComponent<SphereCollider>();
        _trigger.radius = _radius;
        _trigger.isTrigger = true;
        _timer = _timeDead;
    }

    private void Update()
    {
        if (_isTimerDead == true)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _drone.Dead();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.root.GetComponentInParent<Drone>() != null)
        {
            Debug.Log(other.gameObject.transform.root.name);
            _drone = other.gameObject.transform.root.GetComponentInParent<Drone>();
            _drone.OnDeadEvent.AddListener(TurnOffTimer);
            TurnOnTimer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.GetComponentInParent<Drone>() != null)
        {
            Debug.Log(other.gameObject.transform.root.name);
            _drone = other.gameObject.transform.root.GetComponentInParent<Drone>();
            TurnOffTimer();
        }
    }

    private void TurnOnTimer()
    {
        _isTimerDead = true;
    }

    private void TurnOffTimer()
    {
        _isTimerDead = false;
        _timer = _timeDead;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
