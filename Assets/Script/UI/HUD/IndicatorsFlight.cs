using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndicatorsFlight : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private TextMeshProUGUI _heightText;
    // Update is called once per frame
    void Update()
    {
        _speedText.text = _playerController.CurrentSpeed.ToString() + " KM/H";
        _heightText.text = _playerController.CurrentHeight.ToString() + " ALT";
    }
}
