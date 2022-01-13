using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject HP;

    public bool started;

    public float time;
    float timer;
    void Start()
    {
        tutorial.SetActive(false);
        HP.SetActive(false);
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
                HP.SetActive(true);
            }
        }
    }
}
