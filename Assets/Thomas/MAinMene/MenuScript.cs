using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public LevelLoader LL;
    public void PlayGame()
    {
        LL.Play();
    }
    public void Quiit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
    public void Credits()
    {
        LL.Credits();
    }

    public void Hover()
    {
        SFXManager.PlaySound("hover");
    }

    public void Click()
    {
        SFXManager.PlaySound("click");
    }
}
