using UnityEngine;

public class switching : MonoBehaviour
{
    public int selecteditem = 0;
    private bool itempickup = false;
    public GameObject gun_hand, gas_hand,medkit_hand, gas_ground;
    public AudioSource gunsound;


    void Start()
    {
        selectItem();
    }

    void Update()
    {
        int previousselecteditem = selecteditem;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selecteditem >= transform.childCount - 1)
             selecteditem = 0;
            else
            selecteditem++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selecteditem <= 0)
            selecteditem = transform.childCount - 1;
            else
            selecteditem--;
        }
         if (Input.GetAxis("Mouse ScrollWheel") == 1f)
         {
             gunsound.Play();
         }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selecteditem = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selecteditem = 1;
            gunsound.Play();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selecteditem = 2;
        }
         if(Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selecteditem = 3;
        }

        if(previousselecteditem != selecteditem)
        {
            selectItem();
        }

        if (gun_hand.activeSelf || gas_hand.activeSelf || medkit_hand.activeSelf)
        {
            itempickup = true;
        }
        if (selecteditem == 3 && !gas_ground.activeSelf)
        {
            gas_hand.SetActive(true);
        }
        else
        {
            gas_hand.SetActive(false);
        }

    }

    void selectItem ()
    {
        int i = 0;
        foreach (Transform item in transform)
        {
           
            if (i == selecteditem && itempickup == true)
                    item.gameObject.SetActive(true);
                
                else
                item.gameObject.SetActive(false);
             i++;
        }
        
    }
}
