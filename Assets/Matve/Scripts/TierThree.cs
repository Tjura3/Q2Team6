using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierThree : MonoBehaviour
{
    public GameObject hitbox;

    public float damage;
    public float chargeTime;
    public float chargeTimer;

    public bool attacking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            hitbox.SetActive(true);
            attacking = false;
        }
        else
        {
            hitbox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (chargeTime >= chargeTimer)
            {
                chargeTimer++;
            }
            else
            {
                attacking = true;
                chargeTimer = 0;
            }
        }

    }
}
