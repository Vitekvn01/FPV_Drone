using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSpawn : Spawner
{
    void Start()
    {
        _spawnPosition = gameObject.transform;
        Spawn();
    }
}
