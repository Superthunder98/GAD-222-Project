using UnityEngine;

public class TicketSpot : MonoBehaviour
{
    public bool isOccupied = false;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ticket"))
        {
            isOccupied = false;
        }
    }

}

