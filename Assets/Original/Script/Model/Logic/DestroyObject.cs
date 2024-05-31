using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float DestroyTime;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
