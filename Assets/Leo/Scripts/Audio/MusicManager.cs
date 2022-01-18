using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager MusicInstance;
    public AudioSource BGM;
    private int sceneIndex;
    private string currentClip = " ";

    [HideInInspector]
    public AudioClip mainMenu, credits, gameScene, boss;

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

    private void Start()
    {
        mainMenu = Resources.Load<AudioClip>("InfiniteDoors");
        credits = Resources.Load<AudioClip>("Tiny_Blocks");
        gameScene = Resources.Load<AudioClip>("Potato");
        boss = Resources.Load<AudioClip>("Stupid_Dancer");

        BGM = GetComponent<AudioSource>();
    }

    private void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (sceneIndex)
        {
            case 0:
                currentClip = "InfiniteDoors";
                if (BGM.clip.name != currentClip)
                {
                    BGM.Stop();
                    BGM.clip = mainMenu;
                    BGM.Play();
                }
                break;
            case 1:
                currentClip = "Tiny_Blocks";
                if (BGM.clip.name != currentClip)
                {
                    BGM.Stop();
                    BGM.clip = credits;
                    BGM.Play();
                }
                break;
            case 3:
                currentClip = "Potato";
                if (BGM.clip.name != currentClip)
                {
                    BGM.Stop();
                    BGM.clip = gameScene;
                    BGM.Play();
                }
                break;
            case 4:
                currentClip = "Stupid_Dancer";
                if (BGM.clip.name != currentClip)
                {
                    BGM.Stop();
                    BGM.clip = boss;
                    BGM.Play();
                }
                break;
        }
    }
}
