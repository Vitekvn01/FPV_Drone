using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class Drone : Destructible
{
    [SerializeField] DroneType _droneType;
    public DroneType DroneType => _droneType;

    [Header("Характеристики")]
    [SerializeField] protected float _maxSpeed;
    [SerializeField] protected int forceTraction;
    [SerializeField] protected int forceHelixRotate;
    [SerializeField] protected int forceTilt;
    [SerializeField] protected int forceRotate;

    [Header("Эффекты")]
    [SerializeField] private List<GameObject> helixList;
    [SerializeField] protected AudioSource _helixSound;



    private bool isTraction = false;
    private float _currentSpeed;
    private float _currentHeight;

    protected Rigidbody rb;
    public Rigidbody RB => rb;
    protected Vector3 tiltDir; // направление наклона
    protected Vector3 tractionDir; // направление тяги
    protected Vector3 rotationDir; // направление поврота
    protected float _hoverForce;



    public UnityEvent OnDestroyEvent;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Dead();
    }



    protected virtual void Start()
    {
        OnDeadEvent.AddListener(OnDestroyEvent.Invoke);
        rb = GetComponent<Rigidbody>();
        _helixSound.loop = true;
        _helixSound.spatialBlend = 1;
    }
    protected virtual void FixedUpdate()
    {
        Limit();

        Torgue();

        Rotate();

        Traction();

        Hovering();

        RotateHelix();

        TractionSoundEffect();

    }


    /// <summary>
    /// Наклон дрона
    /// </summary>
    protected virtual void Torgue()
    {
        rb.AddRelativeTorque(tiltDir * forceTilt * Time.deltaTime, ForceMode.Acceleration); // наклон   
    }

    /// <summary>
    /// Поворот дрона
    /// </summary>
    protected virtual void Rotate()
    {
        transform.Rotate(transform.up * rotationDir.x * forceRotate * Time.deltaTime, Space.World); // вращение
    }

    /// <summary>
    /// Тяга дрона
    /// </summary>
    protected virtual void Traction()
    {
        rb.AddRelativeForce(tractionDir * forceTraction * Time.deltaTime, ForceMode.Acceleration);  // тяга
    }

    /// <summary>
    /// Ограничение харатеристик дрона:
    /// angularVelocity и velocity
    /// </summary>
    protected virtual void Limit()
    {
        rb.angularVelocity = Vector3.zero;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxSpeed); // ограничение макс скорости
    }

    /// <summary>
    /// Рассчет силы и зависание дрона над месте
    /// </summary>
    protected virtual void Hovering()
    {
        float gravity = Physics.gravity.y; // Получаем гравитационную силу по оси Y
        _hoverForce = rb.mass * -gravity / Time.deltaTime; // Сила, необходимая для компенсации гравитации

        rb.AddRelativeForce(Vector3.up * _hoverForce * Time.deltaTime, ForceMode.Force); // сила для удержания дрона на высоте

        _currentSpeed = rb.velocity.magnitude;
        _currentHeight = transform.position.y;
    }

    protected virtual void RotateHelix()
    {
        if (helixList != null)
        {
            foreach (GameObject helix in helixList)
            {
                helix.transform.Rotate(Vector3.forward * forceTraction, Space.Self);
            }
        }
    }

    protected virtual void TractionSoundEffect()
    {
        if (tractionDir.z != 0 || tractionDir.z != 0)
        {
            _helixSound.volume = 0.75f;
            _helixSound.pitch = 1.10f;
        }
        else
        {
            _helixSound.volume = 0.60f;
            _helixSound.pitch = 1;
        }
            
            
    }

    #region API
    public void SetTiltDirVector(Vector3 Value, float Sensitive, int Inversion)
    {
        tiltDir.z = -Value.x * Sensitive;
        tiltDir.x = -Value.y * Sensitive * Inversion;
    }

    public void SetForceDirVectorZ(Vector3 Value, float Sensitive)
    {
        tractionDir.z = Value.y * Sensitive;
    }

    public void SetForceDirVectorY(Vector3 Value, float Sensitive)
    {
        tractionDir.y = Value.y * Sensitive;
    }

    public void SetDirRotation(Vector3 Value, float Sensitive)
    {
        rotationDir.x = Value.x * Sensitive;
        rotationDir.y = -Value.y * Sensitive;
    }

    public void SetDrugRigidbody(float Drag)
    {
        rb.drag = Drag;
    }

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public float GetCurrentHeight()
    {
        return _currentHeight;
    }

    #endregion

    public override void Dead()
    {
        base.Dead();
        Destroy(gameObject);
    }
}
