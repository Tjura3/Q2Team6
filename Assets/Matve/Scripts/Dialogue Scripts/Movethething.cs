using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movethething : MonoBehaviour
{
    public GameObject blackscreen;

    Animator anim;
    void Start()
    {
        anim = blackscreen.GetComponent<Animator>();
        anim.SetBool("begin", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
