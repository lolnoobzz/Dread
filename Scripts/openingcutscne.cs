using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class openingcutscene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Camera cutsceneCamera;
    public Camera playerCamera;
    public GameObject gameplayElements, ui, ammo, z1, z2, z3, z4, z5, z6;
    public float delayBeforeTransition = 5.0f;
    private AudioSource beep;
    public TMP_Text tutorial, skip;
    public float displaytime = 20f;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
        beep = GetComponent<AudioSource>();
        videoPlayer.loopPointReached += OnVideoFinished;

        
        cutsceneCamera.enabled = true;
        playerCamera.enabled = false;
        ui.SetActive(false);
        ammo.SetActive(false);
        z1.SetActive(false);
        z2.SetActive(false);
        z3.SetActive(false);
        z4.SetActive(false);
        z5.SetActive(false);
        z6.SetActive(false);
        tutorial.gameObject.SetActive(false);

       
        videoPlayer.Play();
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            cutsceneCamera.enabled = false;
            playerCamera.enabled = true;
            ui.SetActive(true);
            ammo.SetActive(false);
            beep.Stop();
            skip.gameObject.SetActive(false);
            videoPlayer.Stop();
            Invoke("show", 0f);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        
        vp.loopPointReached -= OnVideoFinished;

        beep.Play();
        Invoke("SwitchToPlayerCamera", delayBeforeTransition);
    }

    void SwitchToPlayerCamera()
    {
        
        if (cutsceneCamera != null && playerCamera != null)
        {
            cutsceneCamera.enabled = false;
            playerCamera.enabled = true;
            ui.SetActive(true);
            ammo.SetActive(false);
            beep.Stop();
           

        }

        gameObject.SetActive(false);

        
        if (gameplayElements != null)
        {
            gameplayElements.SetActive(true);
        }

        Invoke("show", 0f);
    }

    void show ()
    {
        tutorial.gameObject.SetActive(true);

        Invoke("hide", 20f);
    }

    void hide ()
    {
         tutorial.gameObject.SetActive(false);
    }

}
