using System;
using System.Reflection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class AI_AA : MonoBehaviour
{
    [SerializeField] private float _speedRotateTower;
    [SerializeField] private float _speedRotateMuzle;
    [SerializeField] private Transform _muzle;
    [SerializeField] private Transform _tower;
    [SerializeField] private float _fireRadius;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform[] _spawnPosition;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _lead;
    [SerializeField] private AudioSource _shootSound;
    private bool _onFire = true;

    private float timer;
    private int index = 0;
    private Transform target;
    private float _bulletSpeed;
    [SerializeField] private Destructible _dest;
    private void Start()
    {
        _dest = transform.root.GetComponent<Destructible>();
        _dest.OnDeadEvent.AddListener(OffFire);
        _bulletSpeed = BulletPrefab.GetComponent<Projectile>().Velocity;
    }
    void Update()
    {
        if (_onFire)
        {
            if (PlayerController.CurrentDrone != null)
            {
                target = PlayerController.CurrentDrone.transform;
            }



            if (target != null)
            {
                if (Vector3.Distance(transform.position, target.position) < _fireRadius)
                {
                    timer += Time.deltaTime;

                    RotateTower(_speedRotateTower);
                    RotateMuzle(_speedRotateMuzle);
                    Fire(_fireRate);
                }
            }
        }
    }

    private void Fire(float rate)
    {
        if (timer >= rate)
        {

            _shootSound.Play();
            Transform SpawnPos = _spawnPosition[index];
            Instantiate(BulletPrefab, SpawnPos.position, SpawnPos.rotation);
            if (index != _spawnPosition.Length - 1)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
            timer = 0;

        }
    }

    private void RotateTower(float speed)
    {
        float Y = Quaternion.RotateTowards(_tower.rotation, Quaternion.LookRotation(-(_tower.position - (target.position + LeadFire())).normalized), speed * Time.deltaTime).eulerAngles.y;
        _tower.rotation = Quaternion.Euler(0, Y, 0);

    }

    private void RotateMuzle(float speed)
    {
        float X = Quaternion.RotateTowards(_muzle.rotation, Quaternion.LookRotation(-(_muzle.position - (target.position + LeadFire())).normalized), speed * Time.deltaTime).eulerAngles.x;
        Math.Clamp(X, -55, 0); 
        _muzle.localRotation = Quaternion.Euler(X, 0, -90);

    }

    private Vector3 LeadFire()
    {
        if (PlayerController.CurrentDrone.RB.velocity != null && target != null)
        {
            return PlayerController.CurrentDrone.RB.velocity * (Vector3.Distance(transform.position, target.position) / _bulletSpeed);
        }
        return new Vector3(0, 0, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, _fireRadius);


        Gizmos.color = new Color(1, 0, 0, 0.5f);
        if (target != null)
        {
            Gizmos.DrawSphere(target.position + LeadFire(), 1);
        }

    }

    private void OffFire()
    {
        _onFire = false;
    }
}