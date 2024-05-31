
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Car : Vehicle
{

    [SerializeField] private Transform[] _wheels;
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
/*        if (_moveAi != null)
        {
            _moveAi.SetIsFreeze(true);
        }*/
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

    public void WheelsRotate(float speed)
    {
        foreach (Transform wheel in _wheels)
        {
            wheel.Rotate(Vector3.right, speed * 100);
        }
    }

}
