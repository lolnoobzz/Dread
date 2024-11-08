using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject crosshairs, ebutton, paused, optionpanel,gameover;

    void Start ()
    {
        optionpanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            crosshairs.SetActive(false);
            ebutton.SetActive(false);
            paused.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        if(!paused.activeSelf && !gameover.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
