using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform[] _wheels;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool isFreeze;

    // Расстояние на которое необходимо приблизиться к точке
    [SerializeField] private float distanceToChangeGoal;
    // Номер текущей целевой точки
    private int _currentWaypoint = 0;

    private Rigidbody _rb;
    private NavMeshAgent _navMeshAgent;

    private bool _movingCurrent = true;

    void Start()
    {
        // Сохранение компонента агента и направление к первой точке
        _rb = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        if (!isFreeze)
        {
            EnabledIsCinematicAndNavMesAgent(true);
            _navMeshAgent.enabled = true;
            _navMeshAgent.destination = _waypoints[0].position;
        }
        else
        {
            EnabledIsCinematicAndNavMesAgent(false);
        }

    }

    void Update()
    {
        if (!isFreeze)
        {
            EnabledIsCinematicAndNavMesAgent(true);
            if (Vector3.Distance(transform.position, _waypoints[_currentWaypoint].position) < distanceToChangeGoal)
            {
                // Смена точки на следующую
                _currentWaypoint += 1;
                if (_currentWaypoint == _waypoints.Length) _currentWaypoint = 0;
                _navMeshAgent.destination = _waypoints[_currentWaypoint].position;
                
                Debug.Log(_waypoints[_currentWaypoint].name + " объекта" + gameObject.transform.root.name + " расстояние до точки: " + _navMeshAgent.remainingDistance + " дистанция для завершения: " + distanceToChangeGoal);
            }

            if (_navMeshAgent.velocity.magnitude > 0)
            {
                _movingCurrent = true;
            }
            else _movingCurrent = false;


            // Управление вращением колес
            if (_movingCurrent)
            {
                RotateWheel();
            }

        }
        else
        {
            EnabledIsCinematicAndNavMesAgent(false);
        }
        // Проверяем, движется ли автомобиль
        
    }

    public void GetIsFreeze(bool _bool)
    {
        isFreeze = _bool;
    }

    private void RotateWheel()
    {
        foreach (Transform wheel in _wheels)
        {
            wheel.Rotate(Vector3.right, _navMeshAgent.speed * Time.deltaTime * _rotationSpeed);
        }
    }

    private void EnabledIsCinematicAndNavMesAgent(bool _bool)
    {
        _navMeshAgent.enabled = _bool;
        _rb.isKinematic = _bool;
    }
}
