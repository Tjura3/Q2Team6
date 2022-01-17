using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public static int shooterEnemies = 0;

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
        if (timeBetweenSpawns <= 0 && shooterEnemies <= 4)
        {
            rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, spawnPoint.Length);

            Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;

            shooterEnemies += 1;
            Spawner.totalEnemies += 1;
            Debug.Log("Shooters:" + shooterEnemies);
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
