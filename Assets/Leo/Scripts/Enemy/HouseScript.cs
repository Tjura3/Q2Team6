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
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("contact");
        switch (collision.gameObject.name[0])
        {
            case 'R':
                //print("add one");
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
            //print("entered");
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
                FillHouseAreaWalkableThenDestroy();


            }
            

            
        }
    }

    private void FillHouseAreaWalkableThenDestroy()
    {
        AstarPath.active.AddWorkItem(new AstarWorkItem(() => {
            // Safe to update graphs here

            for (float x = -boxCollider.bounds.extents.x - 1f; x <= boxCollider.bounds.extents.x + 1f; x+=0.5f)
            {
                for (float y = -boxCollider.bounds.extents.y - 1f; y <= boxCollider.bounds.extents.y + 1.5f; y+=0.5f)
                {
                    GraphNode node = AstarPath.active.GetNearest(new Vector2(x + boxCollider.bounds.center.x, y + boxCollider.bounds.center.y)).node;
                    node.Walkable = true;
                }
            }
            var gg = AstarPath.active.data.gridGraph;
            gg.GetNodes(node => gg.CalculateConnections((GridNodeBase)node));

            Destroy(gameObject);
        }));
    }

}
