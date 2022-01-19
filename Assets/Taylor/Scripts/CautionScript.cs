using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionScript : MonoBehaviour
{
    Animator anim;

    int pulseTime = 275;

    public King king;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("Caution", true);

        if (king.waveNum == 1)
        {
            pulseTime = 275;
        }
        if (king.waveNum == 2)
        {
            pulseTime = 200;
        }

        if (king.waveNum == 3)
        {
            pulseTime = 125;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pulseTime > 0)
        {
            pulseTime--;
        }

        if(pulseTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
