using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRoaming : MonoBehaviour
{
    public float speed;

    public float range;

    public float maxDistance;

    SpriteRenderer sr;
    Vector2 destination;

    bool wait;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        findDestination();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, destination) < range && !wait)
        {
            //findDestination();
            StartCoroutine(PauseRoaming());
        }

        if (destination.x > transform.position.x)
        {
            //Debug.Log("Flip x 1 2");
            //enemyGFX.localScale = new Vector3(-Mathf.Abs(enemyGFX.localScale.x), enemyGFX.localScale.y, enemyGFX.localScale.z);
            sr.flipX = true;
        }
        else if (destination.x < transform.position.x)
        {
            //Debug.Log("Flip x 2 2");
            //enemyGFX.localScale = new Vector3(-Mathf.Abs(enemyGFX.localScale.x), enemyGFX.localScale.y, enemyGFX.localScale.z);
            sr.flipX = false;
        }
    }

    void findDestination()
    {
        //current = new Vector2(transform.position);
        destination = new Vector2(( - Random.Range(-maxDistance, maxDistance)), Random.Range(-maxDistance, maxDistance)) + new Vector2(transform.position.x, transform.position.y);
    }

    IEnumerator PauseRoaming()
    {
        wait = true;
        yield return new WaitForSeconds(Random.Range(1, 3));

        findDestination();
        wait = false;

        yield return new WaitForFixedUpdate();

    }
}
