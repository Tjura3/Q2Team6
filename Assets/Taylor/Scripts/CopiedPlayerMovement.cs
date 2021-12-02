using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopiedPlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb2;
    SpriteRenderer sr;
    Animator a;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            a.SetBool("Running", false);
        }
        else
        {
            a.SetBool("Running", true);
        }


        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        //Bottom left kinda cringe
        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
        {
            sr.flipX = false;
        }

    }

    private void FixedUpdate()
    {
        rb2.velocity = Vector2.zero;
    }
}