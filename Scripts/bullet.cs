using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 15;

    void Awake ()
    {
        Destroy(gameObject,life);
    }

    void  OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("destroyable"))
        {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        }
    }
}
