using UnityEngine;

public enum InputMode
{
    Mobile,
    KeyBoard
}

public enum DroneType
{
    Drone,
    ScoutDrone,
}

public class PlayerInput : SingletonBase<PlayerInput>
{
    [SerializeField] private Drone _drone;

    [SerializeField] private GameObject _zoomButtonPanel;
    [SerializeField] private PointerClickHold _upClickHold;
    [SerializeField] private PointerClickHold _downClickHold;
    [SerializeField] private VirtualJoystick _mobilelJoystickRight;
    [SerializeField] private VirtualJoystick _mobilelJoystickLeft;
    [SerializeField] private float _drugAracade = 0.6f;
    [SerializeField] private float _drugSimulator = 0.2f;

    [SerializeField] private InputSettings _inputSettings;
    [SerializeField] private InputMode _inputMode;
    [SerializeField] private DroneType _droneType;


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

    protected override void Awake()
    {
        base.Awake();
        _inputSettings.LoadInputSettings();
    }

    private void Start()
    {
        if (Application.isMobilePlatform != true)
        {
            _inputMode = InputMode.KeyBoard;
            _upClickHold.gameObject.SetActive(false);
            _downClickHold.gameObject.SetActive(false);
            _mobilelJoystickRight.gameObject.SetActive(false);
            _mobilelJoystickLeft.gameObject.SetActive(false);
        }
        else
        {
            _inputMode = InputMode.Mobile;
        }
    }

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
            rotation.x = Input.GetAxis("Rotation");
        }

        if (_drone != null)
        {
            if (_drone.DroneType == DroneType.Drone)
            {
                MoveFPVDrone();
            }
            if (_drone.DroneType == DroneType.ScoutDrone)
            {
                MoveScoutDrone();
            }
            SetParametrFliht();
        }
    }

    public void SetTargetDrone(Drone drone)
    {
        _drone = drone;
        if (_drone.DroneType == DroneType.ScoutDrone)
        {
            DrawZoomButtonPanel(true);
        }
        else
        {
            DrawZoomButtonPanel(false);
            if (_inputMode == InputMode.Mobile)
            {
                _mobilelJoystickLeft.gameObject.SetActive(true);
            }
        }
    }

    private void DrawZoomButtonPanel(bool Value)
    {
        _zoomButtonPanel.gameObject.SetActive(Value);
        _mobilelJoystickLeft.gameObject.SetActive(false);
    }

    private void MoveFPVDrone()
    {
        _drone.SetDirRotation(rotation, SensitiveJoystick);
        _drone.SetTiltDirVector(torque, SensitiveJoystick, _inversion);

        if (_movementType == MovementType.Arcade)
        {
            _drone.SetDrugRigidbody(_drugAracade);
            _drone.SetForceDirVectorZ(heightForce/ _drugAracade, 10);
        }
        if (_movementType == MovementType.Simulator)
        {
            _drone.SetDrugRigidbody(_drugSimulator);
            _drone.SetForceDirVectorY(heightForce, 10);
        }
    }

    private void MoveScoutDrone()
    {
        if (_drone is ScoutDrone)
        {
            ScoutDrone scoutDrone = (ScoutDrone)_drone;
            if (_upClickHold.IsHold || Input.GetAxis("Rotation") < 0)
            {
                scoutDrone.AddZOOM();
            }
            if (_downClickHold.IsHold || Input.GetAxis("Rotation") > 0)
            {
                scoutDrone.RemoveZOOM();
            }

        }
        _drone.SetDirRotation(torque, SensitiveJoystick);
    }

    private void SetParametrFliht()
    {
        _currentSpeed = _drone.GetCurrentSpeed();
        _currentHeight = _drone.GetCurrentHeight();
    }
}

