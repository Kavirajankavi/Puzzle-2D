using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private Vector3 offset;
    private bool pointsAdded = false;
    private bool isDragging = false;
    private bool finish;

    public Transform rightPlace;  

    void Update()
    {
        if(finish == false) 
        {
            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
            }
        }
        

    }

    void OnMouseDown()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (Mathf.Abs(this.transform.localPosition.x - rightPlace.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - rightPlace.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = new Vector3(rightPlace.transform.localPosition.x, rightPlace.transform.localPosition.y, rightPlace.transform.localPosition.z);
            finish = true;
            if (!pointsAdded)
            {
                GameObject.Find("GameManager").GetComponent<Winning>().AddPoints();
                pointsAdded = true;
            }
        }
        else
        {
            if (pointsAdded)
            {
                GameObject.Find("GameManager").GetComponent<Winning>().RemovePoints();
                pointsAdded = false;
            }
        }
    }
}
