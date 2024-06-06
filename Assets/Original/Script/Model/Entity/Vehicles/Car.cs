
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class Car : Vehicle
{

    [SerializeField] private Transform[] _wheels;
    [SerializeField] private List<ParticleSystem> _flames;

    [SerializeField] private AudioSource _motorSound;
    [SerializeField] private GameObject _explosionSoundPrefab;

    private AIController _moveAi;
    private Rigidbody _rb;

    protected void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.mass = 3000f;
        _moveAi = GetComponent<AIController>();
        _motorSound.Play();
        _motorSound.loop = true;
        _motorSound.spatialBlend = 1;
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
        PlayFlame();
        _motorSound.Pause();
        Instantiate(_explosionSoundPrefab, gameObject.transform.position, Quaternion.identity);
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
