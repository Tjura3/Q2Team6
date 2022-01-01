using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twening : MonoBehaviour
{
    public GrowScript GS;
    int waitingTime = 2;
    bool stop1 = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    private void Update()
    {
        //Debug.Log(string.Format("size = {0}", GS.currentSize));
        if (GS.currentSize >= 1f & stop1 == false || Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(BubbleOne());
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
