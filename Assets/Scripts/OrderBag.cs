using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBag : MonoBehaviour
{
    [SerializeField] GameManager gameManager;


    [SerializeField] List<GameObject> packedItems = new List<GameObject>();

    [SerializeField] List<GameObject> requiredItem = new List<GameObject>();

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
        if(packedItems.Count == 0)
        {
            Debug.Log("BAG EMPTY");
            OrderIncorrect();
            return;
        }

        foreach (GameObject item in packedItems)
        {
            if (item == null) // check if there are no more items to check against
            {
                Debug.LogWarning("OUT OF ITEM");
                OrderIncorrect();
                return;
            }

            foreach (GameObject required in requiredItem)
            {
                if (required.GetComponent<FoodData>().FoodType == item.GetComponent<FoodData>().FoodType)
                {
                    requiredItem.Remove(required); // remove matched item from required list
                    break; // exit inner loopon
                }

                if(requiredItem.Count == 0)
                {
                    OrderCorrect();
                    
                    return;
                }


            }


        }
    }


    private void OrderCorrect()
    {
        Debug.Log("Order correct!");
        StartCoroutine(RemoveBag());
    }

    private void OrderIncorrect()
    {
        Debug.Log("Order Incorrect!");
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
