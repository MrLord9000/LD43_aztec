using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    public float baseSpeed = 100f;
    private float speed;
    [Tooltip("Should be a half of max screen height in pixels.")]
    public int maxSize = 540;

    private void Awake()
    {
        speed = baseSpeed;
    }

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
            speed = baseSpeed;
            Camera.main.orthographicSize = 270;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            speed = baseSpeed * 2f;
            Camera.main.orthographicSize = 2 * 270;
        }

    }
}
