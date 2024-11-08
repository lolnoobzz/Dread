using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class car : MonoBehaviour
{
    public GameObject gas_ground, intImage,gas_hand, crosshair;
    public AudioSource pickupsound;
    public Slider gasbar;
    private bool isfilling = false;
    public float fillspeed = 1.0f;
    public float maxgasamount = 100.0f;
    public float currentgasamount = 0.0f;
    private AudioSource fillinggas;
    public PlayableDirector endgamecutscene;
    public TMP_Text endText;
    public GameObject player,ui; 
    public Camera cutsceneCamera;
    
    
    private void Start ()
    {
        gasbar.minValue = 0.0f;
        gasbar.maxValue = maxgasamount;
        gasbar.value = currentgasamount;
        fillinggas = GetComponent<AudioSource>();
    }

    private void Update ()
    {
        if (isfilling)
        {
            fillgasbar();
            isfilling = true;
        }
    }    
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !isfilling && !gas_ground.activeSelf && gas_hand.activeSelf)
        {
           intImage.SetActive(true);
           crosshair.SetActive(false);
           if(Input.GetKeyDown(KeyCode.E))
           {
            intImage.SetActive(false);
            gasbar.gameObject.SetActive(true);
            isfilling = true;
            fillinggas.Play();
           }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isfilling = false;
            intImage.SetActive(false);
            crosshair.SetActive(true);
            gasbar.gameObject.SetActive(false);
            fillinggas.Stop();
        }
    }

    void fillgasbar ()
    {
        currentgasamount += fillspeed * Time.deltaTime;
        currentgasamount = Mathf.Clamp(currentgasamount, 0.0f, maxgasamount);
        gasbar.value = currentgasamount;
    

        if (currentgasamount >= maxgasamount)
        {
            isfilling = false;
            intImage.SetActive(false);
            gasbar.gameObject.SetActive(false);
            player.SetActive(false);
            cutsceneCamera.enabled = true;
            endgamecutscene.Play();
            endText.gameObject.SetActive(true);
            ui.SetActive(false);
            fillinggas.Stop();
            StartCoroutine(ReturnToMainMenu());
        }
    }

     private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(8.5f); 

        SceneManager.LoadSceneAsync(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
    }

}

