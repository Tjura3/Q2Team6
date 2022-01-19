using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPchange : MonoBehaviour
{
    public Twening tweeeen;
    healthSystem HS;
    int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        HS = GetComponent<healthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tweeeen.consumeShoot && stage == 0)
        {
            HS.maxHealth = 125;
            HS.healthPoints = HS.maxHealth;
            stage += 1;
        }
        if (tweeeen.consumeHouse && stage == 1)
        {
            HS.maxHealth = 150;
            HS.healthPoints = HS.maxHealth;
            stage += 1;
        }
        if (tweeeen.consumeVeggies && stage == 2)
        {
            HS.maxHealth = 175;
            HS.healthPoints = HS.maxHealth;
            stage += 1;
        }
        if (tweeeen.consumeBig && stage == 3)
        {
            HS.maxHealth = 200;
            HS.healthPoints = HS.maxHealth;
            stage += 1;
        }
        if (tweeeen.consumeRcok && stage == 4)
        {
            HS.maxHealth = 225;
            HS.healthPoints = HS.maxHealth;
            stage += 1;
        }
        if (tweeeen.consumeDoor && stage == 5)
        {
            HS.maxHealth = 250;
            HS.healthPoints = HS.maxHealth;
            stage += 1;
        }
    }
}
