using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("score and game state")]

    [SerializeField] int correctOrders = 0;
    [SerializeField] int incorrectOrders = 0;

    [SerializeField] int shiftMinsRemaining = 5;
    [SerializeField] int shiftSecsRemaining = 0;

    public bool isShiftActive = true;


    [Header("reference and values")]
    [SerializeField] TicketTrayManager ticketManager;

    public List<GameObject> productList = new List<GameObject>();

    [SerializeField] float minTicketSpawnTime = 3f;
    [SerializeField] float maxTicketSpawnTime = 30f;


    public GameObject goodText;
    public GameObject badText;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Start()
    {
        // Start the ticket spawning process
        StartCoroutine(ticketTimer());
        StartCoroutine(shiftimetr());
    }

    IEnumerator ticketTimer()
    {
        while (isShiftActive)
        {
            yield return new WaitForSeconds(Random.Range(minTicketSpawnTime, maxTicketSpawnTime));
            ticketManager.PlaceTicket();
        }
    }

    IEnumerator shiftimetr()
    {
        while (isShiftActive)
        {
            shiftSecsRemaining--;

            if (shiftSecsRemaining <= 0)
            {
                shiftMinsRemaining--;
                shiftSecsRemaining = 59;
            }

            if (shiftMinsRemaining == 0 && shiftSecsRemaining == 0)
            {
                // End shift
                Debug.Log("Shift over!");
                isShiftActive = false;
            }

            yield return new WaitForSeconds(1f);
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
