using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Transform gunBarrel;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gunBarrel.up = player.position - gunBarrel.position;

       if(player.position.x > enemy.position.x)
        {
            enemy.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            enemy.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
