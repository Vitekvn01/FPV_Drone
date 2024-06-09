using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _droneText;
    [SerializeField] private TextMeshProUGUI _countDroneText;
    [SerializeField] private TextMeshProUGUI _enemyText;
    [SerializeField] private TextMeshProUGUI _countEnemyText;
    [SerializeField] private TextMeshProUGUI _createDroneText;

    private void Start()
    {
        _droneText.text = LocalizationData.DictionaryLocalizationWords["Drones"];
        _enemyText.text = LocalizationData.DictionaryLocalizationWords["Enemies"];
        _createDroneText.text = "FPV";
    }
    private void Update()
    {
        _countDroneText.text = PlayerController.Instance.CountDrone.ToString();
        _countEnemyText.text = Enemy.ListEnemies.Count.ToString();
    }
    public void RespawnButton()
    {
        PlayerController.Instance.SpawnDrone();
    }
}
