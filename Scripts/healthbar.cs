using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Slider slider;

    public GameObject gameobject;
    public Image bar;
   
    void Start()
    {
       slider = GetComponent<Slider>();
       playerHealth.health = playerHealth.maxhealth;

    }

    // Update is called once per frame
    void Update()
    {
       if (slider.value <= slider.minValue)
       {
            bar.enabled = false;
       }
       if(slider.value > slider.minValue && !bar.enabled)
       {
            bar.enabled = true;
       }
       float fillValue = playerHealth.health;
       slider.value = fillValue;
    }

    public void takedamage(float damage)
    {
        playerHealth.health -= damage;
    }

    public void healing (float heal)
    {
        playerHealth.health += heal;
        if(playerHealth.health > playerHealth.maxhealth)
        {
           playerHealth.health = playerHealth.maxhealth;
        }
    }
}
