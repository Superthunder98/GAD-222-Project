using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    public int minCongruentOrders = 1;
    public int maxCongruentOrders = 11;

    public int currentOrders = 0;

    public int maxItems = 6;
    public int minItems = 1;

    [SerializeField] List<GameObject> productList = new List<GameObject>();
    [SerializeField] List<GameObject> currentOrder = new List<GameObject>();

    void GenerateOrder()
    {
        currentOrder.Clear();
        int itemCount = Random.Range(minItems, maxItems + 1);
        for (int i = 0; i < itemCount; i++)
        {
            int randomIndex = Random.Range(0, productList.Count);
            currentOrder.Add(productList[randomIndex]);
        }
        Debug.Log("New Order Generated");
    }










}
