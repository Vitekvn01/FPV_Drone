using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Tank))]
public class AITank : AIController
{
    private Tank _tank;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update(); 
    }

    protected override void GetInStart()
    {
        base.GetInStart();
        _tank = GetComponent<Tank>();
        _tank.GetComponent<Destructible>().OnDeadEvent.AddListener(TurnoOffAi);
        _tank.SuspentionSound();
    }

    protected override void MovementPathWaypoints()
    {
        base.MovementPathWaypoints();
        _tank.MoveSuspention(_navMeshAgent.speed * Time.deltaTime);
    }
}
