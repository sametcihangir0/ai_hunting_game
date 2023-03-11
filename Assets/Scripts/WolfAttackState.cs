using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WolfAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    float distance;
    Vector3 rabbitRotatePosition;
    Rabbit rabbit;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.isStopped= true;
        rabbit = GameObject.FindGameObjectWithTag("Player").GetComponent<Rabbit>();
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

        rabbitRotatePosition = rabbit.agent.transform.position - animator.transform.position; //yön aldýk
        Quaternion quaternion = Quaternion.LookRotation(rabbitRotatePosition,Vector3.up);  


        agent.updateRotation = false;
        agent.transform.rotation = quaternion;  
  
           
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.updateRotation = true;
        agent.isStopped = false;
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
