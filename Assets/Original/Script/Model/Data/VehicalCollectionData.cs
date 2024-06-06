using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class VehicalCollectionData : ScriptableObject
{
    const string filename = "VehicalCollection.dat";

    private static Dictionary<int, VehicleProperties> _dictionaryVehicleProperties = new Dictionary<int, VehicleProperties>();

    [SerializeField] private VehicleProperties[] _allVehiclePropirties;

    [SerializeField] private List<VehicleProperties> _vehicles = new List<VehicleProperties>();
    public List<VehicleProperties> Vehicles => _vehicles;

    [SerializeField] private List<VehiclePropertiesDataContainer> _vehiclesPropertiesData = new List<VehiclePropertiesDataContainer>();



   [Serializable]
    public class VehiclesPropertiesListContainer
    {
        public List<VehiclePropertiesDataContainer> VehiclesDataListContainer;
    }

    [Serializable]
    public class VehiclePropertiesDataContainer
    {
        public int VehiclePropertiesID;

        // Добавьте сюда остальные поля из VehicleProperties
    }

    public void FillVehiclePropertiesDictionary()
    {
        foreach (VehicleProperties vehicleProperties in _allVehiclePropirties)
        {
            _dictionaryVehicleProperties[vehicleProperties.ID] = vehicleProperties;
        }
    }

    public void AddVehicleInList(VehicleProperties vehicle)
    {
        if (!_vehicles.Contains(vehicle))
        {
            _vehicles.Add(vehicle);
        }
    }

    private void GetVehicleList()
    {
        foreach (var vehicleData in _vehiclesPropertiesData)
        {
            if (_dictionaryVehicleProperties.TryGetValue(vehicleData.VehiclePropertiesID, out VehicleProperties vehicle))
            {
                AddVehicleInList(vehicle);
            }
        }
    }

    /// <summary>
    /// Оборачивает VehicleProperties в контейнер для сериализации в Json;
    /// </summary>
    /// <param name="vehicle"></param>
    /// <returns> возвращает VehiclePropertiesDataContainer data </returns>
    private VehiclePropertiesDataContainer WrapVehiclePropertieInContainer(VehicleProperties vehicle) 
    {
        VehiclePropertiesDataContainer data = new VehiclePropertiesDataContainer()
        {
            VehiclePropertiesID = vehicle.ID
        };
        return data;
    }

    /// <summary>
    /// Добавляет контейнер в список контейнеров
    /// </summary>
    /// <param name="data"></param>
    private void AddVehiclePropertiesContainerInListContainer(VehiclePropertiesDataContainer data)
    {
        if (!_vehiclesPropertiesData.Exists(x => x.VehiclePropertiesID == data.VehiclePropertiesID))
        {
            _vehiclesPropertiesData.Add(data);
        }
    }

    /// <summary>
    /// Оборачивает и сохарняет список VehiclePropierty в список контейнеров 
    /// </summary>
    private void SetVehiclePropiertyListInContainer()
    {
        foreach (var vehicle in _vehicles)
        {
            VehiclePropertiesDataContainer data = WrapVehiclePropertieInContainer(vehicle);
            AddVehiclePropertiesContainerInListContainer(data);
        }
    }

    

    public void SaveToFile()
    {
        SetVehiclePropiertyListInContainer();
        string filePath = Path.Combine(Application.persistentDataPath, filename);/// 1. Получение пути к файлу:

        // Создаем экземпляр LevelDataContainer и сохраняем в него массив _levels
        VehiclesPropertiesListContainer container = new VehiclesPropertiesListContainer
        {
            VehiclesDataListContainer = _vehiclesPropertiesData
        };

        // Преобразуем экземпляр LevelDataContainer в JSON-строку и сохраняем в файл
        var data = JsonUtility.ToJson(container); /// JsonUtility.ToJson(this) преобразует экземпляр LevelData в JSON-строку.
        File.WriteAllText(filePath, data);/// Запись данных в файл:
    }

    public static VehicalCollectionData LoadFromFile(VehicalCollectionData existingVehicalCollectionData)
    {
        Debug.Log("Load");
        string filePath = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(filePath))
        {
            var data = File.ReadAllText(filePath);

            // Десериализуем данные из файла в экземпляр LevelDataContainer
            VehiclesPropertiesListContainer container = JsonUtility.FromJson<VehiclesPropertiesListContainer>(data);

            // Записываем данные из контейнера в существующий экземпляр LevelData
            existingVehicalCollectionData._vehiclesPropertiesData = container.VehiclesDataListContainer;
            existingVehicalCollectionData.GetVehicleList();
            return existingVehicalCollectionData;
        }
        else return null;
    }
}

