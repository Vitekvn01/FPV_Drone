using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPrefab;

    [SerializeField] private Transform _spawnPosition;

    protected GameObject spawnObject;

    public virtual void Spawn()
    {
        spawnObject = Instantiate(_spawnPrefab);
        spawnObject.transform.position = transform.position;
        spawnObject.transform.forward = transform.forward;
    }
}
