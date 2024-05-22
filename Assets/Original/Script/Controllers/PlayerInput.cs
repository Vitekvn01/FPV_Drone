using UnityEngine;

public enum InputMode
{
    Mobile,
    KeyBoard
}

public class PlayerInput : SingletonBase<PlayerInput>
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
            torque.y = -Input.GetAxis("Vertical");
            heightForce.y = Input.GetAxis("Jump");
        }

        if (_drone != null)
        {
            MoveFPVDrone();
            SetParametrFliht();
        }
    }

    public void SetTargetDrone(Drone drone)
    {
        _drone = drone;
    }

    private void MoveFPVDrone()
    {
        _drone.SetDirRotation(rotation, SensitiveJoystick);
        _drone.SetTiltDirVector(torque, SensitiveJoystick, _inversion);

        if (_movementType == MovementType.Arcade)
        {
            _drone.SetDrugRigidbody(0.3f);
            _drone.SetForceDirVectorZ(heightForce, SensitiveJoystick);
        }
        if (_movementType == MovementType.Simulator)
        {
            _drone.SetDrugRigidbody(0.1f);
            _drone.SetForceDirVectorY(heightForce, SensitiveJoystick);
        }
    }

    private void SetParametrFliht()
    {
        _currentSpeed = _drone.SetCurrentSpeed();
        _currentHeight = _drone.SetCurrentHeight();
    }
}

