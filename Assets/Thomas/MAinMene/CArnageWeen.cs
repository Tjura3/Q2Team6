using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CArnageWeen : MonoBehaviour
{
    private void Start()
    {
        candyMove();
    }

    void candyMove()
    {
        transform.LeanScale(new Vector2(1.1f, 1.1f), 0.4f).setEaseOutCubic().setLoopPingPong();
    }
}
