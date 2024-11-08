using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intImage;
    public bool interactable, toogle;
    public Animator doorAnim;
    public AudioSource open, close;
    public GameObject z1, z2, z3 ,z4 ,z5 ,z6;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intImage.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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
                toogle = !toogle;
                if (toogle == true)
                {
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open");
                    open.Play();
                    StartCoroutine(Zombiespawn());
                }

                if (toogle == false)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close");
                    close.Play();
                }
                intImage.SetActive(false);
                interactable = false;
            }
            
        }

        IEnumerator Zombiespawn()
        {
        yield return new WaitForSeconds(0.5f); 

        z1.SetActive(true);
        z2.SetActive(true);
        z3.SetActive(true);
        z4.SetActive(true);
        z5.SetActive(true);
        z6.SetActive(true);
        }    
    }
}
