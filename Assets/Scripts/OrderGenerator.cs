using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
   

    [SerializeField] BurgerSpawn burgerSpawnScript;
    [SerializeField] GameManager gameManager;


    public int maxItems = 8;
    public int minItems = 1;

   
    [SerializeField] List<GameObject> currentOrder = new List<GameObject>();
    [SerializeField] List<Transform> ticketVisualSpots = new List<Transform>();


    private void Awake()
    {
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
        burgerSpawnScript = gameManager.GetComponent<BurgerSpawn>();

        GenerateOrder();
    }

    void GenerateOrder()
    {
        currentOrder.Clear();
        int itemCount = Random.Range(minItems, maxItems + 1);
        for (int i = 0; i < itemCount; i++)
        {
            int randomIndex = Random.Range(0, gameManager.GetComponent<GameManager>().productList.Count);
            currentOrder.Add(gameManager.GetComponent<GameManager>().productList[randomIndex]);
        }
        Debug.Log("New Order Generated");

        gameObject.GetComponent<OrderTickets>().currentOrder = new List<GameObject>(currentOrder);

        foreach (GameObject item in currentOrder)
        {
            Instantiate(item.GetComponent<FoodData>().dispalyIcon, ticketVisualSpots[0]);

            ticketVisualSpots.RemoveAt(0);
        }
            
        foreach (GameObject item in currentOrder)
        {
            burgerSpawnScript.productionQueue.Add(item);
        }

        Debug.Log("Order made successfuly");

        Destroy(this);

    }










}
