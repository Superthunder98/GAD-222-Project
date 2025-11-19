using System.Collections.Generic;
using UnityEngine;

public class TicketTrayManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ticketLocation = new List<GameObject>();
    [SerializeField] GameObject ticketPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaceTicket();
        }
    }

    public void PlaceTicket()
    {
        foreach (GameObject location in ticketLocation)
        {
            if (location.GetComponent<TicketSpot>().CheckPositionAvailability() == true)
            {

                Instantiate(ticketPrefab, location.transform);

                break;
            }
        }

        if (ticketLocation.TrueForAll(loc => loc.GetComponent<TicketSpot>().CheckPositionAvailability() == false))
        {
            Debug.LogWarning("All ticket spots are occupied.");
          

        }
    }
    
    public bool CheckAllTicketsAreGone()
    {
        if (ticketLocation.TrueForAll(loc => loc.GetComponent<TicketSpot>().CheckPositionAvailability() == true))
        {
            return true;
        }
        else
        { 
            return false;
        }
    }



}
