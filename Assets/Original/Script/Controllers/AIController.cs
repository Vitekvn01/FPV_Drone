using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField] protected Transform[] _waypoints;

    // Расстояние на которое необходимо приблизиться к точке
    [SerializeField] protected float _distanceComplete = 2;
    // Номер текущей целевой точки
    private int _currentWaypoint = 0;

    protected Rigidbody _rb;
    protected NavMeshAgent _navMeshAgent;

    protected virtual void Start()
    {
        if (_waypoints.Length > 0)
        {
            GetInStart();
            TurnOnAI();
            MoveToWaypoint(_waypoints[_currentWaypoint]);
        }
        else
        {
            TurnoOffAi();
        }

    }

    protected virtual void Update()
    {
        if (_waypoints.Length > 0)
        {
            MovementPathWaypoints();
        }
    }

    protected virtual void GetInStart()
    {
        if (gameObject.GetComponent<Rigidbody>() != null)
        {
            _rb = GetComponent<Rigidbody>();
        }

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected virtual void SetCurrentWaypoint(int indexWaypoint)
    {
        _currentWaypoint = indexWaypoint;
    }

    protected virtual void MoveToWaypoint(Transform waypoint)
    {
        _navMeshAgent.destination = waypoint.position;
    }

    protected virtual bool CopmleteWaypoint(float distanceComplete)
    {
        if (_waypoints.Length > 0)
        {
            return (Vector3.Distance(transform.position, _waypoints[_currentWaypoint].position) < distanceComplete);
        }
        else return false;

    }

    protected virtual void MovementPathWaypoints()
    {
        if (CopmleteWaypoint(_distanceComplete))
        {
            // Смена точки на следующую
            

            if (_currentWaypoint == _waypoints.Length)
            {
                SetCurrentWaypoint(0);
                MoveToWaypoint(_waypoints[_currentWaypoint]);
            }
            else
            {
                _currentWaypoint += 1;
                MoveToWaypoint(_waypoints[_currentWaypoint]);
            }


        }
    }

    public void TurnOnAI()
    {
        if (_navMeshAgent != null)
        {
            _navMeshAgent.enabled = true;
        }
           
        if (_rb != null)
        {
            _rb.isKinematic = true;
        }
    }

    public void TurnoOffAi()
    {
        if (_navMeshAgent!= null)
        {
            _navMeshAgent.enabled = false;
        }
        
        if (_rb != null)
        {
            _rb.isKinematic = false;
        }
    }
}
