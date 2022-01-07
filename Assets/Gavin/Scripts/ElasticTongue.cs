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


    //Does the tongue need to be launched
    bool shoot;
    bool canShoot;
    //Is the tongue being shot again while it is already out
    bool extendShoot;

    [SerializeField] float testVar;

    //Is the tongue going out.
    bool isShooting;
    public bool isTongueOut;
    Vector2 shootVelocity;
    bool canSpawnPoint;


    float retractTimer;
    [SerializeField] float maxRetractTime;

    [SerializeField] float extendShootStrength;

    [SerializeField] float maxShootTime;
    [SerializeField] float minShootTime;
    float shootTime;

    [SerializeField] float slowDist;

    [Header("Player Variables")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Transform playerT;
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerAttack playerAttack;

    int numOfextendShoots = 2;

    // Start is called before the first frame update
    void Start()
    {


        canShoot = true;

        playerMovement.canMove = true;

        shootTime = 0;
        shootVelocity = Vector2.zero;

        points = new List<Point>();

        //GeneratePoints();
        //CreateNewPoint();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Count;


        //points[points.Count].rb.bodyType = RigidbodyType2D.Kinematic;


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
        if (Input.GetMouseButtonDown(0) && !isShooting && !isTongueOut)
        {
            shoot = true;
            isShooting = true;
            shootTime = 0;
            canSpawnPoint = true;

            extendShoot = true;

            retractTimer = 0;
        }
        else if (Input.GetMouseButtonDown(0) && isTongueOut)
        {
            extendShoot = true;

            canSpawnPoint = true;
            retractTimer = 0;
        }

        if (Input.GetMouseButton(0))
        {

            retractTimer = 0;
        }


        if (Input.GetMouseButtonDown(1))
        {
            canSpawnPoint = false;
            canShoot = true;
        }

        shootTime += Time.deltaTime;
        if ((shootTime >= maxShootTime || (!Input.GetMouseButton(0) && shootTime >= minShootTime)) && isShooting)
        {
            isShooting = false;
            //canShoot = true;
        }

        retractTimer += Time.deltaTime;
        if(retractTimer >= maxRetractTime)
        {
            canSpawnPoint = false;
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

            //points[0].rb.AddForce(dir * mouseShootSpeed, ForceMode2D.Impulse);

            shootVelocity = dir * mouseShootSpeed;
            //canShoot = false;
            shoot = false;
            playerMovement.canMove = false;
            playerAnimator.SetTrigger("OpenMouth");
            lineRenderer.enabled = true;


        }

        if (extendShoot && numOfextendShoots >= 0)
        {
            numOfextendShoots--;
            extendShoot = false;

            Vector3 mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Vector2 dir = (mousePos - points[0].transform.position).normalized;

            //points[0].rb.AddForce(dir * mouseShootSpeed, ForceMode2D.Impulse);

            Vector2 shootVelocity = dir * extendShootStrength;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    points[i].rb.AddForce(shootVelocity, ForceMode2D.Impulse);
                }catch(System.Exception e)
                {
                    break;
                }
            }
            

        }

        UpdateTongue();

        UpdatePoints();


        points[points.Count - 1].rb.velocity = Vector3.zero;

    }

    /// <summary>
    /// Lengthens or shortens the tongue
    /// </summary>
    void UpdateTongue()
    {
       

        if (points.Count > 2)
        {
            points[0].gameObject.name = "Anchor";
            if (Vector2.Distance(points[0].transform.position, playerT.position) >= spawnDist)
            {

                if (Vector2.Distance(points[points.Count - 2].transform.position, playerT.position) >= spawnDist && points.Count <= maxNumOfPoints && canSpawnPoint)
                {
                    isTongueOut = canSpawnPoint;
                    CreateNewPoint();
                    UpdateLine();
                }
                else if (Vector2.Distance(points[points.Count - 2].transform.position, playerT.position) <= despawDist && !Input.GetMouseButton(0) && points[points.Count - 2].canBeDestroyed >= 5 && !canSpawnPoint)
                {

                    List<GameObject> destroyedPoint = points[points.Count - 2].pointStick.objectsAttached;

                    Point point = points[points.Count - 3];

                    for (int i = 0; i < destroyedPoint.Count; i++)
                    {
                        point.pointStick.objectsAttached.Add(destroyedPoint[i]);
                        point.pointStick.Sticky(destroyedPoint[i]);


                    }

                    

                    Destroy(points[points.Count - 2].gameObject);
                    points.RemoveAt(points.Count - 2);

                    point.pointStick.UpdateStuckObjects();

                    UpdateLine();


                    
                }
            }
        }
        else
        {
            CreateNewPoint();
            UpdateLine();
        }

        if(IsAllPointsInside() && isTongueOut)
        {
            isTongueOut = false;
            canSpawnPoint = false;
            isShooting = false;
            playerMovement.canMove = true;
            numOfextendShoots = 3;
            CloseMouth();
        }

        //strechStrength = -(maxNumOfPoints * 2) * points.Count + 2000f;
        //Debug.Log(-(maxNumOfPoints * testVar) * points.Count);
    }

    void CloseMouth()
    {
        bool enemiesEaten = playerAttack.Eat();
        if (!enemiesEaten)
        {
            playerAnimator.SetTrigger("CloseMouth");
        }
        lineRenderer.enabled = false;
    }

    bool IsAllPointsInside()
    {
        for (int i = 0; i < points.Count; i++)
        {
            if(Vector2.Distance(points[i].transform.position, playerT.position) >= spawnDist)
            {
                return false;
            }
        }
        return true;
    }

    public void TurnOffTongueCollider()
    {

    }

    public void TurnOnTongueCollider()
    {
    }

    /// <summary>
    /// Calculates the velocity and applies it to every point
    /// </summary>
    void UpdatePoints()
    { 
        points[points.Count - 1].rb.MovePosition(playerT.position);


        for (int i = 0; i < points.Count; i++)
        {
            bool slow = false;
            if (isShooting)
            {
                points[i].rb.velocity = shootVelocity;
                continue;
            }
            else if (Vector2.Distance(points[i].transform.position, playerT.position) <= slowDist)
            {
                slow = true;
            }

            //Test for anti swirl
            if (!Input.GetMouseButton(0))
            {
                //points[i].rb.velocity *= 0.5f;
            }


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

            if (slow)
            {
                points[i].rb.velocity *= 0.2f;
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

        if (points.Count < 1)
        {
            points.Add(point);
            points[0].rb.bodyType = RigidbodyType2D.Kinematic;
            points[0].gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            points.Insert(points.Count - 1, point);
        }

    }

    float CalculatePullForce(Point point1, Point point2)
    {

        //Get Distance
        float distance = Vector2.Distance(point1.transform.localPosition, point2.transform.localPosition);
        //distance -= pointDistance;

        if (distance < 0)
        {
            distance = 0;
        }

        //Calculate pullForce
        float pullForce = strechStrength * distance;

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
    public PointStickScript pointStick;
    public int canBeDestroyed;
    public Point(GameObject gameObject)
    {
        pointStick = gameObject.GetComponent<PointStickScript>();
        transform = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        this.gameObject = gameObject;
    }
}