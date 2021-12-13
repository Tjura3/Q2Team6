using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackTwo : MonoBehaviour
{
    public float kbForce;
    public float damage;

    GameObject player;
    //PlayerMovement PM;
    CopiedPlayerMovement CPM;
    healthSystem HS;
    Rigidbody2D RB2;
    Collider2D col;

    public float stunned;
    public float timer;

    public float colTimer;
    public float colTime;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        //PM = player.GetComponent<PlayerMovement>();
        CPM = player.GetComponent<CopiedPlayerMovement>();
        HS = player.GetComponent<healthSystem>();
        RB2 = player.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
    }

    private void Start()
    {
        col.enabled = false;
    }

    private void Update()
    {
        if (CPM.enabled == false)
        {
            if (stunned >= timer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                CPM.enabled = true;
                RB2.velocity = new Vector2(0, 0);
            }
        }

        if(col.enabled)
        {
            if(colTimer <= colTime)
            {
                colTimer += Time.deltaTime;
            }
            else
            {
                col.enabled = false;
                colTimer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HS.healthPoints -= damage/2;
            if(player.transform.position.x <= gameObject.transform.position.x)
            {
                CPM.enabled = false;
                RB2.AddForce(transform.right * -kbForce);
            }

            if (player.transform.position.x >= gameObject.transform.position.x)
            {
                CPM.enabled = false;
                RB2.AddForce(transform.right * kbForce);
            }

            if (player.transform.position.y < gameObject.transform.position.y)
            {
                CPM.enabled = false;
                RB2.AddForce(transform.up * -kbForce);
            }

            if (player.transform.position.y > gameObject.transform.position.y)
            {
                CPM.enabled = false;
                RB2.AddForce(transform.up * kbForce);
            }
        }
    }

   
}
