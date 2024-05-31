using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : Destructible
{
    [SerializeField] private VehicleProperties vehicleProperties;

    public VehicleProperties VehicleProperties => vehicleProperties;
    public override void Dead()
    {
        base.Dead();
        VehicleCollectionController.Instance.VehicleAddInCollection(vehicleProperties);
    }
}
