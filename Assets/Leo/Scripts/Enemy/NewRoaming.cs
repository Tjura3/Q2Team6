using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NewRoaming : MonoBehaviour
{

    public Vector2 target;

    public float maxDistance;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public bool done = false;
    bool wait = false;
    public float range;
    bool wait2;

    //public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    SpriteRenderer sr;

    bool switchTarget;

    public bool isOff;

    // Start is called before the first frame update
    void Start()
    {

        findDestination();

        seeker = GetComponent<Seeker>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        InvokeRepeating("SwitchTarget", 0f, 3f);

    }

    void SwitchTarget()
    {
        if (isOff)
        {
            return;
        }

        switchTarget = true;
        findDestination();

    }

    void UpdatePath()
    {
        if (isOff)
        {
            return;
        }

        if (seeker.IsDone() || switchTarget)
        {
            switchTarget = false;
            seeker.StartPath(rb.position, target, OnPathComplete);
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
        /*if(target == null)
        {
            findDestination();
            return;
        }
        if (Vector2.Distance(transform.position, target) < range && !wait2)
        {
            //findDestination();
            StartCoroutine(PauseRoaming());
            return;
        }*/




        if (path == null || isOff)
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

        if (rb.velocity.x >= 0.01f)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x <= -0.01f)
        {
            sr.flipX = false;
        }

    }

    void findDestination()
    {
        //Debug.Log("Find destination");
        target = new Vector2((-Random.Range(-maxDistance, maxDistance)), Random.Range(-maxDistance, maxDistance)) + new Vector2(transform.position.x, transform.position.y);

    }


    IEnumerator PauseRoaming()
    {
        wait2 = true;
        yield return new WaitForSeconds(Random.Range(1, 3));

        findDestination();
        wait2 = false;

        yield return new WaitForFixedUpdate();

    }
}
