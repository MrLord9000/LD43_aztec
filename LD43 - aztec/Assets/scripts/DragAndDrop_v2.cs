using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace tmp
{/*

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
        Debug.Log("collision");
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
            Debug.Log(currentPos.occupied);
            currentPos.occupied = true;
            Debug.Log(currentPos.occupied);
            transform.position = currentPos.transform.position;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!canDrag)
        {
            canDrag = true;
            currentPos.occupied = false;
        }
    }
}
    /*
    private void OnMouseDown()
    {
        if(!canDrag)
        {
            canDrag = true;
            currentPos.occupied = false;
        }
    }
}*/
 }


public class DragAndDrop_v2 : MonoBehaviour {

    //private bool canDrag = true;
    private bool assigned = false;
    private bool isLocked = false;
    private LockPointContainer currentPos;
    private LockPointContainer[] target;

    private void OnMouseEnter()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnMouseDrag()
    {
        //if(canDrag)
        {
            isLocked = false;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");

        target = collision.gameObject.GetComponentsInChildren<LockPointContainer>();
        //Debug.Log(target[0].transform.position);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(isLocked)
        {
            target = null;
            isLocked = true;
            currentPos.occupied = false;
        }
    }

    private void Update()
    {
        if(target != null)
        {
            //Debug.Log(target[0].transform.position);

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("mouse up");
                if (target != null)
                {
                    Debug.Log("var1");

                    foreach (LockPointContainer container in target)
                    {
                        Debug.Log("Loop");
                        if (!container.occupied)
                        {

                            container.occupied = true;
                            transform.position = container.transform.position;

                            gameObject.GetComponent<BoxCollider2D>().enabled = false;

                            currentPos = container;
                            isLocked = true;
                            assigned = true;

                            Debug.Log("container.transform.position: " + container.transform.position);
                            target = null;
                            return;
                        }
                    }

                    transform.position = transform.position + new Vector3(1, 1, 0);
                    target = null; // zakomentuj, a będzie fajny efekt xD
                }
                else
                {
                    Debug.Log("var2");
                }
            }

        }
    }

    /*
    private void OnMouseDown()
    {
        if(!canDrag)
        {
            canDrag = true;
            currentPos.occupied = false;
        }
    }*/
}



