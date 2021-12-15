using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{

    public int red = 0;
    public int yellow = 0;
    public int green = 0;
    public int blue = 0;
    public int purple = 0;

    public GameObject redBean;
    public GameObject yellowBean;
    public GameObject greenBean;
    public GameObject blueBean;
    public GameObject purpleBean;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Split(' ')[0] == ("Red") || collision.gameObject.name.Split('(')[0] == ("Red"))
        {
            red += 1;
            Destroy(collision.gameObject);

        } 
        else if (collision.gameObject.name.Split(' ')[0] == ("Yellow") || collision.gameObject.name.Split('(')[0] == ("Yellow"))
        {

            yellow += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name.Split(' ')[0] == ("Green") || collision.gameObject.name.Split('(')[0] == ("Green"))
        {

            green += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name.Split(' ')[0] == ("Blue") || collision.gameObject.name.Split('(')[0] == ("Blue"))
        {

            blue += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.name.Split(' ')[0] == ("Purple") || collision.gameObject.name.Split('(')[0] == ("Purple"))
        {

            purple += 1;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            print("house touched");
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
