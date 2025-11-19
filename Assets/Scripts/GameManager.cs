using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("score and game state")]

    public int correctOrders = 0;
    public int incorrectOrders = 0; // use as a mistake counter, im not renaming this for sake of time management 

    [SerializeField] int shiftMinsRemaining = 10;
    [SerializeField] int shiftSecsRemaining = 02;

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
        while (true)
        {
            if (isShiftActive)
            {
                shiftSecsRemaining--;

                if (shiftSecsRemaining <= 0)
                {
                    shiftMinsRemaining--;
                    shiftSecsRemaining = 59;
                }

                if (shiftMinsRemaining < 0)
                {
                    // End shift
                    Debug.Log("Shift over!");
                    isShiftActive = false;
                }


            }
            else
            {

                if (ticketManager.CheckAllTicketsAreGone())
                {
                    SceneManager.LoadScene("EndGame");
                    Debug.Log("Tickets cleared, game over!");
                }
                else
                {
                    Debug.Log("Waiting for tickets to clear...");

                }
                
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
