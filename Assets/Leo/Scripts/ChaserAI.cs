﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaserAI : MonoBehaviour
{

    public Transform target;


    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public bool done = false;
    bool wait = false;

    //public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("Player").transform;

        seeker = GetComponent<Seeker>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);

    }


    void UpdatePath()
    {
        if (seeker.IsDone() && done == false)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Vector2.Distance(rb.position, target.position) < 10)
        {
            done = false;
            GetComponent<enemyRoaming>().enabled = false;
        }
        else if (Vector2.Distance(rb.position, target.position) > 10)
        {
            done = true;
            if (wait == false)
            {
                StartCoroutine(WaitToRoam());
            }
            return;
        }



        if (Vector2.Distance(rb.position, target.position) > 20)
        {
            rb.velocity = Vector2.zero;

        }


        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (direction.x >= 0.01f)
        {
            //Debug.Log("Flip x 1");
            //enemyGFX.localScale = new Vector3(-Mathf.Abs(enemyGFX.localScale.x), enemyGFX.localScale.y, enemyGFX.localScale.z);
            sr.flipX = true;
        }
        else if (direction.x <= -0.01f)
        {
            //Debug.Log("Flip x 2");
            //enemyGFX.localScale = new Vector3(-Mathf.Abs(enemyGFX.localScale.x), enemyGFX.localScale.y, enemyGFX.localScale.z);
            sr.flipX = false;
        }

    }

    IEnumerator WaitToRoam()
    {
        wait = true;
        //Debug.Log("stuff");
        yield return new WaitForSeconds(2);
        GetComponent<enemyRoaming>().enabled = true;
        wait = false;
        yield return new WaitForFixedUpdate();
    }
}