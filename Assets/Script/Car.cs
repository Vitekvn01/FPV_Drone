using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Car : Enemy
{
    [SerializeField] private List<ParticleSystem> _flames;

    private MoveAI _moveAi;
    private Rigidbody _rb;

    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody>();
        _rb.mass = 3000f;
        _moveAi = GetComponent<MoveAI>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (IsAlive == true)
        {
            if (collision.gameObject.GetComponent<Drone>() != null)
            {
                DestroyEnemy();
            }
        }
        
    }

    public override void DestroyEnemy()
    {
        base.DestroyEnemy();
        Debug.Log("Car destroy");
        if (_moveAi != null)
        {
            _moveAi.GetIsFreeze(true);
        }
        PlayFlame();
        IsAlive = false;
    }

    private void PlayFlame()
    {
        foreach (ParticleSystem _flame in _flames)
        {
            _flame.Play();
        }
    }

}
