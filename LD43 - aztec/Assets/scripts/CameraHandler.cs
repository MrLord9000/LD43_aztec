using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

    public float baseSpeed = 100f;
    private float speed;
    // Max size is determined in Awake(), and it tells us the half of screen height.
    // This is especially useful in grid spawining so keep it in mind
    private static float maxSize;
    private Camera mainCamera;

    public static float GetMaxCameraSize()
    {
        return maxSize;
    }

    private void Awake()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        speed = baseSpeed;
        maxSize = Screen.height / 2f;
        Debug.Log("MaxSize: " + maxSize);
        mainCamera.orthographicSize = maxSize;
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
            mainCamera.orthographicSize = maxSize / 2f;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            speed = baseSpeed * 2f;
            mainCamera.orthographicSize = maxSize;
        }

    }
}
