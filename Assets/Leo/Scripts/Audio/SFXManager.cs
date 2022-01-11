using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audiosrc;

    [HideInInspector]
    public AudioClip footstep, tongue, eat, destroy, escape, shoot, mele;

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
        shoot = Resources.Load<AudioClip>("Shooting");
        mele = Resources.Load<AudioClip>("MeleHit2");

        Audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Footstep":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.footstep, 0.2f);
                break;
            case "Tongue":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.tongue, 0.05f);
                break;
            case "Eating":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.eat, 0.05f);
                break;
            case "Destroy":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.destroy, 0.01f);
                break;
            case "EnteringHouse":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.escape, 0.05f);
                break;
            case "Shooting":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.shoot, 0.06f);
                break;
            case "MeleHit2":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.mele, 0.1f);
                break;
        }
    }
}
