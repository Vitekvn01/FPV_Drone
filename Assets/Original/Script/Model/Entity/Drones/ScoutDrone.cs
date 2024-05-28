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

    }
    protected override void Limit()
    {
        base.Limit();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    protected override void Rotate()
    {
        transform.Rotate(Vector3.up * rotationDir.x * forceRotate * Time.deltaTime, Space.World); // 
        transform.Rotate(transform.right * rotationDir.y * forceRotate * Time.deltaTime, Space.World);
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

}
