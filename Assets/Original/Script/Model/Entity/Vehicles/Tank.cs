using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EffectParticlesPlay))]
[RequireComponent(typeof(ExplosionSpawn))]
public class Tank : Vehicle
{
    [Header(" оллайдеры у€звимых зон танка")]
    [SerializeField] private ColliderElement TowerDefeatCollider;
    [SerializeField] private ColliderElement BortDefeatCollider;

    [Header("—оставные части танка")]
    [SerializeField] private GameObject _tower;
    [SerializeField] private SuspensionTank _suspensionTank;

    [Header("Ёффекты")]
    [SerializeField] private ExplosionSpawn _towertExplosionSpawn; 
    [SerializeField] private EffectParticlesPlay _flametDefeatTowerPlay;
    [SerializeField] private EffectParticlesPlay _flameDefeatBortPlay;
    [SerializeField] private int _explosionForce;

    public GameObject Tower => _tower;

    private bool dronesAttack = false;
    private Rigidbody _rb;
    private AIController _moveAi;

    private float _timer =0;
    public override void Dead()
    {
        base.Dead();
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
                if (TowerDefeatCollider.IsDefeat)
                {
                    _towertExplosionSpawn.Spawn(_tower.transform.position);
                    _flametDefeatTowerPlay.Play();
                    DefeatTurret();
                    Dead();
                }
                if (BortDefeatCollider.IsDefeat)
                {
                    _flameDefeatBortPlay.Play();
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

    private void DefeatTurret()
    {
        float turretMass = 10000f;
        _tower.transform.SetParent(null);
        if (_tower.GetComponent<Rigidbody>() == null)
        {
            _tower.AddComponent<Rigidbody>();
        }
        Rigidbody _rbTurret = _tower.GetComponent<Rigidbody>();
        _rbTurret.mass = turretMass;
        _rbTurret.AddForce(Vector3.up * _explosionForce * turretMass, ForceMode.Impulse);
        _rbTurret.AddTorque(new Vector3(1, 0, 1) * _explosionForce * turretMass, ForceMode.Impulse);
    }


    public void MoveSuspention(float speed)
    {
        _suspensionTank.RollerRotate(speed);
        _suspensionTank.TrackScrolling(speed);
    }



    private void RotateTurret(float x, float y, float z)
    {
        _tower.transform.Rotate(x, y, z);
        Debug.Log("2");
    }
}
