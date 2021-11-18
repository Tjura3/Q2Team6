using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Camera camera;
    public float cameraSize;
    [SerializeField] float cameraGrowthSpeed;
    float lerpProgress;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        if (camera.orthographicSize < cameraSize)
        {
            camera.orthographicSize = Mathf.Lerp(cameraSize, camera.orthographicSize, cameraGrowthSpeed);
        }
        
        if(camera.orthographicSize > cameraSize)
        {
            camera.orthographicSize = cameraSize;
        }

    }
}
