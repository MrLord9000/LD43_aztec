using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop_v2 : MonoBehaviour {

    private ContactFilter2D filter;
    private Collider2D col;

    private void Start()
    {
        filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.NameToLayer("Building"));
        filter.useTriggers = true;
        filter.useLayerMask = true;
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (col.IsTouching(col, filter)) Debug.Log("Działa kurwa!");
        }
    }

}
