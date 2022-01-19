using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    
    
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    
   

    public void LoadNextLevel()
    { 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));  
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Anim
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMenu());
    }
    IEnumerator LoadMenu()
    {
        //Anim
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load
        SceneManager.LoadScene("Menu");
    }


    public void Play()
    {
        StartCoroutine(PlayGame());
    }
    IEnumerator PlayGame()
    {
        Debug.Log("transition");
        SFXManager.PlaySound("transition");
        //Anim
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load
        //SceneManager.LoadScene("Pause!");
        SceneManager.LoadScene("IntroScene");
    }



    public void Credits()
    {
        StartCoroutine(OpenCredits());
    }
    IEnumerator OpenCredits()
    {
        //Anim
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load
        SceneManager.LoadScene("SimpleCredits");
    }





/*    death
    public void deathStart()
    {
        
        StartCoroutine(deathone());
    }
    IEnumerator deathone()
    {
        //Anim
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load
        SceneManager.LoadScene("BET");
    }

  */  
    
}
