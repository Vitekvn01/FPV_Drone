using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoutDrone : Drone
{
    private Camera _camera;

    protected override void Start()
    {
        base.Start();
        _camera = gameObject.GetComponentInChildren<Camera>();
        _helixSound.pitch = 0.9f;
        _helixSound.volume = 0.5f;
    }
    protected override void Limit()
    {
        base.Limit();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    protected override void Rotate()
    {
        transform.Rotate(Vector3.up * rotationDir.x * forceRotate * (_camera.fieldOfView/60) * Time.deltaTime, Space.World); // 
        transform.Rotate(transform.right * rotationDir.y * forceRotate * (_camera.fieldOfView / 60) * Time.deltaTime, Space.World);
    }

    protected override void TractionSoundEffect()
    {
        
    }

    public void RemoveZOOM()
    {
        _camera.fieldOfView += 1;
        if (_camera.fieldOfView >= 60) _camera.fieldOfView = 60;
        if (_camera.fieldOfView <= 5) _camera.fieldOfView = 5;
    }

    public void AddZOOM()
    {
        _camera.fieldOfView -= 1;
        if (_camera.fieldOfView >= 60) _camera.fieldOfView = 60;
        if (_camera.fieldOfView <= 5) _camera.fieldOfView = 5;
    }

    public void SetZOOM(float Value)
    {
        _camera.fieldOfView = - Value;
        if (_camera.fieldOfView >= 60) _camera.fieldOfView = 60;
        if (_camera.fieldOfView <= 5) _camera.fieldOfView = 5;
    }

}
