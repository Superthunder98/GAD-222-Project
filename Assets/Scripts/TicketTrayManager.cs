using System.Collections.Generic;
using UnityEngine;

public class TicketTrayManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ticketLocation = new List<GameObject>();
    [SerializeField] GameObject ticketPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlaceTicket();
        }
    }

    public void PlaceTicket()
    {
        foreach (GameObject location in ticketLocation)
        {
            if (location.GetComponent<TicketSpot>().isOccupied == false)
            {

                location.GetComponent<TicketSpot>().isOccupied = true;

                Instantiate(ticketPrefab, location.transform);

                
                break;
            }
        }

        if (ticketLocation.TrueForAll(loc => loc.GetComponent<TicketSpot>().isOccupied))
        {
            Debug.LogError("All ticket spots are occupied.");
          

        }
    }
    
}
