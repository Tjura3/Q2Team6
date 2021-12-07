using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{

    int red = 0;
    int orange = 0;
    int yellow = 0;
    int green = 0;
    int blue = 0;
    int purple = 0;

    public GameObject redBean;
    public GameObject orangeBean;
    public GameObject yellowBean;
    public GameObject greenBean;
    public GameObject blueBean;
    public GameObject purpleBean;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Red"))
        {
            red += 1;
            Destroy(collision.gameObject);

        } else if (collision.gameObject.name == ("Orange")) { 

            orange += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name == ("Yellow"))
        {

            yellow += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name == ("Green"))
        {

            green += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name == ("Blue"))
        {

            blue += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name == ("Purple"))
        {

            purple += 1;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (red > 0)
            {
                for (int i = 1; i <= red; i++)
                {
                    Instantiate(redBean, new Vector2(transform.position.x + i, transform.position.y), redBean.transform.rotation);
                }

            }
            if (orange > 0)
            {

                for (int i = 1; i <= orange; i++)
                {
                    Instantiate(orangeBean, new Vector2(transform.position.x + i, transform.position.y), orangeBean.transform.rotation);
                }

            }
            if (yellow > 0)
            {

                for (int i = 1; i <= yellow; i++)
                {
                    Instantiate(yellowBean, new Vector2(transform.position.x + i, transform.position.y), yellowBean.transform.rotation);
                }

            }
            if (green > 0)
            {

                for (int i = 1; i <= green; i++)
                {
                    Instantiate(greenBean, new Vector2(transform.position.x + i, transform.position.y), greenBean.transform.rotation);
                }

            }
            if (blue > 0)
            {

                for (int i = 1; i <= blue; i++)
                {
                    Instantiate(blueBean, new Vector2(transform.position.x + i, transform.position.y), blueBean.transform.rotation);
                }

            }
            if (purple > 0)
            {

                for (int i = 1; i <= purple; i++)
                {
                    Instantiate(purpleBean, new Vector2(transform.position.x + i, transform.position.y), purpleBean.transform.rotation);
                }

            }
            

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
