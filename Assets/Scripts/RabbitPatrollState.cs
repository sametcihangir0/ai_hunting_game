using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RabbitPatrollState : StateMachineBehaviour
{
   
    NavMeshAgent agent;
    RaycastHit hit;
    public Vector3 RabbitTargetPoint;
    bool isHit;
    Vector3 origin;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        agent = animator.GetComponent<NavMeshAgent>();
        agent.isStopped= false;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent.SetDestination(RabbitTargetPoint);


        if (isHit == false)
        {
            origin = agent.transform.position + new Vector3(Random.RandomRange(1, 10), 5, Random.RandomRange(1, 10));

            if (Physics.Raycast(origin, Vector3.down, out hit, 6, LayerMask.GetMask("Ground")))
            {
                RabbitTargetPoint = hit.point;     
                isHit = true;
            }
        }
        
        
        if (isHit == true)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                isHit = false;
            }
            
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
