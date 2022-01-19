using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audiosrc;

    [HideInInspector]
    public AudioClip footstep, tongue, eat, destroy, escape, shoot, mele, click, hover, transition;

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
        mele = Resources.Load<AudioClip>("MeleHit");
        click = Resources.Load<AudioClip>("click");
        hover = Resources.Load<AudioClip>("hover");
        transition = Resources.Load<AudioClip>("transition");

        Audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Footstep":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.footstep, 0.85f);
                break;
            case "Tongue":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.tongue, 0.4f);
                break;
            case "Eating":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.eat, 0.4f);
                break;
            case "Destroy":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.destroy, 0.4f);
                break;
            case "EnteringHouse":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.escape, 0.8f);
                break;
            case "Shooting":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.shoot, 0.06f);
                break;
            case "MeleHit":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.mele, 1.5f);
                break;
            case "click":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.click, 0.5f);
                break;
            case "hover":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.hover, 0.5f);
                break;
            case "transition":
                SFXManager.SFXInstance.Audiosrc.PlayOneShot(SFXManager.SFXInstance.transition, 0.3f);
                break;
        }
    }
}
