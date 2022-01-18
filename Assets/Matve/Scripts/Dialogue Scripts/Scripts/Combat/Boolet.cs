using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
{
    float time = 2.5f;
    float timer;

    public float damage;
    healthSystem HS;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        HS = Player.GetComponent<healthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (HS.canDamage)
            {
                HS.healthPoints -= damage;
                HS.canDamage = false;
                
            }
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RunEnemy" || collision.gameObject.tag == "Enviro")
        {
            Destroy(gameObject);
        }
        
    }
}
