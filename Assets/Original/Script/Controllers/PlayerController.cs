using UnityEngine;
using UnityEngine.Events;

public class PlayerController : SingletonBase<PlayerController>
{
    [SerializeField] private DroneSpawner _droneSpawner;

    [SerializeField] private int _countDrone;
    public int CountDrone => _countDrone;

    [SerializeField] private static Drone _currentDrone;
    public static Drone CurrentDrone => _currentDrone;

    private Camera _camera;

    [SerializeField] private Camera _cameraScout;

    [SerializeField] private ScoutDrone _droneScout; // временно

    [SerializeField] private GameObject _respawnPanel;

    public static UnityEvent OnOverCountDroneEvent = new UnityEvent();

    private void Start()
    {
        _respawnPanel.SetActive(true);
        PlayerInput.Instance.SetTargetDrone(_droneScout);
        _cameraScout = GetComponent<Camera>();
        _cameraScout = Camera.main;
    }

    private void Update()
    {
        if (_currentDrone != null)
        {
            _droneScout.gameObject.SetActive(false);
            /* _cameraScout.gameObject.SetActive(false);*/
            _respawnPanel.SetActive(false);
            _droneScout.transform.LookAt(_currentDrone.transform);
            _droneScout.SetZOOM(5);
        }
        else
        {
            _droneScout.gameObject.SetActive(true);
            _respawnPanel.SetActive(true);
            PlayerInput.Instance.SetTargetDrone(_droneScout);

        }
    }

    private void RemoveDroneCount()
    {
        _countDrone -= 1;
        if (_countDrone <= 0)
        {
            OnOverCountDroneEvent.Invoke();
            _countDrone = 0;
        }
    }

    public void SpawnDrone()
    {
        _droneSpawner.Spawn();
    }

    public void DeadDrone()
    {
        _currentDrone.Dead();
    }

    public void SetTargetDrone(Drone drone, Camera camera)
    {
        if (_currentDrone != null)
        {
            _currentDrone.OnDeadEvent.RemoveListener(RemoveDroneCount);
        }
        _currentDrone = drone;
        _currentDrone.OnDeadEvent.AddListener(RemoveDroneCount);
        PlayerInput.Instance.SetTargetDrone(_currentDrone);
        _camera = camera;
        _camera = Camera.main;
    }
}
