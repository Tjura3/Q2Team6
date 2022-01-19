using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUN2 : MonoBehaviour
{
    SizeTrigger ST;
    public GameObject barrier;
    // Start is called before the first frame update
    void Start()
    {
        ST = GetComponent<SizeTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ST.activated)
        {
            Destroy(barrier);
        }
    }
}
