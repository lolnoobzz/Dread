using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clicksound : MonoBehaviour
{
    public Button yourButton; 
    public AudioClip clickSound; 
    private AudioSource audioSource;
    void Start()
    {
         audioSource = GetComponent<AudioSource>();

       
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
