using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PointStickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

            pc.AddSource(constraintSource);
            pc.constraintActive = true;

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
}
