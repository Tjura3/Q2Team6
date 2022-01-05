using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeanBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private Gradient BarColor;
    [SerializeField] private Image fill;
    [SerializeField] private int MaxVal;
    public void SetStartBeans(int beans)
    {

        slider.maxValue = MaxVal;
        slider.value = beans;
        fill.color = BarColor.Evaluate(0);
    }

    public void SetBeans(int beans)
    {      
        slider.value = beans;
        fill.color = BarColor.Evaluate(slider.normalizedValue);
    }
}
/*200 for door
 destroy rocks at 175
 house at 150
125 trees
100 for big bois
25 shooter
*/



