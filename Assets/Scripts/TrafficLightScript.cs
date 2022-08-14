using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightScript : MonoBehaviour
{
    [Header("Variables")]
    public string Direction;
    public string Side;
    public TrafficControllerSystem TCS;
    public enum LightEnum { Red, Green };
    public LightEnum Light;
    private void Update()
    {
        LightColor();
    }

    public void LightColor()
    {
        if (TCS.Direction == Direction)
        {
            Light = LightEnum.Green;
        }
        else
        {
            Light = LightEnum.Red;
        }
    }

}
