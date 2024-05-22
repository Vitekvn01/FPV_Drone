using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drone : MonoBehaviour
{
    [Header("Характеристики")]
    [SerializeField] private float _maxSpeed;
    [SerializeField] private int forceUp;
    [SerializeField] private int forceHelixRotate;
    [SerializeField] private int forceTilt;
    [SerializeField] private int forceRotate;

    [SerializeField] private List<GameObject> helixList;

    private float _currentSpeed;
    private float _currentHeight;

    private Rigidbody rb;
    private Vector3 tiltDir; // направление наклона
    private Vector3 tractionDir; // направление тяги
    private Vector3 rotationDir; // направление поврота
    private float _hoverForce;

    [SerializeField] private GameObject _explosionPrefub;

    public UnityEvent OnDestroyEvent;
    private void OnCollisionEnter(Collision collision)
    {
        SpawnExplosion();
        Destroy(gameObject, 0);
    }

    private void SpawnExplosion()
    {
        GameObject _explosion = Instantiate(_explosionPrefub, gameObject.transform);
        Destroy(_explosion, 2);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected virtual void FixedUpdate()
    {
        Limit();

        Torgue();

        Rotate();

        Traction();

        Hovering();

        RotateHelix();

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
        transform.Rotate(transform.up * rotationDir.x * forceRotate * Time.deltaTime); // вращение
    }

    /// <summary>
    /// Тяга дрона
    /// </summary>
    protected virtual void Traction()
    {
        rb.AddRelativeForce(tractionDir * forceUp * Time.deltaTime, ForceMode.Acceleration);  // тяга
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
        foreach (GameObject helix in helixList)
        {
            helix.transform.Rotate(Vector3.forward * forceUp, Space.Self);
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
    }

    public void SetDrugRigidbody(float Drag)
    {
        rb.drag = Drag;
    }

    public float SetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public float SetCurrentHeight()
    {
        return _currentHeight;
    }

    #endregion

    private void OnDestroy()
    {
        OnDestroyEvent.Invoke();
    }
}
