using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public EnemyAI enemyai;


    // Start is called before the first frame update
    void Start()
    {
        enemyai = GameObject.FindGameObjectWithTag("EnemyAI").GetComponent<EnemyAI>();
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (CompareTag("Player"){
           
        }*/
    }
}
