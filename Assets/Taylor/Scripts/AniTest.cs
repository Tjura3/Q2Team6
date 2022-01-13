using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTest : MonoBehaviour
{
    public bool summonWave;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            summonWave = true;
        }

        if (summonWave = true)
        {
            anim.SetBool("StartWave", true);
        }
        else
        {
            summonWave = false;
        }

    }
}
