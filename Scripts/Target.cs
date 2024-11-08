
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Animator animator;
    public AudioSource dead;
    public void takedamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            dead.Play();
        }
    }
    void Die()
    {
        if(animator != null)
        {
            animator.SetTrigger("die");
        }
            
        
    }
}
