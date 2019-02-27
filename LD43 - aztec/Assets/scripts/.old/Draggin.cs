using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

// Drag & Drop Script

public class Draggin : MonoBehaviour {

    public const string DRAGGABLE_TAG = "UIDraggable";
    public const string DROPPABLE_TAG = "UIDroppable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Vector2 distance; // distance between the object and mouse pointer

    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();

	void Start () {
	}
	

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;

                distance = (Vector2)objectToDrag.position - (Vector2)Input.mousePosition;
            }
        }

        if (dragging)
        {
            objectToDrag.position = (Vector2)Input.mousePosition + distance;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (objectToDrag != null)
            {
                Transform objectToDrop = GetDroppableTransformUnderMouse();
            
                if(objectToDrop != null)
                {
                    /*
                     *
                     *
                     *
                     *
                     *
                     *
                     *
                     *
                     */
                }
                else
                {
                    objectToDrag.position = originalPosition;
                }

                objectToDragImage.raycastTarget = true;
                objectToDrag = null;

                dragging = false;
            }
        }


	}

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);


        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0)
            return null;

        return hitObjects.First().gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject currentObject = GetObjectUnderMouse();

        if (currentObject != null && currentObject.tag == DRAGGABLE_TAG)
            return currentObject.transform;

        return null;
    }

    private Transform GetDroppableTransformUnderMouse()
    {
        GameObject currentObject = GetObjectUnderMouse();

        if (currentObject != null && currentObject.tag == DROPPABLE_TAG)
            return currentObject.transform;

        return null;
    }
}