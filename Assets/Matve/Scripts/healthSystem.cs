using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSystem : MonoBehaviour
{
    public float healthPoints;
    public float maxHealth = 100.0f;

    public bool invFrame;
    public float invTime;
    public float invTimer;

    public bool debug;

    public bool canDamage;
    // Start is called before the first frame update
    void Start()
    {
        canDamage = true;
        healthPoints = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                healthPoints = maxHealth;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                healthPoints = 0;
            }
        }

        if (healthPoints <= 0)
        {
            healthPoints = 0.0f;
            canDamage = false;
        }
        else if (healthPoints >= maxHealth)
        {
            healthPoints = maxHealth;
            canDamage = true;
        }


    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            if (canDamage)
            {
                healthPoints -= collision.gameObject.GetComponent<DoDamage>().damage;
                canDamage = false;
            }
            else
            {
                if (invFrame)
                {
                    if (invTimer < invTime)
                    {
                        invTimer += Time.deltaTime;
                    }
                    else if (invTimer > invTime)
                    {
                        invTimer = 0;
                        canDamage = true;
                    }
                }
                else
                {
                    canDamage = true;
                }

            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            invTimer = 0;
        }
    }
}