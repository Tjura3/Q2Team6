using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincFrame : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("o"))
        //{
        //    rend.sharedMaterial = material[1];
        //}
        //else if (Input.GetKeyDown("p"))
        //{
        //    rend.sharedMaterial = material[0];
        //}

        if (gameObject.GetComponent<healthSystem>().canDamage == true)
        {
            rend.sharedMaterial = material[0];
        }
        else if (gameObject.GetComponent<healthSystem>().canDamage == false)
        {
            rend.sharedMaterial = material[1];
        }
    }
}
