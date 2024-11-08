using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackhandler : MonoBehaviour
{
    public void OnAttackHit()
    {
        Debug.Log("Attack hit!");
        
    }

    public void AttackPlayer(float damage)
    {
       
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.takedamage(damage);
        }
    }
}