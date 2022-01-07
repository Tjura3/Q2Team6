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
    void Start()
    {
        
        transform.localScale = Vector2.zero;
        bigBoy.SetActive(false);
        shooty.SetActive(false);
    }

    private void Update()
    {
        if (GS.currentSize >= shootReq & consumeShoot == false)
        {
            Debug.Log("I AM RUNININGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
            StartCoroutine(Bubbletwo());
            consumeShoot = true;
        }
            //Debug.Log(string.Format("size = {0}", GS.currentSize));
            
        if (GS.currentSize >= bigReq & consumeBig == false)
        {
            StartCoroutine(BubbleOne());
            consumeBig = true;
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

}
