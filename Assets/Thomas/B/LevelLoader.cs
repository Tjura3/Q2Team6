using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public LevelLoader Sussysixtynineing;
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            
            LoadNextLevel();
        }
    }
    public void Wackystacks()
    {
        Sussysixtynineing.LoadNextLevel();
    }


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

}
