using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour
{
    CopiedPlayerMovement CPM;
    PlayerMovement PM;

    Rigidbody2D RB2;

    public Text hpText;

    public float healthPoints;
    public float maxHealth = 100.0f;

    public bool invFrame;
    public float invTime;
    public float invTimer;

    public bool debug;
    public bool isDead;
    public bool canDamage;
    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMovement>();
        canDamage = true;
        healthPoints = maxHealth;
        RB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = healthPoints + "/" + maxHealth;
        if (!canDamage)
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
        }
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
            isDead = true;
            healthPoints = 0.0f;
            

        }
        else if (healthPoints >= maxHealth)
        {
            healthPoints = maxHealth;
            canDamage = true;
        }

        if(healthPoints > 0)
        {
            isDead = false;
        }
        if (isDead)
        {
            PM.enabled = false;
            canDamage = false;
            invFrame = false;
            RB2.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            
        }
    }



    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {

    //        if (canDamage)
    //        {
    //            healthPoints -= collision.gameObject.GetComponent<DoDamage>().damage;
    //            canDamage = false;
    //        }

    //    }
    //}
    
}