using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerLeft : MonoBehaviour
{
    Rigidbody2D rb2;

    int moveTime = 1;
    float pauseTime = 325;

    public King king;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();

        if (king.waveNum == 1)
        {
            pauseTime = 325;
        }
        if (king.waveNum == 2)
        {
            pauseTime = 250;
        }

        if (king.waveNum == 3)
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
            pauseTime-=Time.deltaTime*1000;
        }

        if (pauseTime <= 0)
        {
            moveTime = 1;
        }

        if (moveTime > 0)
        {
            moveTime--;
            rb2.MovePosition(rb2.position + new Vector2(2.5f, 0));
        }

        StartCoroutine(die());
    }
}
