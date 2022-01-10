using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{

    private int red = 0;
    private int yellow = 0;
    private int green = 0;
    private int blue = 0;
    private int purple = 0;

    public GameObject redBean;
    public GameObject yellowBean;
    public GameObject greenBean;
    public GameObject blueBean;
    public GameObject purpleBean;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.name[0])
        {
            case 'R':
                red++;
                break;
            case 'Y':
                yellow++;
                break;
            case 'G':
                green++;
                break;
            case 'B':
                blue++;
                break;
            case 'P':
                purple++;
                break;
        }

        if (collision.transform.CompareTag("RunEnemy"))
        {
            SFXManager.PlaySound("EnteringHouse");
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFXManager.PlaySound("Destroy");
            int offset = 0;

            if (red > 0)
            {
                for (int i = 1; i <= red; i++)
                {
                    offset++;
                    Instantiate(redBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), redBean.transform.rotation);
                }
            }

            if (yellow > 0)
            {

                for (int i = 1; i <= yellow; i++)
                {
                    offset++;
                    Instantiate(yellowBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), yellowBean.transform.rotation);
                }          
            }
            if (green > 0)
            {

                for (int i = 1; i <= green; i++)
                {
                    offset++;
                    Instantiate(greenBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), greenBean.transform.rotation);
                }
            }
            if (blue > 0)
            {

                for (int i = 1; i <= blue; i++)
                {
                    offset++;
                    Instantiate(blueBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), blueBean.transform.rotation);
                }
            }
            if (purple > 0)
            {

                for (int i = 1; i <= purple; i++)
                {
                    offset++;
                    Instantiate(purpleBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), purpleBean.transform.rotation);
                }
            }


            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
