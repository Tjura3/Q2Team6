using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntranceScript : MonoBehaviour
{
    [SerializeField] Collider2D doorBarrier;
    [SerializeField] GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorBarrier.enabled = true;
        GetComponent<Collider2D>().enabled = false;
        camera.GetComponent<Animator>().enabled = true;
        camera.GetComponent<Animator>().SetTrigger("GoToMiddle");
        camera.GetComponent<CameraFollow>().enabled = false;
    }


}
