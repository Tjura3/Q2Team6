using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBeanEnterScript : MonoBehaviour
{
    HouseScript houseScript;
    // Start is called before the first frame update
    void Start()
    {
        houseScript = transform.parent.GetComponent<HouseScript>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        houseScript.BeanEnter(collision);
    }
}
