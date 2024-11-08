using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objective : MonoBehaviour
{
    public TMP_Text objectiveslashed1, objectiveslashed2,objectiveslashed3;
    public GameObject objectivepanel,gun_table, medkit_table, gas_ground;
    public Slider gasbar;
    // Start is called before the first frame update
    void Start()
    {
        objectivepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Tab))
         {
            Toggleobjectivepanel();
         }

         if (!gun_table.activeSelf && !medkit_table.activeSelf)
         {
            objectiveslashed1.gameObject.SetActive(true);
         }
         if (!gas_ground.activeSelf)
         {
            objectiveslashed2.gameObject.SetActive(true);
         }
         if(gasbar.value == 100)
         {
            objectiveslashed3.gameObject.SetActive(true);
         }
    }   

    void  Toggleobjectivepanel()
    {
        objectivepanel.SetActive(!objectivepanel.activeSelf);
    }
}
