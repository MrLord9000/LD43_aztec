using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    float speed = 15f;

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            transform.position -= new Vector3(  Input.GetAxis("Mouse X") * speed * Time.deltaTime,
                                                Input.GetAxis("Mouse Y") * speed * Time.deltaTime);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Camera.main.orthographicSize = 4;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Camera.main.orthographicSize = 8;
        }

    }
}
