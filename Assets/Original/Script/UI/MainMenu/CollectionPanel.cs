using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionPanel : MonoBehaviour
{

    [SerializeField] private VehicalCollectionData _vehicalCollectionData;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartCollectionButton()
    {
        VehicleCollectionController.Instance.DrawVehicleCollection();
    }

    public void NextVechicle()
    {
        VehicleCollectionController.Instance.NextVehicle();
    }

    public void BackVechicle()
    {
        VehicleCollectionController.Instance.BackVehicle();
    }

    public void OnDisable()
    {
        VehicleCollectionController.Instance.HideVehicleColletion();
    }
}
