using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUN : MonoBehaviour
{
    bool testBool;
    public int aa;

    SizeTrigger ST;

    DiaTrigger dia;

    public Transform spawnPoint;
    public GameObject bigBoi;

    // Start is called before the first frame update
    void Start()
    {
        ST = GetComponent<SizeTrigger>();
        dia = GetComponent<DiaTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ST.activated)
        {
            if(aa <= 0)
            {
                Instantiate(bigBoi, spawnPoint);

                DialogueManager DM = FindObjectOfType<DialogueManager>();
                DM.diaCurrentTrigger = gameObject;
                dia.TriggerDialogue();
                aa += 1;
            }
            
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }

    
}
