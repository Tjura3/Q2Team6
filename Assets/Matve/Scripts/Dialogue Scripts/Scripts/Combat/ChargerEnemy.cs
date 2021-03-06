using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerEnemy : MonoBehaviour
{
    public float time;
    public float timer;

    public bool attacking;
    public bool inRange;

    public GameObject hitbox;
    public GameObject enemy;
    public Collider2D hitboxCol;
    Animator controlBoi;

    ChaserAI CAI;
    NewRoaming NR;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = gameObject.transform.GetChild(0).gameObject;
        hitboxCol = hitbox.GetComponent<Collider2D>();
        controlBoi = enemy.GetComponent<Animator>();
        CAI = enemy.GetComponent<ChaserAI>();
        NR = enemy.GetComponent<NewRoaming>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            attacking = true;
        }

        if (attacking)
        {
            controlBoi.SetBool("Attack", true);

            if (timer <= time)
            {
                timer += Time.deltaTime;
                CAI.enabled = false;
                NR.enabled = false;
            }
            else
            {
                hitboxCol.enabled = true;
                timer = 0;
                attacking = false;
                controlBoi.SetBool("Attack", false);
                inRange = false;
                CAI.enabled = true;
                NR.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
}
