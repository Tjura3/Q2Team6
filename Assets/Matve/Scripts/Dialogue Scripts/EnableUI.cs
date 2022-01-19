using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUI : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;
    // Start is called before the first frame update
    void Start()
    {
        UI1.SetActive(false);
        UI2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UI1.SetActive(true);
            UI2.SetActive(true);
        }
    }
}
