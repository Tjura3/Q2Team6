using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRoaming : MonoBehaviour
{
    public float speed;

    public float range;

    public float maxDistance;

    Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        findDestination();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, destination) < range)
        {
            //findDestination();
            StartCoroutine(pauseRoaming());
        }
    }

    void findDestination()
    {
        destination = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

    IEnumerator pauseRoaming()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));

        findDestination();

        yield return new WaitForFixedUpdate();

    }
}
