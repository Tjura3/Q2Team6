using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        GameObject Player = player.gameObject;
        if(player.gameObject.tag == "Player")
        {
            if (player.gameObject.transform.position.x >= gameObject.transform.position.x)
            {
                
            }
        }
    }
}
