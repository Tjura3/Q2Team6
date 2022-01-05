using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twening : MonoBehaviour
{
    public GrowScript GS;
    public float EnemySizeRequierment;
    int waitingTime = 2;
    bool stop1 = false;

    public bool ConsumeBig = false;



    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    private void Update()
    {
        //Debug.Log(string.Format("size = {0}", GS.currentSize));
        if (GS.currentSize >= EnemySizeRequierment & stop1 == false) //|| Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(BubbleOne());
            ConsumeBig = true;
            stop1 = true;
        }
    }

    IEnumerator BubbleOne()
    {
        transform.LeanScale(Vector2.one, 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
    }
}
