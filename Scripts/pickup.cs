using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject intImage, gun_table, gun_hand, crosshair,medkit_hand, ammo_icon;
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

    private void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {                                                                                                                                                               
                intImage.SetActive(false);
                interactable = false;
                pickupsound.Play();
                gun_hand.SetActive(true);
                gun_table.SetActive(false);
                medkit_hand.SetActive(false);
                crosshair.SetActive(true);
                ammo_icon.SetActive(true);
            
            }           
        }
    }

}
    