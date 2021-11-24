using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticTongue : MonoBehaviour
{
    List<Point> points;
    LineRenderer lineRenderer;

    //The distance before line becomes stretchy
    [SerializeField] float startDistance;
    [SerializeField] float strechStrength;
    [SerializeField] float damperStrength;
    [SerializeField] float maxSpeed;

    //For generating the rope
    [SerializeField] int numberOfPoints;
    [SerializeField] float initialDistanceBetweenPoints;
    [SerializeField] GameObject pointPrefab;

    [SerializeField] Camera camera;
    [SerializeField] float mouseMoveSpeed;

    [SerializeField] Transform playerT;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Point>();

        GeneratePoints();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Point"))
            {
                points.Add(new Point(transform.GetChild(i).gameObject));
            }
        }

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Count;

        Debug.Log(points.Count);

        points[points.Count-1].rb.bodyType = RigidbodyType2D.Kinematic;
        //points[points.Length - 1].position = new Vector3(6, 0, 0);
    }

    void GeneratePoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            //new Vector3((i * initialDistanceBetweenPoints) - numberOfPoints * initialDistanceBetweenPoints, 0, 0)
            GameObject point = Instantiate(pointPrefab, new Vector3((i * initialDistanceBetweenPoints) - numberOfPoints * initialDistanceBetweenPoints, 0, 0), new Quaternion(), transform);
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

            Vector2 dir = (mousePos - points[0].transform.position).normalized;



            points[0].rb.AddForce(dir * mouseMoveSpeed);
        }

        UpdatePoints();
        
    }

    /*void UpdatePoints()
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

                float pullForce = -strechStrength * distance - damperStrength * distance;
                pullForce *= -1;

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

                float pullForce = -strechStrength * distance - damperStrength * distance;
                pullForce *= -1;

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
    }*/


    void UpdatePoints()
    {
        points[points.Count - 1].rb.MovePosition(playerT.position);


        for (int i = 0; i < points.Count; i++)
        {
            if (i != 0)
            {
                //Calculate one behind
                points[i].rb.AddForce((points[i - 1].transform.localPosition - points[i].transform.localPosition).normalized * CalculatePullForce(points[i - 1], points[i]));
            }

            if (i != points.Count-1)
            {
                //Calculate one in front
                points[i].rb.AddForce((points[i + 1].transform.localPosition - points[i].transform.localPosition).normalized * CalculatePullForce(points[i + 1], points[i]));
            }
        }

        points[points.Count - 1].velocity = Vector3.zero;
    }
    void DrawLine()
    {

        Vector3[] pointsPos = new Vector3[points.Count];
        for (int i = 0; i < pointsPos.Length; i++)
        {
            pointsPos[i] = points[i].transform.position;
        }
        lineRenderer.SetPositions(pointsPos);
    }

    float CalculatePullForce(Point point1, Point point2)
    {

        //Get Distance
        float distance = Vector2.Distance(point1.transform.localPosition, point2.transform.localPosition);
        distance -= startDistance;

        if (distance < 0)
        {
            distance = 0;
        }

        //Calculate pullForce
        float pullForce = -strechStrength * distance - damperStrength * distance;
        pullForce *= -1;

        if (pullForce > maxSpeed)
        {
            pullForce = maxSpeed;
        }

        return pullForce;
    }

}

class Point
{
    public Vector2 velocity;
    public Transform transform;
    public Rigidbody2D rb;
    public GameObject gameObject;
    public Point(GameObject gameObject)
    {
        transform = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();

    }
}