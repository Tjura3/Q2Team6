using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOut : MonoBehaviour
{
    public CanvasGroup TransImage;
    public GameObject WhiteFade;
    void Start()
    {
        StartCoroutine(StartTransiting());
        //transit();
        //StartCoroutine(StartTransit());
    }

    private void transit()
    {
        TransImage.LeanAlpha(0,1.2f);
    }
    IEnumerator StartTransiting()
    {
        transit();
        yield return new WaitForSeconds(2f);
        WhiteFade.SetActive(false);
    }

   
}
