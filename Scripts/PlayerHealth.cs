using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth = 100f;
    public float health;
    public AudioSource hurt, walk;
    public CharacterController characterController;


   
    void Start()
    {
        health = maxhealth;                 
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            PlayFootstepSound();
        }
        else
        {
            walk.Stop();
        }

    
    }

     void PlayFootstepSound()
    {
        if (!walk.isPlaying)
        {
            walk.Play();
        }
    }

    public void takedamage(float damage)
    {
        health -= damage;
        hurt.Play();
    }

    public void healing (float heal)
    {
        health += heal;
        if(health > maxhealth)
        {
           health = maxhealth;
        }
    }

    
}
