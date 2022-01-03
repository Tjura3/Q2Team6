using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeanBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetStartBeans(int beans)
    {

        slider.maxValue = 200;
        slider.value = beans;
    }

    public void SetBeans(int beans)
    {
        
        slider.value = beans;
    }
}
