using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets;
    private bool _win = false;
    private static int _countTarget;
    void Start()
    {
        _countTarget = _targets.Count;
    }

    void Update()
    {
        if (_countTarget <= 0)
        {
            _win = true;
            Debug.Log("Победа");

        }
    }

    public static void SubtractTarget()
    {
        _countTarget -= 1;
        Debug.Log("-1 цель");
    }


}
