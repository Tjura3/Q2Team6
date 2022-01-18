using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    ShooterAI shooter;
    public Transform player;
    public Transform gunBarrel;
    public Transform enemy;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        sr = gameObject.GetComponentInParent<SpriteRenderer>();
        shooter = GetComponentInParent<ShooterAI>();
    }

    // Update is called once per frame
    void Update()
    {
        gunBarrel.up = player.position - gunBarrel.position;

        if (shooter.done == false)
        {
            if (player.position.x > enemy.position.x)
            {
                gameObject.transform.localPosition = new Vector2(1.86f, 0);
                sr.flipX = true;
            }
            else
            {
                gameObject.transform.localPosition = new Vector2(-1.86f, 0);
                sr.flipX = false;
            }
        }

     
    }
}
