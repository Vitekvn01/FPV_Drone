using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawn : MonoBehaviour
{

    [SerializeField] private GameObject _explosionPrefub;
    public void Spawn(Vector3 transform)
    {
        Instantiate(_explosionPrefub, transform, Quaternion.identity);
    }
}
