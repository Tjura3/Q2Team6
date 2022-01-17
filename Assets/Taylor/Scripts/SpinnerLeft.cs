using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerLeft : MonoBehaviour
{
    Rigidbody2D rb2;

    int moveTime = 0;
    int pauseTime = 325;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();

        if (King.waveNum == 1)
        {
            pauseTime = 325;
        }
        if (King.waveNum == 2)
        {
            pauseTime = 250;
        }

        if (King.waveNum == 3)
        {
            pauseTime = 175;
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseTime > 0)
        {
            pauseTime--;
        }

        if (pauseTime <= 0)
        {
            moveTime = 1;
        }

        if (moveTime > 0)
        {
            moveTime--;
            rb2.MovePosition(rb2.position + new Vector2(Input.GetAxis("Horizontal") + 5, 0));
        }

        StartCoroutine(die());
    }
}
