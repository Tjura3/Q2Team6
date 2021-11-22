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
    [SerializeField] float maxSpeed;

    //For generating the rope
    [SerializeField] int numberOfPoints;
    [SerializeField] float initialDistanceBetweenPoints;
    [SerializeField] GameObject pointPrefab;
    [SerializeField] float shootOutDistance;

    [SerializeField] Camera camera;
    [SerializeField] float mouseMoveSpeed;

    [SerializeField] Transform playerT;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePoints();

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

        pointsRigidbody2Ds[pointsRigidbody2Ds.Length-1].bodyType = RigidbodyType2D.Kinematic;
        //points[points.Length - 1].position = new Vector3(6, 0, 0);
    }

    void GeneratePoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            //new Vector3((i * initialDistanceBetweenPoints) - numberOfPoints * initialDistanceBetweenPoints, 0, 0)
            GameObject point = Instantiate(pointPrefab, new Vector3(0, 0, 0), new Quaternion(), transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = (mousePos - points[0].position).normalized;



            pointsRigidbody2Ds[0].AddForce(dir * mouseMoveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pointsRigidbody2Ds[0].AddForce(Vector2.left * shootOutDistance);
        }

        UpdatePoints();
        
    }

    void UpdatePoints()
    {
        pointsRigidbody2Ds[pointsRigidbody2Ds.Length - 1].MovePosition(playerT.position);

        for (int i = 0; i < points.Length; i++)
        {
            if (i != 0)
            {
                float distance = Vector2.Distance(points[i].localPosition, points[i - 1].localPosition);
                distance -= startDistance;
                if (distance < 0)
                {
                    distance = 0;
                }

                float pullForce = strechStrength * distance;

                if (i != points.Length - 1)
                {
                    pullForce /= 2;
                }

                if (pullForce > maxSpeed)
                {
                    pullForce = maxSpeed;
                }

                pointsRigidbody2Ds[i - 1].AddForce((-points[i - 1].localPosition + points[i].localPosition).normalized * pullForce);
            }

            if (i != points.Length - 1)
            {

                float distance = Vector2.Distance(points[i].localPosition, points[i + 1].localPosition);
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

                if (pullForce > maxSpeed)
                {
                    pullForce = maxSpeed;
                }

                pointsRigidbody2Ds[i + 1].AddForce((-points[i + 1].localPosition + points[i].localPosition).normalized * pullForce);
            }
        }

        //pointsRigidbody2Ds[points.Length - 1].velocity = Vector3.zero;
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
