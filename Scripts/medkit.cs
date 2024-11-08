using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float heal;
    public int usage = 3;
    public GameObject gameobject;
    public AudioSource heals;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerHealth.health < playerHealth.maxhealth && usage > 0)
        {
            heals.Play();
            playerHealth.healing(heal);
            usage--;
        }
        else if (usage == 0)
        {
            gameobject.SetActive(false);
        }
    }  
}
