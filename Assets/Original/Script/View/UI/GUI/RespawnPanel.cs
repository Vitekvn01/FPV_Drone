using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private void Update()
    {
        _countText.text = "Count: " + PlayerController.Instance.CountDrone.ToString();
    }
    public void RespawnButton()
    {
        PlayerController.Instance.SpawnDrone();
    }
}
