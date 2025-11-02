using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderTickets : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI orderTimerText;

    [SerializeField] int orderTimerSec = 0;
    [SerializeField] int orderTimerMin = 0;

    public List<GameObject> currentOrder = new List<GameObject>();

    


   void Awake()
   {
        InvokeRepeating("UpdateTimer", 1f, 1f);
   }

    private void UpdateTimer()
    {
        orderTimerSec += 1;

        if(orderTimerSec >= 60)
        {
            orderTimerMin += 1;
            orderTimerSec = 0;
        }

        orderTimerText.text = orderTimerMin.ToString("00") + ":" + orderTimerSec.ToString("00");

    }



}
