using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAttackState : StateMachineBehaviour
{
    Transform player;
    Animator RabbitAnimator;
    Rabbit rabbit;
    NavMeshAgent agent;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RabbitAnimator = player.GetComponent<Animator>();
        rabbit = player.GetComponent<Rabbit>();
        agent = player.GetComponent<NavMeshAgent>();
        RabbitAnimator.SetBool("isPatroll", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
