using Unity.VisualScripting;
using UnityEngine;

public class DragItem : MonoBehaviour
{

    public bool isDragging = false;
    public bool isTicketInPlace = false;
    private float distance;

    [SerializeField] bool isTicket = false; // To differentiate between tickets and food


    //private void OnMouseEnter()
    //{
    //   Debug.LogWarning("Mouse Entered");
    //}

    //private void OnMouseExit()
    //{
    //    Debug.LogWarning("Mouse Exited");
    //}

    void OnMouseDown()
    {
        if (isTicketInPlace)
        {
            ResetPosition();
            
        }
        else
        { 
             distance = Vector3.Distance(transform.position, Camera.main.transform.position);
             isDragging = true;
        }   
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (!isTicketInPlace && isTicket)
        {
            ResetPosition();
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }

    public void ResetPosition()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
    }
}
