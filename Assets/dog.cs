using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rigidBody;
    public Vector2 moveDirection = new Vector2();

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        moveDirection =  new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();



        rigidBody.velocity = moveDirection * speed;
    }

    void Bark()
    {
        
    }

    void BarkTwice()
    {

    }

    

}
