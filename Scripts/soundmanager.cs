using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundmanager : MonoBehaviour
{
    public Slider volumeslider;
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
            load();
        }
        else
        {
            load();
        }
    }

    public void changevolume ()
    {
        AudioListener.volume = volumeslider.value;
        save();
    }

    private void load ()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicvolume");
    }

    private void save ()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeslider.value);
    }
   
}
