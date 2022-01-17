using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;

    public float startTimeBetweenSpawns;
    private float timeBetweenSpawns;

    public static int spinnerNumber;

    // Start is called before the first frame update
    private void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeBetweenSpawns <= 0 && spinnerNumber >= 0)
        {
            rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, spawnPoint.Length);

            Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;

            spinnerNumber -= 1;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}