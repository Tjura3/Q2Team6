using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candyween : MonoBehaviour
{
    private void Start()
    {
        candyMove();
    }
   
    void candyMove()
    {
        transform.LeanScale(new Vector2(1.1f,1.1f), 0.4f).setEaseOutCubic().setLoopPingPong();
    }


    /*
    IEnumerator Candy()
    {

        transform.LeanScale(Vector2.one, 0.3f).setEaseOutCubic().setLoopPingPong();
        yield return new WaitForSeconds(CandyWait);
        transform.LeanScale(Vector2.zero, 0.3f).setEaseOutCubic().setLoopPingPong();
    }
    */
}
