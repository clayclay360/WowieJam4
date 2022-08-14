using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Variables")]
    public float Speed;
    public bool Go;
    public enum DirectionEnum { Right, Left, Up, Down };
    public DirectionEnum Direction;
    public enum SideEnum { Right, Left}
    public SideEnum Side;

    [Space]
    public DirectionEnum StartDirection;
    [Header("RayCast")]
    public Transform StartRay;
    public Transform EndRay;

    private bool CheckLight;
    private bool CarInFront;

    private Vector2 Movement;
    private Animator CarAnimator;
    private TrafficLightScript LocalTLS;

    // Start is called before the first frame update
    void Start()
    {
        CarAnimator = GetComponent<Animator>();
        ChangeDirection(StartDirection);
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
        CheckForGo();
        RayCast();
    }

    public void CheckForGo()
    {
        if (CheckLight)
        {
            if(LocalTLS.Light == TrafficLightScript.LightEnum.Green)
            {
                Go = true;
                CheckLight = false;
            }
        }
    }

    public void Drive()
    {
        if (Go)
        {
            transform.Translate(Movement * Speed * Time.deltaTime);
        }
    }

    public void ChangeDirection(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.Right:
                Movement = Vector2.right;
                Side = SideEnum.Right;
                CarAnimator.SetTrigger("Right");
                break;
            case DirectionEnum.Left:
                Movement = Vector2.left;
                Side = SideEnum.Left;
                CarAnimator.SetTrigger("Left");
                break;
            case DirectionEnum.Up:
                Movement = Vector2.up;
                CarAnimator.SetTrigger("Up");
                break;
            case DirectionEnum.Down:
                Movement = Vector2.down;
                CarAnimator.SetTrigger("Down");
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TrafficLightScript>())
        {    
            TrafficLightScript TLS = collision.gameObject.GetComponent<TrafficLightScript>();

            if (TLS.Light == TrafficLightScript.LightEnum.Red && TLS.Side == Side.ToString()) 
            {
                Go = false;
                CheckLight = true;
                LocalTLS = TLS;
            }
        }

        if (collision.gameObject.GetComponent<DirectionMaker>())
        {
            DirectionMaker directionMaker = collision.gameObject.GetComponent<DirectionMaker>();

            if (directionMaker.Side == Side.ToString())
            {
                switch (directionMaker.Direction[Random.Range(0, directionMaker.Direction.Length)]) 
                {
                    case "Right":
                        ChangeDirection(DirectionEnum.Right);
                        Debug.Log("Right");
                        break;
                    case "Left":
                        ChangeDirection(DirectionEnum.Left);
                        Debug.Log("Left");
                        break;
                    case "Up":
                        ChangeDirection(DirectionEnum.Up);
                        Debug.Log("Up");
                        break;
                    case "Down":
                        ChangeDirection(DirectionEnum.Down);
                        Debug.Log("Down");
                        break;
                }
            }
        }
    }

    private void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(StartRay.position, EndRay.position);
        Debug.DrawLine(StartRay.position,EndRay.position);
        if(hit.collider != null && hit.collider.GetComponent<CarController>() && hit.collider != this.gameObject.GetComponent<Collider2D>())
        {
            Go = false;
            CarInFront = true;
            Debug.Log("Stop");
        }
        else
        {
            if (CarInFront)
            {
                Go = true;

            }
        }
    }
}
