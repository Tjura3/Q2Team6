using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDia : MonoBehaviour
{
    public TriggerTutorial TT;

    public GameObject tutorialtext1;
    public float timer;
    float time = 0.1f;


    public GameObject text;
    public GameObject blackScreen;
    GameObject player;
    PlayerMovement PM;

    Animator anim;

    int clicks = 4;

    private void Start()
    {
        tutorialtext1.SetActive(false);

        player = GameObject.Find("Player");
        PM = player.GetComponent<PlayerMovement>();
        PM.enabled = false;
        anim = blackScreen.GetComponent<Animator>();

        text.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clicks -= 1;
            if (clicks <= 0)
            {
                anim.SetBool("begin", true);
                text.SetActive(true);


            }

        }
    }

    private void OnDestroy()
    {
        TT.started = true;
    }
}
