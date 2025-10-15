using UnityEngine;
using UnityEngine.InputSystem;

public class TestMouseRay : MonoBehaviour
{

    [SerializeField] Camera mainCam;

    Vector2 mousePosition;


    private void Start()
    {
        mainCam = Camera.main;

        
    }
   
    private void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawRay(mousePosition, transform.forward * 100);

        var rayHit = Physics2D.Raycast(mousePosition, transform.forward, 100f);

        if (rayHit.collider == null)
        {
            Debug.LogWarning("NO HIT");
        }
        else
        {
            Debug.LogWarning(rayHit.collider.name);
        }
    }





}
