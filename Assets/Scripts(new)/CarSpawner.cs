using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("Variables")]
    public float MaxTime;
    public float MinTime;
    public float Timer;

    [Space]
    public int NumberOfCars;
    public int MaxNumberOfCars;

    [Header("Spawner")]
    public GameObject[] CarPrefab;
    public Transform[] SpawnTransforms;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Timer);
            Timer = Random.Range(MinTime, MaxTime);

            if (NumberOfCars <= MaxNumberOfCars)
            {
                NumberOfCars++;
                int CarIndex = Random.Range(0, CarPrefab.Length);
                int SpawnIndex = Random.Range(0, SpawnTransforms.Length);
                GameObject Car = Instantiate(CarPrefab[CarIndex], SpawnTransforms[SpawnIndex].position, Quaternion.identity);
                CarController Controller = Car.GetComponent<CarController>();
                switch (SpawnIndex)
                {
                    case 0:
                        Controller.ChangeDirection(CarController.DirectionEnum.Right);
                        Controller.Side = CarController.SideEnum.Right;
                        break;
                    case 1:
                        Controller.ChangeDirection(CarController.DirectionEnum.Left);
                        Controller.Side = CarController.SideEnum.Left;
                        break;
                    case 2:
                        Controller.ChangeDirection(CarController.DirectionEnum.Up);
                        Controller.Side = CarController.SideEnum.Vertical;
                        break;
                    case 3:
                        Controller.ChangeDirection(CarController.DirectionEnum.Down);
                        Controller.Side = CarController.SideEnum.Vertical;
                        break;
                }
            }
        }
    }
}
