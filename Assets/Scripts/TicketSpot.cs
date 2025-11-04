using UnityEngine;

public class TicketSpot : MonoBehaviour
{
    public int isOccupied = 0;



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ticket"))
        {
            isOccupied -= 1;
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ticket"))
        {
            isOccupied += 1;
        }
       
    }

}

