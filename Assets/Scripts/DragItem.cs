using Unity.VisualScripting;
using UnityEngine;

public class DragItem : MonoBehaviour
{

    public bool isDragging = false;
    public bool isTicketInPlace = false;
    private float distance;
    

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
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (!isTicketInPlace)
        {
            this.transform.localPosition = new Vector3(0, 0, 0);
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

}
