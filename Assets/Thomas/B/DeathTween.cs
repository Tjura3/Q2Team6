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
    public void deathTween()
    {
        StartCoroutine(DT());
    }
    IEnumerator DT()
    {
       
        transform.LeanScale(Vector2.one, 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Death");
    }
}
