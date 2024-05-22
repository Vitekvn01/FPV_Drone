using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private void Update()
    {
        _countText.text = Player.Instance.CountDrone.ToString();
    }
    public void RespawnButton()
    {
        Player.Instance.SpawnDrone();
    }
}
