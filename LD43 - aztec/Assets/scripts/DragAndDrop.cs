using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private GameObject building = null;
    private Unit unit;
    private Transform old;

    private void Start()
    {
        //Debug.Log("DUPA");
        //unit = GetComponent<Unit>();
        //Debug.Log(unit.gameObject.transform.position);
    }
    private void Update()
    {

    }
    // private bool isColliding;
    private void OnMouseDown()
    {
        //Debug.Log(unit.transform.position);
        //old.SetPositionAndRotation(unit.transform.position, unit.transform.rotation);
    }


    private void OnMouseDrag()
    {        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        building = collision.gameObject;
        print("111");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        building = null;
    }

    private void OnMouseUp()
    {
        //unit.transform.position = old.position;

        //return;


        if (building.GetComponent<Building>() == null)
        {
            //unit.transform.position = old.position;
            return;
        }

        if ( building != null && building.GetComponent<Building>().assigned < building.GetComponent<Building>().capacity )
        {
            if(unit.house!=null)
            {
                unit.house.GetComponent<Building>().slots[unit.slotInHouse] = false;
                unit.house.GetComponent<Building>().assigned--;
            }
            unit.house = building;
            unit.house.GetComponent<Building>().assigned++;

            print("sss");

            int slot = (int)Random.Range(0, 5);
            if (unit.house.GetComponent<Building>().slots[slot] == true ) slot++;
            if (slot == 5) slot = 0;
            unit.house.GetComponent<Building>().slots[slot] = true;
            unit.slotInHouse = slot;

            unit.house.GetComponent<Building>().SetInSlot(this.gameObject);
        }
        //else unit.transform.position = old.position;
    }
    
}
