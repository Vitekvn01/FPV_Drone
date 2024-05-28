using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawn : MonoBehaviour
{

    [SerializeField] private GameObject _explosionPrefub;
    public void Spawn()
    {
        Instantiate(_explosionPrefub, gameObject.transform.position, Quaternion.identity);
    }
}
