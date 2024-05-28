using UnityEngine;
using UnityEngine.AI;

public class VehicleCollectionController : SingletonBase<VehicleCollectionController>
{
    [SerializeField] private int _speedRotate = 2;
    [SerializeField] private GameObject _blackVisualModelPrefab;
    [SerializeField] private VehicalCollectionData _vehicalCollectionData;
    [SerializeField] private Transform _transform;
    private GameObject _currentVehicle;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        VehicalCollectionData.LoadFromFile(_vehicalCollectionData);
    }

    private void Update()
    {
        if (_currentVehicle != null)
        {
            _currentVehicle.transform.Rotate(Vector3.up * _speedRotate * Time.deltaTime, Space.Self);
        }
    }

    public void VehicleAddInCollection(VehicleProperties vehicle)
    {
        _vehicalCollectionData.AddVehicleInList(vehicle);
        _vehicalCollectionData.SaveToFile();
    }

    public void DrawVehicleCollection()
    {
        if (_vehicalCollectionData.Vehicles != null && _vehicalCollectionData.Vehicles.Count != 0)
        {
            SpawnCurrentVehicle(_vehicalCollectionData.Vehicles[index].VehiclePrefab);
            _currentVehicle.GetComponent<Rigidbody>().isKinematic = true;
            if (_currentVehicle.GetComponents<MonoBehaviour>().Length > 0)
            {
                MonoBehaviour[] scripts = _currentVehicle.GetComponents<MonoBehaviour>();

                foreach (MonoBehaviour script in scripts)
                {
                    Destroy(script);
                }
            }
            if (_currentVehicle.GetComponent<NavMeshAgent>() != null)
            {
                NavMeshAgent destroyComponent = _currentVehicle.GetComponent<NavMeshAgent>();
                Destroy(destroyComponent);
            }
        }
        else
        {
            SpawnCurrentVehicle(_blackVisualModelPrefab);
            _currentVehicle.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    private void SpawnCurrentVehicle(GameObject prefab)
    {
        if (_currentVehicle != null)
        {
            Destroy(_currentVehicle);
        }
        _currentVehicle = Instantiate(prefab, _transform);
    }

    public void HideVehicleColletion()
    {
        if (_currentVehicle != null)
        {
            Destroy(_currentVehicle);
        }
        
    }


    public void NextVehicle()
    {
        if (index != _vehicalCollectionData.Vehicles.Count - 1)
        {
            index += 1;
            Destroy(_currentVehicle);
            DrawVehicleCollection();
        }
    }

    public void BackVehicle()
    {
        if (index != 0)
        {
            index -= 1;
            Destroy(_currentVehicle);
            DrawVehicleCollection();
        }
    }
}
