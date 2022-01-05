using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeanBar : MonoBehaviour
{
    public Slider slider;
    public Gradient BarColor;
    public Image fill;
    
    public void SetStartBeans(int beans)
    {

        slider.maxValue = 200;
        slider.value = beans;
        fill.color = BarColor.Evaluate(0);
    }

    public void SetBeans(int beans)
    {      
        slider.value = beans;
        fill.color = BarColor.Evaluate(slider.normalizedValue);
    }
}
