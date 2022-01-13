using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOut : MonoBehaviour
{
    public CanvasGroup TransImage;
    
    
    void Start()
    {
        transit();
        //StartCoroutine(StartTransit());
    }

    private void transit()
    {
        TransImage.LeanAlpha(0,1.2f);
    }


    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BubbleOne());
        }
    }
    IEnumerator StartTransit()
    {

        TransImage.LeanAlpha(0, 1);
        yield return new WaitForSeconds(2f);
        
    }*/
}
