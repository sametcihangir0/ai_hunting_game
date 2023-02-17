using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RabbitPatrollState : StateMachineBehaviour
{
    float timer;
    NavMeshAgent agent;
    RaycastHit hit;
    public Vector3 RabbitTargetPoint;
    bool isHit;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        agent = animator.GetComponent<NavMeshAgent>();
        
       
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatroll",false);
        }

        Vector3 origin;
        //tavþanýn konumuna ekstra pozisyon

        agent.SetDestination(RabbitTargetPoint);


        //out hit ile yukarýdaki raycaste baðlamýþ olduk .

        if (isHit == false)
        {
            origin = agent.transform.position + new Vector3(Random.RandomRange(1, 10), 5, Random.RandomRange(1, 10));

            if (Physics.Raycast(origin, Vector3.down, out hit, 6, LayerMask.GetMask("Ground")))
            {
                RabbitTargetPoint = hit.point;     //ýþýnýn dokunduðu noktayý bu deðiþkene atamýþ olduk 
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
