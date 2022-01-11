using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HouseScript : MonoBehaviour
{
    [HideInInspector]
    public int red = 0;
    [HideInInspector]
    public int yellow = 0;
    [HideInInspector]
    public int green = 0;
    [HideInInspector]
    public int blue = 0;
    [HideInInspector]
    public int purple = 0;

    public GameObject redBean;
    public GameObject yellowBean;
    public GameObject greenBean;
    public GameObject blueBean;
    public GameObject purpleBean;

    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

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

            for (int i = 1; i <= red; i++)
            {
                offset++;
                Instantiate(redBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), redBean.transform.rotation);
            }


            for (int i = 1; i <= yellow; i++)
            {
                offset++;
                Instantiate(yellowBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), yellowBean.transform.rotation);
            }


            for (int i = 1; i <= green; i++)
            {
                offset++;
                Instantiate(greenBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), greenBean.transform.rotation);
            }


            for (int i = 1; i <= blue; i++)
            {
                offset++;
                Instantiate(blueBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), blueBean.transform.rotation);
            }


            for (int i = 1; i <= purple; i++)
            {
                offset++;
                Instantiate(purpleBean, new Vector2(transform.position.x + (offset * 0.1f), transform.position.y), purpleBean.transform.rotation);
            }


            if (gameObject != null)
            {
                Destroy(gameObject);

                
            }
            

            
        }
    }

    private void FillHouseAreaWalkable()
    {
        AstarPath.active.AddWorkItem(new AstarWorkItem(() => {
            // Safe to update graphs here
            GraphNode topLeftNode = AstarPath.active.GetNearest(new Vector2(boxCollider.bounds.center.x - boxCollider.bounds.extents.x, boxCollider.bounds.center.y - boxCollider.bounds.extents.y)).node;
            GraphNode bottomRightNode = AstarPath.active.GetNearest(new Vector2(boxCollider.bounds.center.x + boxCollider.bounds.extents.x, boxCollider.bounds.center.y + boxCollider.bounds.extents.y)).node;

            for (int x = 0; x < boxCollider.bounds.extents.x * 2; x++)
            {
                for (int y = 0; y < boxCollider.bounds.extents.y * 2; y++)
                {

                    GraphNode topLeftNode = AstarPath.active.GetNearest(new Vector2(x, y))).node;
                }
            }

        }));
    }

}
