using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    Animator anim;

    public static int waveNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("StartWave", false);
    }

    IEnumerator flip()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("StartWave", true);
        yield return new WaitForSeconds(0);
        anim.SetBool("StartWave", false);
        waveNum++;

        yield return new WaitForSeconds(6);
        if (waveNum == 1)
        {
            SpinnerSpawner.spinnerNumber = 2;
            waveNum++;
        }

        yield return new WaitForSeconds(6);
        anim.SetBool("StartWave", true);
        yield return new WaitForSeconds(0);
        anim.SetBool("StartWave", false);
        yield return new WaitForSeconds(7);
        if (waveNum == 2)
        {
            SpinnerSpawner.spinnerNumber = 5;
            waveNum++;
        }

        yield return new WaitForSeconds(9);
        anim.SetBool("StartWave", true);
        yield return new WaitForSeconds(0);
        anim.SetBool("StartWave", false);
        yield return new WaitForSeconds(7);
        if (waveNum == 3)
        {
            SpinnerSpawner.spinnerNumber = 11;
        }
        yield return new WaitForSeconds(8);
        waveNum++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            StartCoroutine(flip());
        }
    }
}