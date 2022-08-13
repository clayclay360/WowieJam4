using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    public GameObject humanGameObject;
    public human humanPlayer;
    public float speed = 10;
    public Rigidbody2D rigidBody;
    public Vector2 moveDirection = new Vector2();

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        humanPlayer = humanGameObject.GetComponent<human>();
    }
    void Update()
    {

        moveDirection =  new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();


        if (Input.GetMouseButtonDown(0))
        {
            Bark();
        }
        if (Input.GetMouseButtonDown(1))
        {
            BarkTwice();
        }

        rigidBody.velocity = moveDirection * speed;
    }

    void Bark()
    {
        if (IsCloseEnough())
        {
            humanPlayer.Bark(new Vector2(transform.position.x, transform.position.y));
        }
    }

    void BarkTwice()
    {
        if (IsCloseEnough())
        {
            humanPlayer.BarkAway(new Vector2(transform.position.x, transform.position.y));
        }
    }

    
    bool IsCloseEnough()
    {
        if (Vector3.Distance(humanGameObject.transform.position, transform.position) > 40)
        {
            return false;
        }
        return true;
    }
}
