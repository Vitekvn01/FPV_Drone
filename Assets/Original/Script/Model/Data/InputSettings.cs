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

    private float _sensitiveJoystick = 8;
    public float SensitiveJoystick => _sensitiveJoystick;

    public void LoadInputSettings()
    {
        if (PlayerPrefs.GetInt("MovementType", 0) == 0)
        {
            movementType = MovementType.Arcade;
        } else movementType = MovementType.Simulator;

        if (PlayerPrefs.GetInt("InversionJoystick", 1) == 0)
        {
            _onInversionJoystick = true;
        }
        else _onInversionJoystick = false;

        _sensitiveJoystick = PlayerPrefs.GetInt("sensitivejoystick", 8);

    }

    public void SettingMovementType()
    {
        if (movementType == MovementType.Arcade)
        {
            PlayerPrefs.SetInt("MovementType", 1);
            movementType = MovementType.Simulator;
        }
        else
        {
            PlayerPrefs.SetInt("MovementType", 0);
            movementType = MovementType.Arcade;
        }
    }

    public void SettingInversionJoystick()
    {
        if (_onInversionJoystick)
        {
            _onInversionJoystick = false;
            PlayerPrefs.SetInt("InversionJoystick", 1);
        }
        else
        {
            _onInversionJoystick = true;
            PlayerPrefs.SetInt("InversionJoystick", 0);
        }

    }

    public void SetSensetiveJoystick(float Value)
    {
        _sensitiveJoystick = Value;
        PlayerPrefs.SetFloat("sensitivejoystick", Value);
        Debug.Log(_sensitiveJoystick);
    }
}
