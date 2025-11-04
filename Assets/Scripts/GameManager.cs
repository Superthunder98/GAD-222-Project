using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("score and game state")]

    [SerializeField] int correctOrders = 0;
    [SerializeField] int incorrectOrders = 0;



    [Header("reference and values")]
    [SerializeField] TicketTrayManager ticketManager;

    public List<GameObject> productList = new List<GameObject>();

    [SerializeField] float minTicketSpawnTime = 3f;
    [SerializeField] float maxTicketSpawnTime = 30f;


    public GameObject goodText;
    public GameObject badText;



    void Start()
    {
        // Start the ticket spawning process
        StartCoroutine(ticketTimer());
    }

    IEnumerator ticketTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTicketSpawnTime, maxTicketSpawnTime));
            ticketManager.PlaceTicket();
        }
    }

    public void OrderCorrect()
    {
        Debug.LogWarning("Order correct!");
        correctOrders++;
        goodText.SetActive(true);
        StartCoroutine(turnOffText());
    }

    public void OrderIncorrect()
    {
        Debug.LogWarning("Order Incorrect!");
        incorrectOrders++;
        badText.SetActive(true);
        StartCoroutine(turnOffText());

    }


    IEnumerator turnOffText()
    {
        yield return new WaitForSeconds(01f);
        goodText.SetActive(false);
        badText.SetActive(false);
    }
}
