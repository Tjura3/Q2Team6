using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScript : MonoBehaviour
{
    [SerializeField] float growSpeed;
    [SerializeField] float lerpGrowSpeed;
    [SerializeField] float startSize;
    public float currentSize;

    //Thomas Stuff
    public BeanBar Bbar;
    int StartBeans = 0;
    int currentBeans = 0;
    //Thomas Stuff End

    [SerializeField] CameraFollow cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        currentSize = startSize;
        try
        {
            Bbar.SetStartBeans(StartBeans);  //thomas again
        }catch(System.Exception e)
        {
            Debug.LogError("THERE IS NO BEAN BAR IN GAME YET. ADD THAT");
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow.cameraSize = currentSize * 3 + 10;

         

        //Debug.Log("cameraSize: " + cameraFollow.cameraSize);
        //Debug.Log("CurrentSize: " + currentSize);
        //Debug.Log("Lerp Val: " + Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, transform.localScale.y, 1), lerpGrowSpeed));
        if (transform.localScale.x < currentSize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentSize, currentSize, currentSize), lerpGrowSpeed);
        }

        if (transform.localScale.x >= currentSize)
        {
            transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            
        }
    }

    /// <summary>
    /// Will grow when you call this function                                        
    /// </summary>
    public void Eat(GameObject gameObject)
    {
        Destroy(gameObject);
        currentSize += growSpeed;
        Spawner.enemyNumber -= 1;
        currentBeans++;  //ThomasThing
        Bbar.SetBeans(currentBeans); //ThomasThing
        //Debug.Log("Enemies:" + Spawner.enemyNumber);
        Debug.Log("Munch");
    }

    [ContextMenu("Grow a Bit")]
    public void GrowABit()
    {
        currentSize += growSpeed;
    }
}
