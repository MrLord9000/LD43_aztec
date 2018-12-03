using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop_v2 : MonoBehaviour {

    private bool canDrag = true;
    private LockPointContainer currentPos;
    private LockPointContainer[] pos;

    private void OnMouseDrag()
    {
        if(canDrag)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {   
        if (Input.GetMouseButtonUp(0))
        {
            canDrag = false;
            pos = collision.gameObject.GetComponentsInChildren<LockPointContainer>();

            foreach (var element in pos)
            {
                if (!element.occupied)
                {
                    currentPos = element;
                }
                Debug.Log(element.transform.position);
            }
            currentPos.occupied = true;
            transform.position = currentPos.transform.position;
        }
    }

    private void OnMouseDown()
    {
        if(!canDrag)
        {
            canDrag = true;
            currentPos.occupied = false;
        }
    }
}
