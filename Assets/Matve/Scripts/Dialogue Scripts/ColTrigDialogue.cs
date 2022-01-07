using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColTrigDialogue : MonoBehaviour
{
    GameObject player;
    PlayerMovement PM;

    DiaTrigger dia;
    bool diaActive;
    void Start()
    {
        player = GameObject.Find("Player");
        PM = player.GetComponent<PlayerMovement>();

        dia = GetComponent<DiaTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diaActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager DM = FindObjectOfType<DialogueManager>();
        DM.diaCurrentTrigger = gameObject;
        dia.TriggerDialogue();
        diaActive = true;

        PM.enabled = false;
    }
}
