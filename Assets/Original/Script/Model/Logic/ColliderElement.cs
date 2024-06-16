using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderElement : MonoBehaviour
{
    private bool isDefeat = false;
    public bool IsDefeat => isDefeat;

    private void Start()
    {
        if (gameObject.GetComponent<Collider>() != null)
        {
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogError("Collider null");
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.root.GetComponent<Drone>() != null)
        {
            Debug.Log("Попадание в " + gameObject.name);
            isDefeat = true;
        }
    }
}
