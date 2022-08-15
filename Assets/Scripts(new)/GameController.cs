using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Variables")]
    public bool gameStarted;

    [Header("UI")]
    public TextMeshProUGUI countDownText;
    public TextMeshProUGUI walletText;

    [Header("Spawn Coins")]
    public float minTime;
    public float maxTime;
    public float Timer;
    public GameObject currencyPrefab;

    [Header("Map")]
    public Transform[] CoinSpawns;
    public Transform[] PlayerSpawns;

    [Header("CoinCount")]
    public int numberOfCoins;
    public int maxNumberOfCoins;

    [Header("Player")]
    public GameObject Duo;

    private void Start()
    {
        //StartGame();
    }

    public void StartGame()
    {
        gameStarted = true;
        StartCoroutine(CountDown());
    }

    public void SpawnPlayer()
    {
        Duo.SetActive(true);
        Duo.transform.position = PlayerSpawns[Random.Range(0, PlayerSpawns.Length)].position;
        walletText.gameObject.SetActive(true);
    }

    IEnumerator CountDown()
    {
        int countDown = 3;
        Debug.Log("Counting Down");

        while(countDown > 0)
        {
            countDownText.text = countDown.ToString();
            yield return new WaitForSeconds(1);
            countDown--;
        }

        SpawnPlayer();
        countDownText.text = "";
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (gameStarted)
        {
            if (numberOfCoins < maxNumberOfCoins)
            {
                Instantiate(currencyPrefab, CoinSpawns[Random.Range(0,CoinSpawns.Length)].position, Quaternion.identity);
                numberOfCoins++;
            }
            Timer = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(Timer);
        }
    }
    
    public void GameOver()
    {
        countDownText.text = "Game Over";
    }
}
