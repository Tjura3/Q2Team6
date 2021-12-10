using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    Rigidbody2D RB;

    public float kbForce;
    public float kbForceNeg;
    // Start is called before the first frame update
    void Start()
    {
        
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Tier3)
    {
        
        if(Tier3.gameObject.tag == "Tier3")
        {
            print("AAAAAAAAAAAAAAAA");
            RB.AddForce(new Vector2(kbForceNeg, 0));
        }
    }
}
