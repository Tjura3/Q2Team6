using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager MusicInstance;

    public void Awake()
    {
        if(MusicInstance != null && MusicInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        MusicInstance = this;
        DontDestroyOnLoad(this);
    }
}
