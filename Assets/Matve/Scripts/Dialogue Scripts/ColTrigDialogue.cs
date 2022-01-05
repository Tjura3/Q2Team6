using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColTrigDialogue : MonoBehaviour
{
    DiaTrigger dia;
    bool diaActive;
    void Start()
    {
        dia = GetComponent<DiaTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diaActive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dia.TriggerDialogue();
        diaActive = true;
    }
}
