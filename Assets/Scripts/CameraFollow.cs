using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private Vector3 target;
    private Vector3 velocity = Vector3.zero;

    
    // Update is called once per frame
    void Update()
    {
        target = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.2f);
    }
}
