using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour
{
    CopiedPlayerMovement PM;

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
        PM = GetComponent<CopiedPlayerMovement>();
        canDamage = true;
        healthPoints = maxHealth;
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
          
        }
        else
        {
            
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

        }
    }
    
}