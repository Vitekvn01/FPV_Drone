using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBase<Player>
{
    [SerializeField] private DroneSpawner _droneSpawner;

    [SerializeField] private int _countDrone;
    public int CountDrone => _countDrone;

    [SerializeField] private static Drone _currentDrone;
    public static Drone CurrentDrone => _currentDrone;

    private Camera _camera;

    [SerializeField] private Camera _cameraScout;

    [SerializeField] private Drone _droneScout; // временно

    [SerializeField] private GameObject _respawnPanel;

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
    }

    public void SpawnDrone()
    {
        _droneSpawner.Spawn();
    }

    private void SetTartgetScout()
    {

    }

    public void SetTargetDrone(Drone drone, Camera camera)
    {
         if (_currentDrone != null)
        {
            _currentDrone.OnDestroyEvent.RemoveListener(RemoveDroneCount);
        }
        _currentDrone = drone;
        _currentDrone.OnDestroyEvent.AddListener(RemoveDroneCount);
        PlayerInput.Instance.SetTargetDrone(_currentDrone);
        _camera = camera;
        _camera = Camera.main;
    }


}
