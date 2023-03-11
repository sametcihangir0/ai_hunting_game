using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class WolfChaseState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;
    float distance;
    Rabbit rabbit;
    bool isRotate;
    bool oneTimeSetRotate;
    bool isAttackTrigger;
    Quaternion target;
    Vector3 rabbitRotatePosition;
    Vector3 target2;
    Wolf wolf;
    


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rabbit = player.GetComponent<Rabbit>();
        agent.speed = 10f;
        agent.isStopped= false;
        wolf = animator.GetComponent<Wolf>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (rabbit.isAlive == true)
        {
            distance = Vector3.Distance(agent.transform.position, player.transform.position);
            if (distance > 30f)
            {
                animator.SetBool("isPatroll", true);
                animator.SetBool("isChase", false);

            }
            else
            {
                agent.SetDestination(player.transform.position);
            }

            if (agent.remainingDistance <= agent.stoppingDistance && wolf.first == false)
            {
                animator.SetBool("isAttack", true);
                animator.SetBool("isChase", false);
                wolf.first = true;
            }
      
        }
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isChase", false);

        }
    }

    

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
