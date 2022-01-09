using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ScaredAI : MonoBehaviour
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

    bool playerIsTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        FindHouse();

        //Debug.Log("Do a thing");

        seeker = GetComponent<Seeker>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);

    }



    void UpdatePath()
    {
        if (seeker.IsDone() && done == false && target != null)
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
        UpdateEnemyPath();
    }

    void UpdateEnemyPath()
    {

        if (target == null)

        {
            FindHouse();
            return;
        }

        if (Vector2.Distance(rb.position, GameObject.Find("Player").transform.position) < 10)
        {
            done = false;
            GetComponent<NewRoaming>().isOff = true;


            /*if ((Vector2.Distance(rb.position, target.position) > 20) && playerIsTarget == true)
            {
                rb.velocity = Vector2.zero;
            }*/
        }
        else if (Vector2.Distance(rb.position, GameObject.Find("Player").transform.position) > 10)
        {
            done = true;
            if (wait == false)
            {
                StartCoroutine(WaitToRoam());
            }

        }




        if (path == null)
        {
            return;
        }

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
        //print("force: " + force);
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            //Debug.Log("Flip x 1");
            //enemyGFX.localScale = new Vector3(-Mathf.Abs(enemyGFX.localScale.x), enemyGFX.localScale.y, enemyGFX.localScale.z);
            sr.flipX = true;
        }
        else if (rb.velocity.x <= -0.01f)
        {
            //Debug.Log("Flip x 2");
            //enemyGFX.localScale = new Vector3(-Mathf.Abs(enemyGFX.localScale.x), enemyGFX.localScale.y, enemyGFX.localScale.z);
            sr.flipX = false;
        }
    }

    public void FindHouse()
    {
        GameObject[] houses = GameObject.FindGameObjectsWithTag("House");
        if (houses.Length != 0)
        {
            //Debug.Log(houses.Length);
            GameObject closestHouse = houses[0];
            for (int i = 0; i < houses.Length; i++)
            {
                if (Vector2.Distance(closestHouse.transform.position, transform.position) > Vector2.Distance(houses[i].transform.position, transform.position))
                {
                    closestHouse = houses[i];
                }
            }
            target = closestHouse.transform;
        } else
        {
            //Debug.Log("no house");
            target = GameObject.Find("Player").transform;
            speed = -Mathf.Abs(speed);
            playerIsTarget = true;
        }
    } 

    IEnumerator WaitToRoam()
    {
        wait = true;
        yield return new WaitForSeconds(2);
        GetComponent<NewRoaming>().isOff = false;
        wait = false;
        yield return new WaitForFixedUpdate();
    }
}
