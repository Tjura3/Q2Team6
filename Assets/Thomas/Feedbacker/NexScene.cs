﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NexScene : MonoBehaviour
{


    // Update is called once per frame
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
        Debug.Log("bruh");
            if (collision.gameObject.tag == "Player")
            {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    
}
