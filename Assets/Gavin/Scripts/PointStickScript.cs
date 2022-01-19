using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PointStickScript : MonoBehaviour
{
    ElasticTongue tongue;
    public List<GameObject> objectsAttached;
    [SerializeField] ParentConstraint parentConstraintPrefab;

    // Start is called before the first frame update
    void Start()
    {
        objectsAttached = new List<GameObject>();
        tongue = transform.parent.GetComponent<ElasticTongue>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EatEnemies(collision.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EatEnemies(collision.transform);
    }

    void EatEnemies(Transform objectTransform)
    {
        if (tongue == null)
        {
            tongue = transform.parent.GetComponent<ElasticTongue>();
        }

        if (!tongue.isTongueOut)
        {
            return;
        }

        if (objectTransform.tag.CompareTo("Enemy") == 0 || objectTransform.tag.CompareTo("RunEnemy") == 0 || objectTransform.tag.CompareTo("King") == 0)
        {

            ScaredAI scaredAI = objectTransform.gameObject.GetComponent<ScaredAI>();
            ChaserAI chaserAI = objectTransform.gameObject.GetComponent<ChaserAI>();
            ShooterAI shooterAI = objectTransform.gameObject.GetComponent<ShooterAI>();
            enemyRoaming enemyRoaming = objectTransform.gameObject.GetComponent<enemyRoaming>();

            if(chaserAI != null && !tongue.twen.consumeBig)
            {
                return;
            }else if(shooterAI != null && !tongue.twen.consumeShoot)
            {
                return;
            }

            ConstraintSource constraintSource = new ConstraintSource();
            constraintSource.sourceTransform = transform;
            constraintSource.weight = 1;
            PositionConstraint pc = objectTransform.gameObject.GetComponent<PositionConstraint>();
            if (pc == null)
            {
                pc = objectTransform.gameObject.AddComponent<PositionConstraint>();
            }

            objectTransform.GetComponent<Renderer>().sortingOrder = transform.parent.GetComponent<Renderer>().sortingOrder;
            
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

                objectTransform.gameObject.GetComponent<Collider2D>().isTrigger = true;
                objectsAttached.Add(objectTransform.gameObject);
            }


            objectTransform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 8;

            if (objectTransform.gameObject.transform.childCount > 0)
            {
                objectTransform.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

            if (scaredAI != null)
            {
                scaredAI.enabled = false;
            }
            else if (chaserAI != null)
            {
                chaserAI.enabled = false;
            }
            else if (shooterAI != null)
            {
                shooterAI.enabled = false;
            }

            //enemyRoaming.enabled = false;
        }
    }

    public void Sticky(GameObject enemyGO)
    {
        ConstraintSource constraintSource = new ConstraintSource();
        constraintSource.sourceTransform = transform;
        constraintSource.weight = 1;
        enemyGO.AddComponent<ParentConstraint>();



        PositionConstraint pc = enemyGO.GetComponent<PositionConstraint>();
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

    public void UpdateStuckObjects()
    {
        foreach(GameObject gameObject in objectsAttached)
        {
            ConstraintSource constraintSource = new ConstraintSource();
            constraintSource.sourceTransform = transform;
            constraintSource.weight = 1;

            if(gameObject == null)
            {
                continue;
            }

            PositionConstraint pc = gameObject.GetComponent<PositionConstraint>();
            pc.locked = true;

            gameObject.name = transform.gameObject.name;

            //Clear sources that have been deleted
            for (int i = 0; i < pc.sourceCount; i++)
            {
                if (pc.GetSource(i).sourceTransform == null)
                {
                    pc.RemoveSource(i);
                    i--;
                }
            }

            pc.AddSource(constraintSource);
            pc.constraintActive = true;
        }
    }

    public bool EnemiesAttached()
    {
        foreach (GameObject enemy in objectsAttached)
        {
            if(enemy != null)
            {
                return true;
            }
        }
        return false;
    }
}
