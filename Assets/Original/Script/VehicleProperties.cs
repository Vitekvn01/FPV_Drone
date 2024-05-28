using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class VehicleProperties : ScriptableObject
{
    public GameObject _vehiclePrefab;

    public string _name;

    public string _text;

    public GameObject VehiclePrefab => _vehiclePrefab;
}
