using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Tank : Destructible
{

    [SerializeField] private ColliderElement TurretDefeat;
    [SerializeField] private ColliderElement BortDefeat;
    [SerializeField] private GameObject _turret;
    [SerializeField] private GameObject _explosionTurret;
    [SerializeField] private ParticleSystem _flameTurret;
    [SerializeField] private List<ParticleSystem> _flames;
    [SerializeField] private int _explosionForce;

    /*
        [Header("Поврот башни")]
        [SerializeField] private float _dirRotateTurretX;
        [SerializeField] private float _dirRotateTurretY;
        [SerializeField] private float _dirRotateTurretZ;
        [SerializeField] private float _timeRotateTurret;*/

    private bool dronesAttack = false;
    

    private Rigidbody _rb;
    private AIController _moveAi;

    private float _timer =0;
    public override void Dead()
    {
        base.Dead();
        if (_moveAi != null)
        {
            _moveAi.GetIsFreeze(true);
        }
    }

    protected void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.mass = 30000f;
        _moveAi = GetComponent<AIController>();
    }

    void Update()
    {
        if (IsAlive)
        {
            _timer += 1 * Time.deltaTime;
            if (dronesAttack)
            {
                if (TurretDefeat.IsDefeat)
                {
                    ExplosionTurret();
                    PlayFlame();
                    Dead();
                }
                if (BortDefeat.IsDefeat)
                {
                    PlayFlame();
                    Dead();
                }
            }
        }
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Drone>() != null)
        {
            dronesAttack = true;
        }
    }

    private void ExplosionTurret()
    {
        ParticleSystem _explosion = _explosionTurret.GetComponent<ParticleSystem>();
        _explosion.Play();
        float turretMass = 10000f;
        _turret.transform.SetParent(null);
        if (_turret.GetComponent<Rigidbody>() == null)
        {
            _turret.AddComponent<Rigidbody>();
        }
        Rigidbody _rbTurret = _turret.GetComponent<Rigidbody>();
        _rbTurret.mass = turretMass;
        _rbTurret.AddForce(Vector3.up * _explosionForce * turretMass, ForceMode.Impulse);
        _rbTurret.AddTorque(new Vector3(1, 0, 1) * _explosionForce * turretMass, ForceMode.Impulse);
        Destroy(_explosionTurret, 1f);
        _flameTurret.Play();
    }

    private void PlayFlame()
    {
        foreach (ParticleSystem _flame in _flames)
        {
            _flame.Play();
        }
    }

    private void RotateTurret(float x, float y, float z)
    {
        _turret.transform.Rotate(x, y, z);
        Debug.Log("2");
    }
}
