using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : StateMachineBehaviour
{
    public float attackrange = 0.1f;
    public float attackcooldown = 1f;
    private float isattacktime;
    private Transform player;
    private Animator animator;
    public float damage;
    public GameObject Player;
     private attackhandler attackHandler;
     private bool isAttacking;
     public AudioClip audioclip;
     private AudioSource zombieattack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackHandler = animator.GetComponent<attackhandler>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        zombieattack = animator.GetComponent<AudioSource>();
        zombieattack.clip = audioclip;
         if (Time.time - isattacktime >= attackcooldown)
        {
            animator.SetBool("ischasing", true);
            isAttacking = false;
            animator.ResetTrigger("isattacking");
            Debug.Log("Switching to Chase State");
        }

         if (CanAttack())
        {
            isAttacking = true;
            animator.SetBool("isnotattacking", false);
            animator.SetTrigger("isattacking"); 
            isattacktime = Time.time; 
            zombieattack.Play();
            attackHandler.AttackPlayer(20);
            Debug.Log("Attacking Player");
    }
        }
         
    
    bool CanAttack()
    {
        bool canAttack = Time.time - isattacktime >= attackcooldown && player != null &&
        Vector3.Distance(animator.transform.position, player.position) <= attackrange;
        if (canAttack)
        {   
        Debug.Log("CanAttack: True");
        }   

        return canAttack;

   
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isAttacking)
        {
        animator.SetBool("isnotattacking", true);
        animator.ResetTrigger("isattacking");
        Debug.Log("Exiting Attacking State");
        }
    }

     void OnAttackHit()
    {
        Debug.Log("Attack hit!");
        AttackPlayer();
        animator.ResetTrigger("isattacking");
    }


     void AttackPlayer()
    {
        
    if (attackHandler != null)
    {
      attackHandler.AttackPlayer(damage);
    }
    }

}
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
    
