using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

    }

    public void setHealth (int health)
    {
        slider.value = health;
        Debug.Log("setHealth: " + slider.value.ToString());
        Debug.Log("slider Max: " + slider.maxValue.ToString());
    }
}
