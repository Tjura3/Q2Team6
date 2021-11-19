using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Collider2D collider;
    
    GrowScript growScript;
    
    [SerializeField] Camera camera;

    GameObject stunHitbox;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        growScript = GetComponent<GrowScript>();

        stunHitbox = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Eat();
        }

        if (Input.GetMouseButtonDown(0))
        {
            StunAttack();
        }
    }

    /// <summary>
    /// Checks to see if there is a creature to eat
    /// </summary>
    void Eat()
    {
        List<Collider2D> colliders = new List<Collider2D>();
        collider.GetContacts(colliders);

        foreach(Collider2D collider in colliders)
        {
            //CHANGE TAG FROM TEST FOOD TO ENEMY OR SOMETHING IDK
            if(collider.tag == "TestFood")
            {
                growScript.Eat(collider.gameObject);
            }
        }
    }

    void StunAttack()
    {
        Vector3 direction = Input.mousePosition;
        direction.z = -camera.transform.position.z;
        direction = camera.ScreenToWorldPoint(direction) - stunHitbox.transform.position;
        stunHitbox.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        Debug.Log(stunHitbox.transform.rotation);
    }
}
