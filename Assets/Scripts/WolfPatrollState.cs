using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class WolfPatrollState : StateMachineBehaviour
{
    NavMeshAgent agent;
    RaycastHit hit;
    Vector3 origin;
    Vector3 WolfTargetPoint;
    bool isHit;
    float distance;
    Transform player;
    Rabbit rabbit;
 

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rabbit = player.GetComponent<Rabbit>();
        agent.speed = 5f;
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



        if (rabbit.isAlive == true)
        {
            distance = Vector3.Distance(agent.transform.position, player.transform.position);
            if (distance < 10f)
            {
                animator.SetBool("isChase", true);
                animator.SetBool("isPatroll", false);

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
