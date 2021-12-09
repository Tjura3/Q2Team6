using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PointStickScript : MonoBehaviour
{
    public List<GameObject> objectsAttached;

    // Start is called before the first frame update
    void Start()
    {
        objectsAttached = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.CompareTo("Enemy") == 0 || collision.transform.tag.CompareTo("RunEnemy") == 0)
        {
            ConstraintSource constraintSource = new ConstraintSource();
            constraintSource.sourceTransform = transform;
            constraintSource.weight = 1;
            collision.gameObject.AddComponent<ParentConstraint>();
            ParentConstraint pc = collision.gameObject.GetComponent<ParentConstraint>();
            pc.locked = true;


            //Clear sources that have been deleted
            for (int i = 0; i < pc.sourceCount; i++)
            {
                if (pc.GetSource(i).sourceTransform == null)
                {
                    pc.RemoveSource(i);
                    i--;
                }
            }

            if (pc.sourceCount == 0)
            {
                pc.AddSource(constraintSource);
                pc.constraintActive = true;

                objectsAttached.Add(collision.gameObject);
            }

            ScaredAI scaredAI = collision.gameObject.GetComponent<ScaredAI>();
            ChaserAI chaserAI = collision.gameObject.GetComponent<ChaserAI>();
            enemyRoaming enemyRoaming = collision.gameObject.GetComponent<enemyRoaming>();

            if (scaredAI != null)
            {
                scaredAI.enabled = false;
            }
            else
            {
                chaserAI.enabled = false;
            }

            enemyRoaming.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.CompareTo("Enemy") == 0 || collision.transform.tag.CompareTo("RunEnemy") == 0)
        {
            ConstraintSource constraintSource = new ConstraintSource();
            constraintSource.sourceTransform = transform;
            constraintSource.weight = 1;
            collision.gameObject.AddComponent<ParentConstraint>();
            ParentConstraint pc = collision.gameObject.GetComponent<ParentConstraint>();
            pc.locked = true;


            //Clear sources that have been deleted
            for (int i = 0; i < pc.sourceCount; i++)
            {
                if(pc.GetSource(i).sourceTransform == null)
                {
                    pc.RemoveSource(i);
                    i--;
                }
            }

            if (pc.sourceCount == 0)
            {
                pc.AddSource(constraintSource);
                pc.constraintActive = true;

                collision.collider.isTrigger = true;
                objectsAttached.Add(collision.gameObject);
            }

            ScaredAI scaredAI = collision.gameObject.GetComponent<ScaredAI>();
            ChaserAI chaserAI = collision.gameObject.GetComponent<ChaserAI>();
            enemyRoaming enemyRoaming = collision.gameObject.GetComponent<enemyRoaming>();

            if (scaredAI != null)
            {
                scaredAI.enabled = false;
            }
            else
            {
                chaserAI.enabled = false;
            }

            enemyRoaming.enabled = false;
        }
    }

    public void Sticky(GameObject enemyGO)
    {
        ConstraintSource constraintSource = new ConstraintSource();
        constraintSource.sourceTransform = transform;
        constraintSource.weight = 1;
        enemyGO.AddComponent<ParentConstraint>();
        ParentConstraint pc = enemyGO.GetComponent<ParentConstraint>();
        pc.locked = true;

        //Clear sources that have been deleted
        for (int i = 0; i < pc.sourceCount; i++)
        {
            if (pc.GetSource(i).sourceTransform == null)
            {
                pc.RemoveSource(i);
                i--;
            }
        }

        if (pc.sourceCount == 0)
        {
            pc.AddSource(constraintSource);
            pc.constraintActive = true;

            objectsAttached.Add(enemyGO);
        }
    }
}
