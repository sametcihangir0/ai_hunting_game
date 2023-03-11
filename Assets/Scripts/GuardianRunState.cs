using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardianRunState : StateMachineBehaviour
{
    NavMeshAgent agent;
    RaycastHit hit;
    Vector3 origin;
    Vector3 GuardianTargetPoint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent.SetDestination(GuardianTargetPoint);


        origin = agent.transform.position + new Vector3(1,3);
        if (Physics.Raycast(origin,Vector3.down,out hit , 4 , LayerMask.GetMask("Ground")))
        {
            
            GuardianTargetPoint = hit.point;
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
