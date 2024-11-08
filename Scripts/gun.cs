using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
     public float damage = 10f;
     public float range = 100f;
     public float firerate = 15f;
     public float impactForce = 30f;
     public Camera fpscam;
     public ParticleSystem muzzleflash;
     public GameObject enemyimpactEffect;
     private float nextTimetoFire = 0f;
     public int maxammo = 12;
     private int currentammo;
     public float reloadtime = 1.3f;
     private bool isreloading = false;
     public Animator animator;
     public AudioSource gunfire, gunreload;
     void Start()
     {
        currentammo = maxammo;
       
     }
 
    void Update()
    {
        if (isreloading)
        {
            return;
        }
        if (currentammo <= 0 || Input.GetKeyDown("r"))
        {
            StartCoroutine(reload());
            gunreload.Play();   
            return;
        }
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / firerate;
            shoot();
            gunfire.Play();
        }
    }

    IEnumerator reload ()
    {
        isreloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("reloading", true);

        yield return new WaitForSeconds(reloadtime - .25f);
         animator.SetBool("reloading", false);
        yield return new WaitForSeconds(.25f);
        currentammo = maxammo;
        isreloading = false;
    }
    void shoot()
    {
        muzzleflash.Play();

        currentammo--;
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.takedamage(damage);
                Instantiate(enemyimpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            
        }
    }    
}