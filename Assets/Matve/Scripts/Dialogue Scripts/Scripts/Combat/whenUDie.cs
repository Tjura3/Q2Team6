using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class whenUDie : MonoBehaviour
{
    public static Scene previousScene;
    public DeathTween DT;
    public GameObject gavinsTongue;
    
    Animator A;
    healthSystem HS;

    GrowScript GS;
    PlayerAttack PA;
    // Start is called before the first frame update
    void Start()
    {
        HS = GetComponent<healthSystem>();
        GS = GetComponent<GrowScript>();
        PA = GetComponent<PlayerAttack>();
        A = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HS.isDead)
        {
            GS.enabled = false;
            PA.enabled = false;
            A.enabled = false;
            gavinsTongue.SetActive(false);
            DT.deathTween();
            previousScene = SceneManager.GetActiveScene();
        }
    }
}
