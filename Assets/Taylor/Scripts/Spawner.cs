using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public static int enemyNumber = 0;

    public float startTimeBetweenSpawns;
    private float timeBetweenSpawns;
    // Start is called before the first frame update
    
    private void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeBetweenSpawns <= 0 && enemyNumber <= 29)
        {
            rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, spawnPoint.Length); 

            Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;

            enemyNumber += 1;
            Debug.Log("Enemies:" + enemyNumber);
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
