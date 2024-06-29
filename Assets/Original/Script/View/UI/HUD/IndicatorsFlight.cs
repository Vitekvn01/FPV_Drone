using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndicatorsFlight : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private TextMeshProUGUI _heightText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _failedTimer;
    // Update is called once per frame

    private void Start()
    {
        if (LevelFailed.OnEventTimerFailed != null)
        {
            LevelFailed.OnEventTimerFailed.AddListener(SetTimer);
        }
    }
    void Update()
    {
        if (PlayerController.CurrentDrone != null)
        {
            _speedText.text = (int)PlayerController.CurrentDrone.GetCurrentSpeed() + LocalizationData.DictionaryLocalizationWords["KM/H"];
            _heightText.text = (int)PlayerController.CurrentDrone.GetCurrentHeight() + LocalizationData.DictionaryLocalizationWords["H"];
        }
        else
        {
            _speedText.text = "0" + LocalizationData.DictionaryLocalizationWords["KM/H"];
            _heightText.text = "0" + LocalizationData.DictionaryLocalizationWords["H"];
        }


        if (LevelFailed.OnEventTimerFailed != null)
        {
            Debug.Log("onEvent != null");
            TimeSpan failedTimeSpan = TimeSpan.FromSeconds(_failedTimer);
            _timerText.text = failedTimeSpan.ToString(@"hh\:mm\:ss");
        }
        else
        {
            DateTime currentTime = DateTime.Now;
            _timerText.text = currentTime.ToString(@"hh\:mm\:ss");
        }
    }

    private void SetTimer(float value)
    {
        _failedTimer = value;
    }
}
