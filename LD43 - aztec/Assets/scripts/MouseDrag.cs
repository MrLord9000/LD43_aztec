using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    float speed = 15f;
    public float boundsX, boundsY;

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            //if(transform.position.x < boundsX && transform.position.x > -boundsX && transform.position.y < boundsY && transform.position.y > -boundsY)
            transform.position -= new Vector3(  Input.GetAxis("Mouse X") * speed * Time.deltaTime,
                                                Input.GetAxis("Mouse Y") * speed * Time.deltaTime);

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Camera.main.orthographicSize = 4;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Camera.main.orthographicSize = 8;
        }

    }
}
