using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void MaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void Health(float health)
    {
        slider.value = health;
    }    
}
