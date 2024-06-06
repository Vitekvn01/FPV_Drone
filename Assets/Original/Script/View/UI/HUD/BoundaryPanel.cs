using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (LevelBoundary.Instance.IsTimerDead)
        {
            text.gameObject.gameObject.SetActive(true);
            text.text = "NO SIGNAL: " + LevelBoundary.Instance.Timer.ToString("F0");
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
