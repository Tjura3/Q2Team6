using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticTongue : MonoBehaviour
{
    List<Point> points;
    LineRenderer lineRenderer;

    //The distance before line becomes stretchy
    [SerializeField] float startDistance;
    [SerializeField] float whileShootingDistance;
    [SerializeField] float strechStrength;
    [SerializeField] float damperStrength;
    [SerializeField] float maxSpeed;

    //For generating the rope
    [SerializeField] int maxNumOfPoints;
    [SerializeField] float initialDistanceBetweenPoints;
    [SerializeField] GameObject pointPrefab;
    //How far the point has to be away from the center to spawn another one
    [SerializeField] float spawnDist;
    //How far the point has to be away from the center to despawn
    [SerializeField] float despawDist;

    [SerializeField] Camera camera;
    [SerializeField] float mouseDragSpeed;
    [SerializeField] float mouseShootSpeed;

    [SerializeField] Transform playerT;

    float pointDistance;
    //Does the tongue need to be launched
    bool shoot;
    //Is the tongue being dragged
    bool drag;

    [SerializeField] float testVar;

    // Start is called before the first frame update
    void Start()
    {
        pointDistance = startDistance;

        points = new List<Point>();

        //GeneratePoints();
        CreateNewPoint();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Count;



        //points[points.Length - 1].position = new Vector3(6, 0, 0);

    }

    void GeneratePoints()
    {
        for (int i = 0; i < 0; i++)
        {
            //new Vector3((i * initialDistanceBetweenPoints) - numberOfPoints * initialDistanceBetweenPoints, 0, 0)
            GameObject point = Instantiate(pointPrefab, new Vector3((i * initialDistanceBetweenPoints) - maxNumOfPoints * initialDistanceBetweenPoints, 0, 0), new Quaternion(), transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        if (Input.GetMouseButtonDown(0) && !drag)
        {
            shoot = true;
            Debug.Log("Shoot");
        }

        if (Input.GetMouseButton(0))
        {
            pointDistance = whileShootingDistance;
            drag = true;
        }
        else
        {
            pointDistance = startDistance;
            drag = false;
        }
    }
    private void FixedUpdate()
    {
        if (shoot)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Vector2 dir = (mousePos - points[0].transform.position).normalized;

            points[0].rb.AddForce(dir * mouseShootSpeed, ForceMode2D.Impulse);

            shoot = false;
        }

        if (drag)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Vector2 dir = (mousePos - points[0].transform.position).normalized;

            points[0].rb.AddForce(dir * mouseDragSpeed);
        }


        UpdateTongue();

        UpdatePoints();


    }

    /// <summary>
    /// Lengthens or shortens the tongue
    /// </summary>
    void UpdateTongue()
    {
       

        if (points.Count > 2)
        {
            if (Vector2.Distance(points[0].transform.position, playerT.position) >= spawnDist)
            {
                if (Vector2.Distance(points[points.Count - 2].transform.position, playerT.position) >= spawnDist && points.Count <= maxNumOfPoints)
                {
                    points[points.Count - 1].rb.bodyType = RigidbodyType2D.Dynamic;
                    CreateNewPoint();
                    points[points.Count - 1].rb.bodyType = RigidbodyType2D.Kinematic;
                    UpdateLine();
                }
                else if (Vector2.Distance(points[points.Count - 2].transform.position, playerT.position) <= despawDist && !Input.GetMouseButton(0) && points[points.Count - 2].canBeDestroyed >= 5)
                {
                    Destroy(points[points.Count - 2].gameObject);
                    points.RemoveAt(points.Count - 2);
                    UpdateLine();
                }
            }
        }
        else
        {
            points[points.Count - 1].rb.bodyType = RigidbodyType2D.Dynamic;
            CreateNewPoint();
            points[points.Count - 1].rb.bodyType = RigidbodyType2D.Kinematic;
            UpdateLine();
        }
        points[points.Count - 1].velocity = Vector3.zero;

        //strechStrength = -(maxNumOfPoints * 2) * points.Count + 2000f;
        //Debug.Log(-(maxNumOfPoints * testVar) * points.Count);
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

    /// <summary>
    /// Calculates the velocity and applies it to every point
    /// </summary>
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

            points[i].canBeDestroyed++;
            if(points[i].canBeDestroyed > 100)
            {
                points[i].canBeDestroyed = 100;
            }
        }

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

    void UpdateLine()
    {
        lineRenderer.positionCount = points.Count;
    }

    void CreateNewPoint()
    {
        Point point = new Point(Instantiate(pointPrefab, playerT.position, new Quaternion(), transform));

        points.Add(point);
    }

    float CalculatePullForce(Point point1, Point point2)
    {

        //Get Distance
        float distance = Vector2.Distance(point1.transform.localPosition, point2.transform.localPosition);
        distance -= pointDistance;

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
    public int canBeDestroyed;
    public Point(GameObject gameObject)
    {
        transform = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        this.gameObject = gameObject;
    }
}