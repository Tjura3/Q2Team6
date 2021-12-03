using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{

    public int hidingBeans = 0;
    public GameObject beans;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RunEnemy")
        {
            hidingBeans += 1;
            //Debug.Log(hidingBeans);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {

            for (int i = 1; i <= hidingBeans; i++)
            {
                Instantiate(beans, new Vector2(transform.position.x + i, transform.position.y), beans.transform.rotation);
            }

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
