using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guardian : MonoBehaviour
{
    public Animator wolfAnimator;
    public Animator guardianAnimator;
    Vector3 origin;
    Vector3 GuardianTargetPoint;
    RaycastHit hit;
    public NavMeshAgent agent;
    Wolf wolf;
    

    void Start()
    {
        
    }

    private void Update()
    {
        ChaseSet();


    }

    public void ChaseSet()
    {
        if (wolfAnimator.GetBool("isChase"))
        {
            guardianAnimator.SetBool("isChase", true);

        }
    }



}
