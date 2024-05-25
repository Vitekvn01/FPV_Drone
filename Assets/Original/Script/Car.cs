
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : Destructible
{
    [SerializeField] private List<ParticleSystem> _flames;

    private AIController _moveAi;
    private Rigidbody _rb;

    protected void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.mass = 3000f;
        _moveAi = GetComponent<AIController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (IsAlive == true)
        {
            if (collision.gameObject.GetComponent<Drone>() != null)
            {
                Dead();
            }
        }
        
    }

    public override void Dead()
    {
        base.Dead();
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
