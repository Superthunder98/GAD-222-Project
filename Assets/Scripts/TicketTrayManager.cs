using System.Collections.Generic;
using UnityEngine;

public class TicketTrayManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ticketLocation = new List<GameObject>();

    public void PlaceTicket(GameObject ticket)
    {
        foreach (GameObject location in ticketLocation)
        {
            if (gameObject.gameObject.GetComponent<TicketSpot>().isOccupied == false)
            {
                ticket.transform.position = location.transform.position;
                gameObject.gameObject.GetComponent<TicketSpot>().isOccupied = true;
                break;
            }
        }

        if (ticketLocation.TrueForAll(loc => loc.GetComponent<TicketSpot>().isOccupied))
        {
            Debug.LogError("All ticket spots are occupied.");
            Destroy(ticket); // fail-safe to prevent game over from non completeable task.

        }
    }
    
}
