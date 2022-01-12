using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOut : MonoBehaviour
{

    public GameObject transit;
    
    void Start()
    {
        transform.localScale = Vector2.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BubbleOne());
        }
    }
    IEnumerator BubbleOne()
    {

        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(2f);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();

    }
}
