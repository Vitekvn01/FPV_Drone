using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class VehicalCollectionData : ScriptableObject
{
    const string filename = "VehicalCollection.dat";

    [SerializeField] private VehicleProperties[] allVehicleCount;

    [SerializeField] private List<VehicleProperties> _vehicles = new List<VehicleProperties>();

    public List<VehicleProperties> Vehicles => _vehicles;

    public void AddVehicleInList(VehicleProperties vehicle)
    {
        if (_vehicles.Contains(vehicle))
        {
            return;
        }
        else
        {
            _vehicles.Add(vehicle);
        }
    }

    [System.Serializable]
    public class VehicalCollectionContainer
    {
        public List<VehicleProperties> VehiclesList;
    }

    [Serializable]

    private class VehicleCintainer
    {
        public VehicleProperties vehicleProperties;
        
    }

    public void SaveToFile()
    {

        Debug.Log("Save");
        string filePath = Path.Combine(Application.persistentDataPath, filename);/// 1. Получение пути к файлу:

        // Создаем экземпляр LevelDataContainer и сохраняем в него массив _levels
        VehicalCollectionContainer container = new VehicalCollectionContainer
        {
            VehiclesList = _vehicles
        };

        // Преобразуем экземпляр LevelDataContainer в JSON-строку и сохраняем в файл
        var data = JsonUtility.ToJson(container); /// JsonUtility.ToJson(this) преобразует экземпляр LevelData в JSON-строку.
        File.WriteAllText(filePath, data);/// Запись данных в файл:
    }

    public static VehicalCollectionData LoadFromFile(VehicalCollectionData existingVehicalCollectionContainer)
    {
        Debug.Log("Load");
        string filePath = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(filePath))
        {
            var data = File.ReadAllText(filePath);

            // Десериализуем данные из файла в экземпляр LevelDataContainer
            VehicalCollectionContainer container = JsonUtility.FromJson<VehicalCollectionContainer>(data);

            // Записываем данные из контейнера в существующий экземпляр LevelData
            existingVehicalCollectionContainer._vehicles = container.VehiclesList;

            return existingVehicalCollectionContainer;
        }
        else return null;
    }

}
