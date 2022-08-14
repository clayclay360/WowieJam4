using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficControllerSystem : MonoBehaviour
{
    [Header("Variables")]
    public float MaxTime;
    public float MinTime;
    public float Time;

    public bool Switch;
    public string Direction;

    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Switch)
        {
            Direction = "Horizontal";
        }
        else
        {
            Direction = "Vertical";
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            Time = Random.Range(MinTime, MaxTime);
            yield return new WaitForSeconds(Time);
            Switch = !Switch;
        }
    }
}
