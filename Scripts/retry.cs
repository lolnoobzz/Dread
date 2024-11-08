using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{

    // Update is called once per frame
    public void level1 ()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
