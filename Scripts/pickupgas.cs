using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupgas : MonoBehaviour
{
    public GameObject intImage, gas_ground, gas_hand,gun_hand, medkit_hand;
    public AudioSource pickupsound;
    public bool interactable;
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            intImage.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            intImage.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {                                                                                                                                                               
                intImage.SetActive(false);
                interactable = false;
                pickupsound.Play();
                gas_hand.SetActive(true);
                gas_ground.SetActive(false);
                gun_hand.SetActive(false);
                medkit_hand.SetActive(false);
                
            }           
        }
    }

}
    