using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplosionSpawn))]
public class FPVDrone : Drone
{   
    ExplosionSpawn _explosionSpawn;
    protected override void Start()
    {
        base.Start();
        _explosionSpawn = gameObject.GetComponent<ExplosionSpawn>();
       
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        _explosionSpawn.Spawn();
        base.OnCollisionEnter(collision);
    }
}
