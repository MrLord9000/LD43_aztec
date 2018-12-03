using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop_v2 : MonoBehaviour {

    private bool isAssigned = false;
    private LockPointContainer currentPos;
    private LockPointContainer[] target;

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = collision.gameObject.GetComponentsInChildren<LockPointContainer>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        target = null;
        if (isAssigned)
        {
            currentPos.occupied = false;
            isAssigned = false;
            Debug.Log("Occupied: " + currentPos.occupied);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(target != null && !isAssigned)
            {
                foreach (LockPointContainer container in target)
                {
                    if (!container.occupied)
                    {
                        container.occupied = true;
                        transform.position = container.transform.position;

                        currentPos = container;
                        isAssigned = true;
                        Debug.Log("Occupied: " + currentPos.occupied);
                        target = null;
                        return;
                    }
                }
                transform.position = transform.position + new Vector3(1, 1, 0);
                target = null; // zakomentuj, a będzie fajny efekt 

            }
            else if(isAssigned)
            {
                transform.position = currentPos.transform.position;
            }
        }
    }
}



