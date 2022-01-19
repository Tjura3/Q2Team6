using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntranceScript : MonoBehaviour
{
    [SerializeField] Collider2D doorBarrier;
    [SerializeField] GameObject camera;
    [SerializeField] King king;
    [SerializeField] BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorBarrier.enabled = true;
            GetComponent<Collider2D>().enabled = false;
            camera.GetComponent<Animator>().enabled = true;
            camera.GetComponent<Animator>().SetTrigger("GoToMiddle");
            camera.GetComponent<CameraFollow>().enabled = false;
            playerCollider.enabled = false;
            king.StartFight();
        }
    }


}
