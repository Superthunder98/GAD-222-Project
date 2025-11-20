using Unity.VisualScripting;
using UnityEngine;

public class EndTextPrinter : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] TMPro.TextMeshProUGUI scoreText; 


    private void Awake()
    {
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();


        scoreText.text = "Total Correct Orders: " + gameManager.correctOrders.ToString() + ", Total Mistakes Orders: " + gameManager.incorrectOrders.ToString();

       gameManager.DestroyManager();
        
        
    }




}
