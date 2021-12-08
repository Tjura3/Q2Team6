using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    GameObject Player;
    healthSystem HS;
    public GameObject projectile;
    public Transform rotate; //Projectile spawn point

    public bool canShoot;
    public bool inRange;

    public float speed;
    public float timer;
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        HS = Player.GetComponent<healthSystem>();

        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (HS.isDead)
        {
            inRange = false;
        }
        if (inRange)
        {
            if (canShoot)
            {
                Shoot();

                canShoot = false;
            }
            else
            {
                if(timer <= delayTime)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    canShoot = true;
                    timer = 0;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectile, rotate.position, rotate.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(rotate.up * speed, ForceMode2D.Impulse);
    }
}
