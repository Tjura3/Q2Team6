using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicManagers : MonoBehaviour
{
    public int pages = 4;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    // Start is called before the first frame update
    void Start()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pages--;
        }
        if (pages == 4)
        {
            p1.SetActive(true);
            
        }
        if (pages == 3)
        {
            p1.SetActive(false);
            p2.SetActive(true);
            
        }
        if (pages == 2)
        {
            p2.SetActive(false);
            p3.SetActive(true);
            
        }
        if (pages == 1)
        {
            p3.SetActive(false);
            p4.SetActive(true);
            
        }
        if (pages <= 0)
        {
            pages = 0;
        }
    }
}
