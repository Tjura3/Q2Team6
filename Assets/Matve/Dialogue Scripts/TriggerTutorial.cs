using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject tutorial;

    public bool started;

    public float time;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if(time >= timer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                tutorial.SetActive(true);
            }
        }
    }
}
