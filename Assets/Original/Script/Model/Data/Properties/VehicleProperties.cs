using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class VehicleProperties : ScriptableObject
{
     // Статическое поле для генерации ID

    public int ID;


    public GameObject VehiclePrefab;

    public string Name;

    public string Text;
}
