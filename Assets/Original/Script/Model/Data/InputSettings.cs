using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    Arcade,
    Simulator
}

[CreateAssetMenu]
public class InputSettings : ScriptableObject
{
    private MovementType movementType;
    public MovementType MovementType => movementType;

    private bool _onInversionJoystick = false;
    public bool OnInversionJoystick => _onInversionJoystick;

    private float _sensitiveJoystick = 6;
    public float SensitiveJoystick => _sensitiveJoystick;

    public void SettingMovementType()
    {
        if (movementType == MovementType.Arcade)
        {
            movementType = MovementType.Simulator;
        }
        else
        {
            movementType = MovementType.Arcade;
        }
    }

    public void SettingInversionJoystick()
    {
        if (_onInversionJoystick)
        {
            _onInversionJoystick = false;
        }
        else _onInversionJoystick = true;
    }

    public void SetSensetiveJoystick(float Value)
    {
        _sensitiveJoystick = Value;
        Debug.Log(_sensitiveJoystick);
    }
}
