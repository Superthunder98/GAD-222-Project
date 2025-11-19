using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBag : MonoBehaviour
{
    // THIS CODE IS SHIT I MADE THIS GAME IN 4HRS OKAY SO BACK OFF!!!!!
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform ticketSpot;

    [SerializeField] List<GameObject> packedItems = new List<GameObject>();

    [SerializeField] List<GameObject> requiredItem = new List<GameObject>();

    [SerializeField] GameObject ticket;

    [SerializeField] KeyCode valadateOrderShortcut;

    // TESTING
    // TEMP ONLY


    // TESTING
    private void Update()
    {
        if (Input.GetKeyDown(valadateOrderShortcut))
        {
            Debug.Log("Validating order...");
            Validate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("collision at" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("FoodItem"))
        {
            Debug.Log("Item packed: " + collision.gameObject.name);
            if (!packedItems.Contains(collision.gameObject))
            {
                packedItems.Add(collision.gameObject);
            }
        }

        if(collision.gameObject.CompareTag("Ticket"))
        {
            if( !ticket )
            {
               Debug.Log("Ticket:" + collision.gameObject.name);
            

                 ticket = collision.gameObject;
            
                 collision.gameObject.GetComponent<DragItem>().isDragging = false;
                  collision.gameObject.GetComponent<DragItem>().isTicketInPlace = true;

                  collision.gameObject.transform.position = ticketSpot.position;

                 foreach (GameObject item in collision.gameObject.GetComponent<OrderTickets>().currentOrder)
                 {
                requiredItem.Add(item);
                Debug.Log("Required item added: " + item.name);
                 }
            }
            else
            {
                
               

                Debug.Log("A ticket is already in place. Cannot add another ticket.");
                 

                ticket.gameObject.GetComponent<DragItem>().ResetPosition();
                collision.gameObject.GetComponent<DragItem>().ResetPosition();


                

            }



        }


    }


    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("FoodItem"))
        {
            Debug.Log("Item removed: " + collision.gameObject.name);
            packedItems.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ticket"))
        {
            Debug.Log("Ticket removed: " + collision.gameObject.name);
            
            collision.gameObject.GetComponent<DragItem>().isTicketInPlace = false;
            ticket = null;
            requiredItem.Clear();
        }
    }

    public void Validate()
    {

        if (!ticket)
        {
            Debug.Log("NO TICKET PRESENT");
           
            return;
        }

        if (packedItems.Count < requiredItem.Count)
        {
            Debug.Log("ITEM COUNT MISMATCH");
            OrderIncorrect();
            return;
        }

        foreach (GameObject item in packedItems)
        {
            foreach(GameObject required in requiredItem)
            {
                //Debug.LogWarning("TEST TEST TEST TEST");
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
        gameManager.OrderCorrect();
        RemoveBag();
    }

    private void OrderIncorrect()
    {
        gameManager.OrderIncorrect();
        RemoveBag();
    }

    void RemoveBag()
    {
        Destroy(ticket.gameObject);
        requiredItem.Clear();
        ticket = null;
       

        foreach (GameObject item in packedItems)
        {

           
            Destroy(item.gameObject, 0.2f);

        } 
          
        packedItems.Clear();

    }

}
