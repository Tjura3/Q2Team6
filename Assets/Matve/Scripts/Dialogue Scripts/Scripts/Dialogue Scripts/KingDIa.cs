using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDIa : MonoBehaviour
{
    public GameObject tongue;
    [SerializeField] GameObject kingGameObject;

    DiaTrigger dia;
    bool diaActive;
    // Start is called before the first frame update
    void Start()
    {
        tongue.SetActive(false);
        dia = GetComponent<DiaTrigger>();

    }

    // Update is called once per frame
    void Update()
    {
        if(King.waveNum == 1 && !diaActive)
        {
            print("start king stuff");
            GetComponent<DiaTrigger>().TriggerDialogue();
            tongue.SetActive(true);

            kingGameObject.GetComponent<Collider2D>().enabled = true;
            kingGameObject.GetComponent<King>().enabled = false;
            //kingGameObject.GetComponent<Animator>().SetBool("BeScared", true);

            DialogueManager DM = FindObjectOfType<DialogueManager>();
            DM.diaCurrentTrigger = gameObject;
            dia.TriggerDialogue();
            diaActive = true;


        }

        if (diaActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }
}
