using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderTickets : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI orderTimerText;
    [SerializeField] GameManager gameManager;

    [SerializeField] int orderTimerSec = 31;
    [SerializeField] int orderTimerMin = 2;

    [SerializeField] bool timerAlarm = false; // flag value
    [SerializeField] bool ticketTimedOut = false; // flag value

    public List<GameObject> currentOrder = new List<GameObject>();

    [SerializeField] Animation alarmFlash;


    void Awake()
   {
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
        InvokeRepeating("UpdateTimer", 1f, 1f);
   }

    private void UpdateTimer()
    {
            
            if (ticketTimedOut)
            {
                return;
            }

            orderTimerSec --;

            if (orderTimerSec <= 0)
            {
                orderTimerMin --;
                orderTimerSec = 59;
            }

            if (orderTimerMin == 0)
            {
                orderTimerText.color = Color.red;
            }

            if (orderTimerMin < 0)
            {
                ticketTimedOut = true;
                CancelInvoke("UpdateTimer");
                Debug.LogWarning("TICKET TIMED OUT");
                gameManager.incorrectOrders++;
                orderTimerText.text = "00:00";
                return;
            }

            orderTimerText.text = orderTimerMin.ToString("00") + ":" + orderTimerSec.ToString("00");

            if (timerAlarm)
            {
                return;
            }

            if (orderTimerMin == 0 && orderTimerSec <= 30)
            {
                timerAlarm = true;

                alarmFlash.Play();

                Debug.LogWarning("TIMER ALARM TRIGGERED");
            }

            
        
        
    }
    

    

}
