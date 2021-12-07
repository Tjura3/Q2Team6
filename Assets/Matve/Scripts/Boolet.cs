using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
{
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
        }
        Destroy(gameObject);
    }
}
