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
    bool isRotate;
    bool oneTimeSetRotate;
    bool isRoarTrigger;
    Quaternion target;
    float distance2;
    Guardian guardian;
    
 

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rabbit = player.GetComponent<Rabbit>();
        agent.speed = 5f;
        guardian= player.GetComponent<Guardian>();

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
            if (distance < 15f)
            {
                isRoarTrigger = true;

            }
            if (isRoarTrigger == true)
            {
                if (!oneTimeSetRotate)
                {
                    agent.isStopped= true;
                    target = Quaternion.LookRotation((player.position - agent.transform.position) , Vector3.up); //bakýþ yeri
                    target = Quaternion.Euler(0,target.eulerAngles.y,0); //

                    isRotate = true;
                    oneTimeSetRotate= true;
                }

                if (isRotate)
                {
                    agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, target, 125 * Time.deltaTime);
                }

                if (CheckRotation() && isRotate)
                {
                    animator.SetBool("isChase", true);
                    animator.SetBool("isPatroll", false);
                    isRoarTrigger = false;   //Attack daha sonra bir defa daha çalýþacaðý için buralarý da false oldu
                    isRotate = false; //Attack daha sonra bir defa daha çalýþacaðý için buralarý da false oldu
                    oneTimeSetRotate = false; //Attack daha sonra bir defa daha çalýþacaðý için buralarý da false oldu
                }

            }
        }

       
   
    }

    public bool CheckRotation()
    {
        return Mathf.Approximately(Mathf.Abs(Quaternion.Dot(agent.transform.rotation, target)), 1f); //2 rotasyonun eþit olup olmadýðýný sorguluyor 
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
