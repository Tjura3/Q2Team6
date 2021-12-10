using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackTwo : MonoBehaviour
{
    public float kbForce;
    public float damage;

    GameObject player;
    PlayerMovement PM;
    healthSystem HS;
    Rigidbody2D RB2;

    public float stunned;
    public float timer;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        PM = player.GetComponent<PlayerMovement>();
        HS = player.GetComponent<healthSystem>();
        RB2 = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PM.enabled == false)
        {
            if (stunned >= timer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                PM.enabled = true;
                RB2.velocity = new Vector2(0, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HS.healthPoints -= damage;
            if(player.transform.position.x <= gameObject.transform.position.x)
            {
                PM.enabled = false;
                RB2.AddForce(transform.right * -kbForce);
            }

            if (player.transform.position.x >= gameObject.transform.position.x)
            {
                PM.enabled = false;
                RB2.AddForce(transform.right * kbForce);
            }

            if (player.transform.position.y < gameObject.transform.position.y)
            {
                PM.enabled = false;
                RB2.AddForce(transform.up * -kbForce);
            }

            if (player.transform.position.y > gameObject.transform.position.y)
            {
                PM.enabled = false;
                RB2.AddForce(transform.up * kbForce);
            }
        }
    }

   
}
