using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twening : MonoBehaviour
{
    public GrowScript GS;
    int waitingTime = 2;
    

    public float shootReq;
    public float bigReq;
    public float treeReq;
    public float houseReq;
    public float rokcReq;
    public float doorReq;

    public bool consumeShoot = false;
    public bool consumeBig = false;
    public bool consumeVeggies = false;
    public bool consumeHouse = false;
    public bool consumeRcok = false;
    public bool consumeDoor = false;

    public GameObject bigBoy;
    public GameObject shooty;
    public GameObject tree;
    public GameObject house;
    public GameObject rok;
    public GameObject door;

    void Start()
    {
     consumeShoot = false;
     consumeBig = false;
     consumeVeggies = false;
     consumeHouse = false;
     consumeRcok = false;
     consumeDoor = false;

     transform.localScale = Vector2.zero;
        bigBoy.SetActive(false);
        shooty.SetActive(false);
        tree.SetActive(false);
        house.SetActive(false);
        rok.SetActive(false);
        door.SetActive(false);
    }

    private void Update()
    {
        if (GS.currentSize >= shootReq & consumeShoot == false)
        {
            StartCoroutine(Bubbletwo());
            consumeShoot = true;
        }
            //Debug.Log(string.Format("size = {0}", GS.currentSize));
            
        if (GS.currentSize >= bigReq & consumeBig == false)
        {
            StartCoroutine(BubbleOne());
            consumeBig = true;
        }
        if (GS.currentSize >= treeReq & consumeVeggies == false)
        {
            StartCoroutine(Bubblethree());
            consumeVeggies = true;
        }
        if (GS.currentSize >= houseReq & consumeHouse == false)
        {
            StartCoroutine(Bubblefour());
            consumeHouse = true;
        }
        if (GS.currentSize >= rokcReq & consumeRcok == false)
        {
            StartCoroutine(Bubblefive());
            consumeRcok = true;
        }
        if (GS.currentSize >= doorReq & consumeDoor == false)
        {
            StartCoroutine(Bubblesix());
            consumeDoor = true;
        }
    }

    IEnumerator BubbleOne()
    {
        bigBoy.SetActive(true);
        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
        bigBoy.SetActive(false);
    }
    IEnumerator Bubbletwo()
    {
        shooty.SetActive(true);
        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
        shooty.SetActive(false);
    }
    IEnumerator Bubblethree()
    {
        tree.SetActive(true);
        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
        tree.SetActive(false);
    }
    IEnumerator Bubblefour()
    {
        house.SetActive(true);
        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
        house.SetActive(false);
    }
    IEnumerator Bubblefive()
    {
        rok.SetActive(true);
        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
        rok.SetActive(false);
    }
    IEnumerator Bubblesix()
    {
        door.SetActive(true);
        transform.LeanScale(new Vector2(1.5f, 1.5f), 0.8f).setEaseOutCubic();
        yield return new WaitForSeconds(waitingTime);
        transform.LeanScale(Vector2.zero, 0.8f).setEaseOutCubic();
        door.SetActive(false);
    }
}
