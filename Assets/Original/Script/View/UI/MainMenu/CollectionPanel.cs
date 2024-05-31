using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionPanel : MonoBehaviour
{

    [SerializeField] private VehicalCollectionData _vehicalCollectionData;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _nameText;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_vehicalCollectionData.Vehicles.Count != 0 && _vehicalCollectionData.Vehicles != null)
        {
            _nameText.text = VehicleCollectionController.Instance.GetCurrentVehicleProperties().Name.ToString();
            _infoText.text = VehicleCollectionController.Instance.GetCurrentVehicleProperties().Text.ToString();
            
        }
        else
        {
            _nameText.text = "--------";
            _infoText.text = "”ничтожайте вражeскую технику, что бы открыть трофеи";
        }
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
