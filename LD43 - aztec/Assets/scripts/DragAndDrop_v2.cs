using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop_v2 : MonoBehaviour {

    [SerializeField]
    private bool isAssigned = false;
    private Unit thisUnit;
    private LockPointContainer currentPos;
    private LockPointContainer[] target;

    private void Start()
    {
        thisUnit = GetComponent<Unit>();
    }

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
        if (isAssigned)//RELESING WOKER
        {            
            currentPos.occupied = false;
            currentPos.worker = null;
            thisUnit.workplace = null;

            isAssigned = false;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(target != null && !isAssigned)
            {
                if (target[0].isTemple)
                {
                    target[0].GetComponentInParent<TEMPORARY_Sacrefice>().Sacrefice(thisUnit);
                    return;
                }
                if (target[0].isShrine)
                {
                    target[0].GetComponentInParent<TEMPORARY_Sacrefice>().EvilSacrefice(thisUnit);
                    return;
                }

                foreach (LockPointContainer container in target)
                {
                    if (!container.occupied)//ASSIGING WORKER
                    {
                        container.worker = gameObject;
                        container.occupied = true;

                        transform.position = container.transform.position;
                        
                        currentPos = container;
                        thisUnit.workplace = currentPos.gameObject;

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



