using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupmedkit : MonoBehaviour
{
    public GameObject intImage, medkit_table, medkit_hand, gun_hand;
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
                medkit_hand.SetActive(true);
                medkit_table.SetActive(false);
                gun_hand.SetActive(false);
            
            }           
        }
    }

}
    