using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject diaCurrentTrigger;
    GameObject player;
    Animator playerAnim;

    public Animator anim;

    private Queue<string> sentences;
    private Queue<string> names;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        anim.SetBool("isActive", true);

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
        Time.timeScale = 1;
        Destroy(diaCurrentTrigger);
        Debug.Log("End of conversation.");
        anim.SetBool("isActive", false);
    }
}
