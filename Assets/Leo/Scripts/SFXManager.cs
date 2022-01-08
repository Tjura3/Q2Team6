using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audiosrc;

    public AudioClip footstep, tongue, eat, destroy, escape;

    public static SFXManager SFXInstance;

    public void Awake()
    {
        if (SFXInstance != null && SFXInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        SFXInstance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        footstep = Resources.Load<AudioClip>("Footstep");
        tongue = Resources.Load<AudioClip>("Tongue");
        eat = Resources.Load<AudioClip>("Eating");
        destroy = Resources.Load<AudioClip>("Destroy");
        escape = Resources.Load<AudioClip>("EnteringHouse");

        Audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Footstep":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.footstep);
                break;
            case "Tongue":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.tongue);
                break;
            case "Eating":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.eat);
                break;
            case "Destroy":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.destroy);
                break;
            case "EnteringHouse":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.escape);
                break;
        }
    }
}
