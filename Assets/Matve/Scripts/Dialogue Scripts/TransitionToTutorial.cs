using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToTutorial : MonoBehaviour
{
    public Transform spinny;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spinny.localScale.x >= 57 && spinny.localScale.y >= 57)
        {
            //Debug.Log("transition");
            SFXManager.PlaySound("transition");
            TutorialNext();
        }
    }

    public void TutorialNext()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
