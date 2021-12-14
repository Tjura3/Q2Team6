﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerEnemy : MonoBehaviour
{
    public float time;
    public float timer;

    public bool attacking;
    public bool inRange;

    public GameObject hitbox;
    public Collider2D hitboxCol;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = gameObject.transform.Find("Hitbox").gameObject;
        hitboxCol = hitbox.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            attacking = true;
        }

        if (attacking)
        {
            if (timer <= time)
            {
                timer += Time.deltaTime;

            }
            else
            {
                hitboxCol.enabled = true;
                timer = 0;
                attacking = false;
            }
        }
        else
        {
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}