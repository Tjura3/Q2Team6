using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMove : MonoBehaviour
{
    PlayerMovement PM;
    void Start()
    {
        PM = gameObject.GetComponent<PlayerMovement>();
        PM.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
