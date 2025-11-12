using UnityEngine;

public class TicketSpot : MonoBehaviour
{
    


    public bool CheckPositionAvailability()
    {
        if (transform.childCount == 0)
        {
            return true; // Spot is available
        }
        else
        {
            return false;// Spot is occupied
        }
    }

}

