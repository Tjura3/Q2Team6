using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Collider2D collider;
    
    GrowScript growScript;
    
    [SerializeField] Camera camera;


    GameObject stunHitbox;
    Collider2D stunHitboxCollider;
    [SerializeField] float stunHitboxDuration;
    float stunHitboxActiveTime;
    [SerializeField] float maxSpinSpeed;
    bool stunHitboxActive;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        growScript = GetComponent<GrowScript>();

        //stunHitbox = transform.GetChild(0).gameObject;
        //stunHitboxCollider = stunHitbox.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Eat();
        }
        return;
        if (Input.GetMouseButtonDown(0))
        {
            //StunAttack();
        }

        if (stunHitboxActive)
        {
            stunHitboxActiveTime += Time.deltaTime;
            if(stunHitboxActiveTime >= stunHitboxDuration)
            {
                stunHitboxActiveTime = 0;
                stunHitboxActive = false;
            }
        }
        else
        {
            stunHitboxActiveTime = 0;
            stunHitbox.SetActive(false);
        }

    }

    /// <summary>
    /// Checks to see if there is a creature to eat
    /// </summary>
    public bool Eat()
    {
        bool enemiesEaten = false;
        List<Collider2D> colliders = new List<Collider2D>();
        collider.GetContacts(colliders);

        System.Random random = new System.Random();

        foreach(Collider2D collider in colliders)
        {
            //CHANGE TAG FROM TEST FOOD TO ENEMY OR SOMETHING IDK
            if (collider.tag == "Enemy" || collider.tag == "RunEnemy")
            {
                enemiesEaten = true;
                print("eat: " + collider.gameObject.name + "; Tag: " + collider.gameObject.tag);
                collider.GetComponent<Animator>().SetTrigger("Shrink");
                //growScript.Eat(collider.gameObject);
            }
        }

        return enemiesEaten;
    }

    void StunAttack()
    {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos = camera.ScreenToWorldPoint(mousePos);

        stunHitbox.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x));
        stunHitboxActive = true;
        stunHitbox.SetActive(true);
    }
}
