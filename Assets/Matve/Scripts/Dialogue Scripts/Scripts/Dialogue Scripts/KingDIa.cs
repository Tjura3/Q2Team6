using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDIa : MonoBehaviour
{
    public GameObject tongue;
    // Start is called before the first frame update
    void Start()
    {
        tongue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(King.waveNum == 4)
        {
            GetComponent<DiaTrigger>().TriggerDialogue();
            tongue.SetActive(true);
        }
    }
}
