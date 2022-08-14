using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedesterianController : MonoBehaviour
{
    const float Tolerence = 0.3f;

    public List<Transform> path_pos;
    public float speed = 2f;

    public Rigidbody2D rigidBody;
    private int index = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance( path_pos[index].position, transform.position) < Tolerence)
        {
            index = index == path_pos.Count - 1 ? 0 : index + 1;
        }

        Vector2 direction = new Vector2(path_pos[index].position.x, path_pos[index].position.y) 
                          - new Vector2(transform.position.x, transform.position.y);

        direction.Normalize();


        
        rigidBody.velocity = direction * speed; ;
    }
}
