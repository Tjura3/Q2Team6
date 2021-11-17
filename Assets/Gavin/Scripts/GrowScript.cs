using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScript : MonoBehaviour
{
    [SerializeField] float growSpeed;
    [SerializeField] float lerpGrowSpeed;
    [SerializeField] float startSize;
    float currentSize;

    [SerializeField] CameraFollow cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        currentSize = startSize;
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow.cameraSize = currentSize * 2 + 5;

        //Debug.Log("cameraSize: " + cameraFollow.cameraSize);
        //Debug.Log("CurrentSize: " + currentSize);
        //Debug.Log("Lerp Val: " + Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, transform.localScale.y, 1), lerpGrowSpeed));
        if (transform.localScale.x < currentSize)
        {
            transform.localScale += Vector3.Lerp(transform.localScale, new Vector3(currentSize, currentSize, currentSize), lerpGrowSpeed);
        }

        if (transform.localScale.x > currentSize)
        {
            transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            
        }
    }


    /*
     * JUST FOR TESTING PURPOSES
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TestFood")
        {
            Destroy(collision.gameObject);
            currentSize += growSpeed;
            Debug.Log("Munch");
        }
    }
}
