using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBag : MonoBehaviour
{
    [SerializeField] GameManager gameManager;


    [SerializeField] List<GameObject> packedItems = new List<GameObject>();

    [SerializeField] List<GameObject> requiredItem = new List<GameObject>();

    // TESTING
    // TEMP ONLY
    public GameObject goodText;
    public GameObject badText;

    // TESTING
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Validating order...");
            Validate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FoodItem"))
        {
            Debug.Log("Item packed: " + collision.gameObject.name);
            if (!packedItems.Contains(collision.gameObject))
            {
                packedItems.Add(collision.gameObject);
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Item removed: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("FoodItem"))
        {
            packedItems.Remove(collision.gameObject);
        }
    }

   



    public void Validate()
    {
        if(packedItems.Count < requiredItem.Count)
        {
            Debug.Log("ITEM COUNT MISMATCH");
            OrderIncorrect();
            return;
        }

        foreach (GameObject item in packedItems)
        {
            foreach(GameObject required in requiredItem)
            {
                Debug.LogWarning("TEST TEST TEST TEST");
                if (required.GetComponent<FoodData>().FoodType == item.GetComponent<FoodData>().FoodType)
                {
                    requiredItem.Remove(required); // remove matched item from required list

                    if(requiredItem.Count == 0)
                    {
                        OrderCorrect();
                        Debug.LogWarning("ALL ITEMS MATCHED");
                        return;
                    }

                    break; 
                }
            }

           
        }

         OrderIncorrect();

       
        //foreach (GameObject item in packedItems)
        //{

        //    foreach (GameObject required in requiredItem)
        //    {
        //        Debug.LogWarning("TEST TEST TEST TEST");

        //        if (required.GetComponent<FoodData>().FoodType == item.GetComponent<FoodData>().FoodType)
        //        {
        //            requiredItem.Remove(required); // remove matched item from required list
                   
        //            if (requiredItem.Count == 1)
        //            {
        //                OrderCorrect();
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            break; 
        //        }
        //        break; 
        //    }
        //}

        //OrderIncorrect();

    }


    private void OrderCorrect()
    {
        Debug.LogWarning("Order correct!");
        goodText.SetActive(true);
        StartCoroutine(RemoveBag());
    }

    private void OrderIncorrect()
    {
        Debug.LogWarning("Order Incorrect!");
        badText.SetActive(true);
        StartCoroutine(RemoveBag());
    }

 
    
   


    IEnumerator RemoveBag()
    {
        while (true)
        { 
            if (packedItems.Count > 0)
            {
                GameObject item = packedItems[0];
                packedItems.RemoveAt(0);
                Destroy(item);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                gameManager.SpawnBag();

                Destroy(this.gameObject);
                yield return null;
            }
        }
    }

}
