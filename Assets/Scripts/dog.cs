using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    public GameObject humanGameObject;
    public human humanPlayer;
    public AudioSource soundBark;
    public float speed = 10;
    public Rigidbody2D rigidBody;
    public Vector2 moveDirection = new Vector2();
    public float barkRate;
    public bool barkReady;

    private Animator animator;
    private void Start()
    {
        humanPlayer = FindObjectOfType<human>();
        humanGameObject = humanPlayer.gameObject;
        rigidBody = GetComponent<Rigidbody2D>();
        humanPlayer = humanGameObject.GetComponent<human>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2d(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("lost");
        }
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);

        moveDirection =  new Vector2(moveX, moveY);
        moveDirection.Normalize();


        if (Input.GetMouseButtonDown(0) && barkReady)
        {
            barkReady = false;
            Bark();
            StartCoroutine(ReloadBark());
        }
        if (Input.GetMouseButtonDown(1) && barkReady)
        {
            barkReady = false;
            BarkTwice();
            StartCoroutine(ReloadBark());
        }

        rigidBody.velocity = moveDirection * speed;
    }

    void Bark()
    {
        if (IsCloseEnough())
        {
            humanPlayer.Bark(new Vector2(transform.position.x, transform.position.y));
            soundBark.Play();
        }
    }

    void BarkTwice()
    {
        if (IsCloseEnough())
        {
            humanPlayer.BarkAway(new Vector2(transform.position.x, transform.position.y));
            StartCoroutine(BarkTwiceSound());
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

    IEnumerator BarkTwiceSound()
    {
        soundBark.Play();
        yield return new WaitForSeconds(0.5f);
        soundBark.Play();
    }
   
    IEnumerator ReloadBark()
    {
        yield return new WaitForSeconds(barkRate);
        barkReady = true;
    }

}
