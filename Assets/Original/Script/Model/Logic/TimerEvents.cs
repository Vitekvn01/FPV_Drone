using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvents : MonoBehaviour
{
    [SerializeField] private float _time;

    public UnityEvent OnTimerEvent;

    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _time)
        {
            OnTimerEvent.Invoke();
            timer = 0;
        }

    }
}
