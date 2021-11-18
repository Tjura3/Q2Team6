using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Collider2D collider;
    GrowScript growScript;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        growScript = GetComponent<GrowScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Eat();
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
}
