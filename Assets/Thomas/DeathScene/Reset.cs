using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    
    public CanvasGroup AlphaScale;
    public GameObject blackFade;

    public void Retry()
    {
        StartCoroutine(DarkTransR());
    }
    public void Menu()
    {
        StartCoroutine(DarkTrans());  
    }
    IEnumerator DarkTrans()
    {
        blackFade.SetActive(true);
        AlphaScale.LeanAlpha(1, 1.2f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator DarkTransR()
    {
        blackFade.SetActive(true);
        AlphaScale.LeanAlpha(1, 1.2f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(PreviousScene.previousSceneBuildIndex);
    }
}
