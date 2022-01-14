using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeTrigger : MonoBehaviour
{
    GameObject Player;
    GrowScript GS;

    public bool activated;

    public float trigger;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        GS = Player.GetComponent<GrowScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GS.currentSize >= trigger)
        {
            
            activated = true;
        }
        else
        {
            
            activated = false;
        }
    }
}
