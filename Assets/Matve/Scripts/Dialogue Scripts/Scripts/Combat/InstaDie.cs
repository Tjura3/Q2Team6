using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDie : MonoBehaviour
{
    healthSystem HS;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        HS = player.GetComponent<healthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HS.healthPoints = 0;
        }
    }
}
