using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public bool animActive;
    float timer;
    float time = 0.6f;

    public GameObject diaCurrentTrigger;
    GameObject player;
    PlayerMovement PM;
    Animator playerAnim;

    public Animator anim;

    private Queue<string> sentences;
    private Queue<string> names;

    private void Start()
    {
        player = GameObject.Find("Player");
        PM = player.GetComponent<PlayerMovement>();

        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    private void Update()
    {
        if (animActive)
        {
            Time.timeScale = 0;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isActive", true);
        animActive = true;
        
        names.Clear();
        sentences.Clear();
        
        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    

    public void DisplayNextSentence()
    {
        
        if(sentences.Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
                return;
            }
        }
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        nameText.text = name;
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        PM.enabled = true;

        animActive = false;
        Time.timeScale = 1;
        Destroy(diaCurrentTrigger);
        Debug.Log("End of conversation.");
        anim.SetBool("isActive", false);
    }
}
