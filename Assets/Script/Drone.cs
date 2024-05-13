using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefub;

    private void OnCollisionEnter(Collision collision)
    {
        SpawnExplosion();
    }

    private void SpawnExplosion()
    {
        GameObject _explosion = Instantiate(_explosionPrefub, gameObject.transform);
        Destroy(_explosion, 2);
    }
}
