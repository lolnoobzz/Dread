using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dieeeee : MonoBehaviour
{
    public GameObject gameoverpanel, crosshair, paused;
    public Slider hpslider;
  

    void Start()
    {
        gameoverpanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (hpslider.value <= 0)
        {
            GameOver();
        }
        if (!gameoverpanel.activeSelf && !paused.activeSelf)
        {
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Locked;
         Time.timeScale = 1;
        }
    }
    

    public void GameOver()
    {
        gameoverpanel.SetActive(true);
        crosshair.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.01f;
    }
}