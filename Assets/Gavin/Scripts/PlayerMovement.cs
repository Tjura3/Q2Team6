using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb2;
    SpriteRenderer sr;
    Animator a;
    
    [HideInInspector] public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        rb2 = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            a.SetBool("Running", false);
            a.SetBool("Shoot", true);
            a.SetBool("Attack", true);
        }
        else
        {
            a.SetBool("Running", true);
            a.SetBool("Shoot", false);
            a.SetBool("Attack", false);
        }


        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        //Bottom left kinda cringe
        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
        {
            sr.flipX = false;
        }

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb2.MovePosition(rb2.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        }
        else
        {
            rb2.velocity = Vector2.zero;
        }
    }
}
