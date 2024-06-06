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

    public override void Dead()
    {
        _explosionSpawn.Spawn(gameObject.transform.position);
        base.Dead();
    }
}
