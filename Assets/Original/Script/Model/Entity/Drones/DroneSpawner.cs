using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DroneSpawner : Spawner
{
    public static UnityEvent OnDroneSpawnEvent;
    public override void Spawn()
    {
        base.Spawn();
        Drone drone = spawnObject.GetComponent<Drone>();
        Camera camera = drone.GetComponent<Camera>();
        PlayerController.Instance.SetTargetDrone(drone, camera);
    }
}
