using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class WolfEscapeState : StateMachineBehaviour
{
    NavMeshAgent agent;
    RaycastHit hit;
    Vector3 origin;
    Vector3 WolfTargetPoint;
    bool isHit;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 10f;
        

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(WolfTargetPoint);


        if (isHit == false)
        {
            origin = agent.transform.position + new Vector3(Random.RandomRange(1, 10), 5, Random.RandomRange(1, 10));

            if (Physics.Raycast(origin, Vector3.down, out hit, 6, LayerMask.GetMask("Ground")))
            {
                WolfTargetPoint = hit.point;
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
