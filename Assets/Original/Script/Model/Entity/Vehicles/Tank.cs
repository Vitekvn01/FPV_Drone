using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EffectParticlesPlay))]
/*[RequireComponent(typeof(ExplosionSpawn))]*/
public class Tank : Vehicle
{
    [Header(" оллайдеры у€звимых зон танка")]
    [SerializeField] private ColliderElement TowerDefeatCollider;
    [SerializeField] private ColliderElement BortDefeatCollider;

    [Header("—оставные части танка")]
    [SerializeField] private GameObject _tower;
    [SerializeField] private SuspensionTank _suspensionTank;

    [Header("Ёффекты")]
    [SerializeField] private GameObject _towerExplosion;
    [SerializeField] private GameObject _bodyDefeatSoundEffect;
    [SerializeField] private AudioSource _motorSound;
    [SerializeField] private AudioSource _trackSound;

    [SerializeField] private EffectParticlesPlay _flametDefeatTowerPlay;
    [SerializeField] private EffectParticlesPlay _flameDefeatBortPlay;
    [SerializeField] private int _explosionForce;

    private Transform _bodyDefeatPosition;
    public GameObject Tower => _tower;

    private bool dronesAttack = false;
    private Rigidbody _rb;
    private AIController _moveAi;

    private float _timer =0;
    public override void Dead()
    {
        base.Dead();

        _motorSound.Pause();
        _trackSound.Pause();
    }

    protected void Start()
    {
        _motorSound.Play();
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
                    Instantiate(_towerExplosion, _tower.transform.position, Quaternion.identity );
                    _flametDefeatTowerPlay.Play();
                    DefeatTurret();
                    Dead();
                }
                if (BortDefeatCollider.IsDefeat)
                {
                    Instantiate(_bodyDefeatSoundEffect, gameObject.transform.position, Quaternion.identity);
                    _flameDefeatBortPlay.Play();
                    Dead();
                }
            }
        }
        
    }



    private void OnCollisionEnter(Collision collision)
    {
/*        _bodyDefeatPosition = collision.gameObject.transform;*/
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

    private void StopSuspention()
    {
        _suspensionTank.RollerRotate(0);
        _suspensionTank.TrackScrolling(0);
    }

    public void SuspentionSound()
    {
        _trackSound.Play();
    }


    private void RotateTurret(float x, float y, float z)
    {
        _tower.transform.Rotate(x, y, z);
        Debug.Log("2");
    }
}
