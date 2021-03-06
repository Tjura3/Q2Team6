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
    public bool canShoot;
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
    [SerializeField] public Twening twen;

    [Header("Player Variables")]
    //[SerializeField] SpriteRenderer 
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

        lineRenderer.widthMultiplier = playerT.localScale.x;

        DrawLine();
        if (Input.GetMouseButtonDown(0) && !isShooting && !isTongueOut && canShoot)
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

        if (Input.GetMouseButtonDown(0))
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

        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("BiteClose") && IsAllPointsInside())
        {
            
        }
    }
    private void FixedUpdate()
    {
        if (shoot)
        {
            SFXManager.PlaySound("Tongue");

            Vector3 mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Vector2 dir = (mousePos - points[0].transform.position).normalized;

            //points[0].rb.AddForce(dir * mouseShootSpeed, ForceMode2D.Impulse);

            shootVelocity = dir * (mouseShootSpeed * (playerT.gameObject.GetComponent<GrowScript>().currentSize * 0.2f) + 20);
            //canShoot = false;
            shoot = false;
            playerMovement.canMove = false;
            playerAnimator.SetTrigger("OpenMouth");
            playerAnimator.SetBool("MouthClose", false);
            ContactFilter2D filter2D = new ContactFilter2D();
            filter2D.layerMask = 1<<12;
            filter2D.useLayerMask = true;
            Collider2D[] results = new Collider2D[5];
            int num = Physics2D.OverlapBox(playerT.position, new Vector2(0.1f, 0.1f), 180, filter2D, results);
            //Debug.Log(ray.collider.gameObject.name);
            if(num != 0)
            {
                GetComponent<Renderer>().sortingOrder = 6;
            }
            else
            {
                GetComponent<Renderer>().sortingOrder = 8;
            }

            lineRenderer.enabled = true;


        }

        if (extendShoot && numOfextendShoots >= 0)
        {
            SFXManager.PlaySound("Tongue");

            numOfextendShoots--;
            extendShoot = false;

            Vector3 mousePos = Input.mousePosition;
            mousePos = camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Vector2 dir = (mousePos - points[0].transform.position).normalized;

            //points[0].rb.AddForce(dir * mouseShootSpeed, ForceMode2D.Impulse);

            Vector2 shootVelocity = dir * (extendShootStrength * (playerT.gameObject.GetComponent<GrowScript>().currentSize/2) + 30);

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
        float adjustedDespawnDist = despawDist * playerT.localScale.x + 1;

        if (points.Count > 2)
        {
            points[0].gameObject.name = "End";
            if (Vector2.Distance(points[0].transform.position, playerT.position) >= spawnDist)
            {

                if (Vector2.Distance(points[points.Count - 2].transform.position, playerT.position) >= spawnDist && points.Count <= maxNumOfPoints && canSpawnPoint)
                {
                    isTongueOut = canSpawnPoint;
                    CreateNewPoint();
                    UpdateLine();
                }
                else if (Vector2.Distance(points[points.Count - 2].transform.position, playerT.position) <= adjustedDespawnDist && !Input.GetMouseButton(0) && points[points.Count - 2].canBeDestroyed >= 5 && !canSpawnPoint)
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
            for (int i = 0; i < points.Count; i++)
            {
                points[i].transform.position = playerT.position;
                points[i].rb.velocity = Vector2.zero;
            }
            canSpawnPoint = false;
            isShooting = false;
            playerMovement.canMove = true;
            numOfextendShoots = 3;
            CloseMouth();
        }

        //strechStrength = -(maxNumOfPoints * 2) * points.Count + 2000f;
        //Debug.Log(-(maxNumOfPoints * testVar) * points.Count);
    }

    bool AllEnemiesEaten()
    {
        bool allEnemiesEaten = false;
        for (int i = 0; i < points.Count; i++)
        {
            if (points[0].pointStick.EnemiesAttached())
            {
                return false;
            }
        }
        return allEnemiesEaten;
    }

    void CloseMouth()
    {

        bool enemiesEaten = playerAttack.Eat();
        if (enemiesEaten)
        {
            SFXManager.PlaySound("Eating");
        }
        else
        {
            playerAnimator.SetBool("MouthClose", true);
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
                //slow = true;
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