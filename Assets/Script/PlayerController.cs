using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    [SerializeField] private VirtualJoystick _mobilelJoystickRight;
    [SerializeField] private VirtualJoystick _mobilelJoystickLeft;

    [SerializeField] private InputSettings _inputSettings;
    private MovementType _mevementType => _inputSettings.MovementType;
    private bool _inversionJoystick => _inputSettings.OnInversionJoystick;
    private int _inversion;

    private Rigidbody rb;
    private Vector3 tiltDirVector;
    private Vector3 forceDirVector;
    private Vector3 helixVector;

    private float _currentSpeed;
    public int CurrentSpeed => (int)_currentSpeed;

    private float _currentHeight;
    public int CurrentHeight => (int)_currentHeight;


    [SerializeField] private float _maxSpeed;
    [SerializeField] private int forceUp;
    [SerializeField] private int forceHelixRotate;
    [SerializeField] private int forceTilt;
    [SerializeField] private int forceRotate;
    [SerializeField] private List<GameObject> helixList;

    private float sensitiveJoystick => _inputSettings.SensitiveJoystick;

    private int currentforceHelixRotate;

    private float _hoverForce;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       /* Debug.Log(sensitiveJoystick);*/
        if (_inversionJoystick)
        {
            _inversion = -1;
        }
        else _inversion = 1;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxSpeed); // ограничение макс скорости
       
        helixVector.z = Input.GetAxisRaw("Jump") * forceUp;


        _currentSpeed = rb.velocity.magnitude;
        _currentHeight = transform.position.y;
        #region joystick_Input

        Vector3 torque = _mobilelJoystickRight.Value;

        tiltDirVector.z = -torque.x * sensitiveJoystick;
        tiltDirVector.x = -torque.y * sensitiveJoystick * _inversion;

        rb.AddRelativeTorque(tiltDirVector * forceTilt * Time.deltaTime, ForceMode.Acceleration);

        Vector3 heightForce = _mobilelJoystickLeft.Value;

        if (_mevementType == MovementType.Arcade)
        {
            rb.drag = 0.3f;
            forceDirVector.z = heightForce.y * sensitiveJoystick;
        }
        if (_mevementType == MovementType.Simulator)
        {
            rb.drag = 0.1f;
            forceDirVector.y = heightForce.y * sensitiveJoystick;
        }

        rb.AddRelativeForce(forceDirVector * forceUp * Time.deltaTime, ForceMode.Acceleration);

        Vector3 rotation = _mobilelJoystickLeft.Value * sensitiveJoystick;
        transform.Rotate(transform.up * rotation.x * forceRotate * Time.deltaTime);

        #endregion

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

        currentforceHelixRotate = forceHelixRotate;
        foreach (GameObject helix in helixList)
        {
            helix.transform.Rotate(Vector3.forward * currentforceHelixRotate, Space.Self);
        }

        float gravity = Physics.gravity.y; // Получаем гравитационную силу по оси Y
        _hoverForce = rb.mass * -gravity / Time.deltaTime; // Сила, необходимая для компенсации гравитации

        rb.AddRelativeForce(Vector3.up * _hoverForce * Time.deltaTime, ForceMode.Force);

    }
}

