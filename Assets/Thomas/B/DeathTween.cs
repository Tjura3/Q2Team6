using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTween : MonoBehaviour
{
    
    private void Start()
    {
        transform.localScale = Vector2.zero;
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            deathTween();
        }
    }
    */
    public void deathTween()
    {
        StartCoroutine(DT());
    }
    IEnumerator DT()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        transform.LeanScale(new Vector2(2, 2), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Death");
    }
}
