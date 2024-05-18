using UnityEngine;

public enum InputMode
{
    Mobile,
    KeyBoard
}

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Drone _drone;
    [SerializeField] private VirtualJoystick _mobilelJoystickRight;
    [SerializeField] private VirtualJoystick _mobilelJoystickLeft;

    [SerializeField] private InputSettings _inputSettings;
    [SerializeField] private InputMode _inputMode;

    private MovementType _movementType => _inputSettings.MovementType;
    private bool _inversionJoystick => _inputSettings.OnInversionJoystick;

    private int _inversion;

    private float _currentSpeed;
    public int CurrentSpeed => (int)_currentSpeed;

    private float _currentHeight;
    public int CurrentHeight => (int)_currentHeight;
    private float SensitiveJoystick => _inputSettings.SensitiveJoystick;

    Vector3 torque;
    Vector3 heightForce;
    Vector3 rotation;

    void FixedUpdate()
    {
        if (_inversionJoystick)
        {
            _inversion = -1;
        }
        else _inversion = 1;

        if (_inputMode == InputMode.Mobile)
        {
            torque = _mobilelJoystickRight.Value;
            heightForce = _mobilelJoystickLeft.Value;
            rotation = _mobilelJoystickLeft.Value;
        }
        else
        {
            torque.x = Input.GetAxis("Horizontal");
            torque.y = - Input.GetAxis("Vertical");
            heightForce.y = Input.GetAxis("Jump");
        }

        _drone.GetDirRotation(rotation, SensitiveJoystick);
        _drone.GetTiltDirVector(torque, SensitiveJoystick, _inversion);

        _currentSpeed = _drone.SetCurrentSpeed();
        _currentHeight = _drone.SetCurrentHeight();

        if (_movementType == MovementType.Arcade)
        {
            _drone.GetDrugRigidbody(0.3f);
            _drone.GetForceDirVectorZ(heightForce, SensitiveJoystick);
        }
        if (_movementType == MovementType.Simulator)
        {
            _drone.GetDrugRigidbody(0.1f);
            _drone.GetForceDirVectorY(heightForce, SensitiveJoystick);
        }
        /*#region PC_Input

        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            tiltDirVector.z = -Input.GetAxis("Mouse X") * sensitiveMouse;
            tiltDirVector.x = -Input.GetAxis("Mouse Y") * sensitiveMouse;

            rb.AddRelativeTorque(tiltDirVector * forceTilt * Time.deltaTime);
        }
        else rb.angularVelocity = Vector3.zero;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            tiltDirVector.z = -Input.GetAxisRaw("Horizontal");
            tiltDirVector.x = Input.GetAxisRaw("Vertical");

            rb.AddRelativeTorque(tiltDirVector * forceTilt * Time.deltaTime);
        }

        if (Input.GetButton("Jump"))
        {
            forceDirVector.y = Input.GetAxisRaw("Jump");
            rb.AddRelativeForce(forceDirVector * forceUp * Time.deltaTime, ForceMode.Acceleration);
            currentforceHelixRotate += forceUp;
        }
        #endregion*/
    }

    public void SetTargetDrone(Drone drone)
    {
        _drone = drone;
    }
}

