using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public void baccc ()
    {
         Debug.Log("Button Clicked!");
        SceneManager.LoadSceneAsync(0);
    }
}
