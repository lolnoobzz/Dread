using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : StateMachineBehaviour
{
    private patrolspots Patrol;
    public float speed;
    private int randomspot;
    public float rotationspeed = 2f;
    public float detectionDistance = 10f;
    public GameObject player;
    private float idleTimer = 0f;
    public float idleduration = 5f;
    private bool isidle = false;
    private AudioSource zombienormal;
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entering patrolling state");
        Patrol = GameObject.FindGameObjectWithTag("patrolspots").GetComponent<patrolspots>();
        if (Patrol != null && Patrol.patrolPoints != null && Patrol.patrolPoints.Length > 0)
        {
            randomspot = Random.Range(0, Patrol.patrolPoints.Length);
        }
        Patrol = GameObject.FindGameObjectWithTag("patrolspots").GetComponent<patrolspots>();
        randomspot = Random.Range(0, Patrol.patrolPoints.Length);

        player = GameObject.FindGameObjectWithTag("Player");
        isidle = false;
        idleTimer = 0f;

        zombienormal = animator.GetComponent<AudioSource>();
        if (zombienormal != null)
        {
            zombienormal.Play();
        }
   
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        Debug.Log("isidle: " + isidle);
        Debug.Log("idleTimer: " + idleTimer);
         if (isidle)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleduration)
            {
                idleTimer = 0f;
                isidle = false;
                SetRandomPatrolPoint(animator);
            }
        }
         else
        {
            float distanceToPatrolPoint = Vector3.Distance(animator.transform.position, Patrol.patrolPoints[randomspot].position);

            if (distanceToPatrolPoint > 0.2f)
            {
                
                Vector3 targetDirection = Patrol.patrolPoints[randomspot].position - animator.transform.position;
                targetDirection.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, targetRotation, Time.deltaTime * rotationspeed);
                animator.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if(!isidle)
            {
                
                isidle = true;
                animator.SetBool("isidle", true);
            }
        }

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.transform.position);

            if (distanceToPlayer <= detectionDistance)
            {
                animator.SetBool("ischasing", true);
                animator.SetInteger("ispatrolling", 1);
            }
        }
    }

    
    

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting patrolling state");
        animator.SetBool("isidle", false);
        if (zombienormal != null)
        {
            zombienormal.Stop();
        }
    }

    void SetRandomPatrolPoint(Animator animator)
    {
        randomspot = Random.Range(0, Patrol.patrolPoints.Length);
        animator.SetInteger("ispatrolling", randomspot);
    
    }
  
    
}
