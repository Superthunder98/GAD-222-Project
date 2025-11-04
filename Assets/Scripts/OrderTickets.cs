using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderTickets : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI orderTimerText;

    [SerializeField] int orderTimerSec = 60;
    [SerializeField] int orderTimerMin = 2;

    public List<GameObject> currentOrder = new List<GameObject>();

    


   void Awake()
   {
        InvokeRepeating("UpdateTimer", 1f, 1f);
   }

    private void UpdateTimer()
    {
        orderTimerSec -= 1;

        if(orderTimerSec <= 0)
        {
            orderTimerMin -= 1;
            orderTimerSec = 59;
        }

        if(orderTimerMin == 0)
        {
            orderTimerText.color = Color.red;
        }
        orderTimerText.text = orderTimerMin.ToString("00") + ":" + orderTimerSec.ToString("00");

    }



}
