using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticTongue : MonoBehaviour
{
    Transform[] points;
    Rigidbody2D[] pointsRigidbody2Ds;
    LineRenderer lineRenderer;

    //The distance before line becomes stretchy
    [SerializeField] float startDistance;
    [SerializeField] float strechStrength;
    // Start is called before the first frame update
    void Start()
    {
        points = transform.GetComponentsInChildren<Transform>();
        //Fixing weird problem with empty child
        Transform[] tempPoints = new Transform[points.Length - 1];
        for (int i = 0; i < tempPoints.Length; i++)
        {
            tempPoints[i] = points[i + 1];
        }
        points = tempPoints;

        pointsRigidbody2Ds = transform.GetComponentsInChildren<Rigidbody2D>();
        Debug.Log(pointsRigidbody2Ds.Length);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if(i != 0)
            {
                float distance = Vector2.Distance(points[i].position, points[i - 1].position);
                distance -= startDistance;
                if(distance < 0)
                {
                    distance = 0;
                }

                float pullForce = strechStrength * distance;

                if (i != points.Length - 1)
                {
                    pullForce /= 2;
                }

                pointsRigidbody2Ds[i - 1].AddForce((-points[i - 1].position + points[i].position).normalized * pullForce);
            }

            if(i != points.Length - 1)
            {

                float distance = Vector2.Distance(points[i].position, points[i + 1].position);
                distance -= startDistance;
                if (distance < 0)
                {
                    distance = 0;
                }

                float pullForce = strechStrength * distance;

                if (i != 0)
                {
                    pullForce /= 2;
                }


                pointsRigidbody2Ds[i + 1].AddForce((-points[i + 1].position + points[i].position).normalized * pullForce);
            }
        }
    }

    void DrawLine()
    {

        Vector3[] pointsPos = new Vector3[points.Length];
        for (int i = 0; i < pointsPos.Length; i++)
        {
            pointsPos[i] = points[i].position;
        }
        lineRenderer.SetPositions(pointsPos);
    }
}
