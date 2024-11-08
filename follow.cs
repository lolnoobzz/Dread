using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : StateMachineBehaviour
{
    private Transform playerpos;
    public float speed;
    public float rotationspeed = 2f;
    public float fixedYPosition = 0f;
    public float attackrange = 0.3f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
         Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);

            if (distanceToPlayer < attackrange)
            {
                animator.SetTrigger("isattacking");
            }
            else
            {
                 animator.SetBool("ischasing", true);
            }
        }
        if (playerpos != null)
        {
            
            Vector3 targetPosition = new Vector3(playerpos.position.x, fixedYPosition, playerpos.position.z);
            
           
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, targetPosition, speed * Time.deltaTime);
    
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerpos.position, speed * Time.deltaTime);
        Vector3 direction = playerpos.position - animator.transform.position;
      animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationspeed);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
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
}
