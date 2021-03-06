using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Camera camera;
    public float cameraSize;
    [SerializeField] float cameraGrowthSpeed;
    public float lerpProgress;

    [SerializeField] bool lockX;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lockX)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        }
        if (camera.orthographicSize < cameraSize)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraSize, cameraGrowthSpeed);
        }
        
        if(camera.orthographicSize > cameraSize)
        {
            camera.orthographicSize = cameraSize;
        }

    }
}
