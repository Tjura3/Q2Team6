using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Debug.Log("Right");
        } else if (rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("Left");
        }
    }
}
