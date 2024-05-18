using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEditor;
using UnityEngine;

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
    private Vector3 tiltDirVector;
    private Vector3 forceDirVector;
    private Vector3 helixVector;
    private Vector3 rotationDir;
    private float _hoverForce;
    private int currentforceHelixRotate;

    [SerializeField] private GameObject _explosionPrefub;

    private void OnCollisionEnter(Collision collision)
    {
        SpawnExplosion();
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
    private void FixedUpdate()
    {
        rb.angularVelocity = Vector3.zero;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxSpeed); // ограничение макс скорости

        rb.AddRelativeTorque(tiltDirVector * forceTilt * Time.deltaTime, ForceMode.Acceleration); // наклон

        rb.AddRelativeForce(forceDirVector * forceUp * Time.deltaTime, ForceMode.Acceleration); // тяга

        transform.Rotate(transform.up * rotationDir.x * forceRotate * Time.deltaTime); // вращение

        currentforceHelixRotate = forceHelixRotate;

        foreach (GameObject helix in helixList)
        {
              helix.transform.Rotate(Vector3.forward * forceUp, Space.Self);
        }

        float gravity = Physics.gravity.y; // Получаем гравитационную силу по оси Y
        _hoverForce = rb.mass * -gravity / Time.deltaTime; // Сила, необходимая для компенсации гравитации

        rb.AddRelativeForce(Vector3.up * _hoverForce * Time.deltaTime, ForceMode.Force); // сила для удержания дрона на высоте

        _currentSpeed = rb.velocity.magnitude;
        _currentHeight = transform.position.y;
    }

    public void GetTiltDirVector(Vector3 Value, float Sensitive, int Inversion)
    {
        tiltDirVector.z = -Value.x * Sensitive;
        tiltDirVector.x = -Value.y * Sensitive * Inversion;
    }

    public void GetForceDirVectorZ(Vector3 Value, float Sensitive)
    {
        forceDirVector.z = Value.y * Sensitive;
    }

    public void GetForceDirVectorY(Vector3 Value, float Sensitive)
    {
        forceDirVector.y = Value.y * Sensitive;
    }

    public void GetDirRotation(Vector3 Value, float Sensitive)
    {
        rotationDir.x = Value.x * Sensitive;
    }

    public void GetDrugRigidbody(float Drag)
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

}
