using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    public enum States 
    {
    Idle,
    Bark_Towards,
    Bark_Away
    }

    public States state = States.Idle;
    public Vector2 ScareDirection;
    public float coolDownTimerLength = 3f;
    private float coolDownTimer = 0f;


    [Header("Steering Mechanics")]
    [SerializeField]
    public float steerStrength = 0.2f;
    [SerializeField]
    private float Speed = 8;
    [SerializeField]
    private float IdleSpeed = 1f;

    public Vector2 movement = new Vector2();

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Bark(Vector2 dogPosition )
    {
        ScareDirection = dogPosition - new Vector2(transform.position.x, transform.position.y);
        coolDownTimer = coolDownTimerLength;


        //move
        movement = ScareDirection.normalized * 30;
        state = States.Bark_Away;
    }

    public void BarkAway(Vector2 dogPosition)
    {
        ScareDirection = dogPosition - new Vector2(transform.position.x, transform.position.y);
        coolDownTimer = coolDownTimerLength;

        
      
        movement = -ScareDirection.normalized * 30;
        state = States.Bark_Towards;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
   
        if (collision.gameObject.tag == "Enemy")
        {
            //lose
            print("lose");
        }
    }
    private void Update()
    {
        HandleState();


    }

    void HandleState()
    {
        movement += new Vector2(Random.Range(-steerStrength, steerStrength), Random.Range(-steerStrength, steerStrength)) * Time.deltaTime;
            
        coolDownTimer = Mathf.Max(coolDownTimer - Time.deltaTime, 0);
        if (coolDownTimer <= 0)
        {
            movement = new Vector2(Random.Range(-steerStrength * coolDownTimerLength, steerStrength * coolDownTimerLength), Random.Range(-steerStrength * coolDownTimerLength, steerStrength * coolDownTimerLength));
            coolDownTimer = coolDownTimerLength;
            state = States.Idle;
        }
        if ( state == States.Idle)
        {
            rigidBody.velocity = movement.normalized * IdleSpeed;
        }

        if( state == States.Bark_Towards || state == States.Bark_Away)
        {
            rigidBody.velocity = movement.normalized * Speed;
        }

    }

    

}
