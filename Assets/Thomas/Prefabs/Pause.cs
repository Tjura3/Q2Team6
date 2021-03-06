using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    public LevelLoader LL;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Trying to do thing");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paus();
            }

        }
       
    }
   
    public void Resume()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Paus()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void quitgame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void loadmenu()
    {
        Debug.Log("Menu");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        LL.LoadMainMenu();
    }
    public void Sloadmenu()
    {
        Debug.Log("Menu");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }




}
