using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Car))]
public class AICar : AIController
{
    private Car _car;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        _car.WheelsRotate(_navMeshAgent.speed * Time.deltaTime);
    }

    protected override void GetInStart()
    {
        base.GetInStart();
        _car = GetComponent<Car>();
        _car.GetComponent<Destructible>().OnDeadEvent.AddListener(TurnoOffAi);
    }
}
