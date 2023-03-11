using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    public Animator RabbitAnimator;
    public Rabbit rabbit;
    public int damageAmount = 20;
    public NavMeshAgent agent;
    public float distance;
    public Animator WolfAnimator;
    public float timer = 0;
    public Animator GuardianAnimator;
    bool isRotate;
    bool oneTimeSetRotate;
    bool isEatTrigger;
    Quaternion target;
    float distance2;
    Guardian guardian;
    public Transform CurrentTarget;
    public bool first;



    private void Start()
    {
        
    }

    public void Update()
    {
      
    }



    public void chaseControl()
    {
        distance = Vector3.Distance(agent.transform.position, rabbit.transform.position);
        
        if (distance > 0.5f)    // ATTACKDA ENTERDA NAVMESHI KAPATTIÐIMIZ ÝÇÝN BURDA DÝSTANCE'DAN KONTROL ETTÝK .
        {
            WolfAnimator.SetBool("isAttack", false);
            WolfAnimator.SetBool("isChase", true);
            first = false; 
        }

        
        if (rabbit.isAlive == false)
        {


            WolfAnimator.SetBool("isEating", true);
            if (WolfAnimator.GetBool("isEating"))
            {
                
            }

        }

    }



    public void damageControl ()
    {
        distance = Vector3.Distance(agent.transform.position, rabbit.transform.position);

        if (distance < 3f) //Attack animasyonu bittikten sonra kalan mesafe 2.1f den küçükse damage'ini al .
        {
            rabbit.TakeDamage(damageAmount);
        }

    }

    public void guardianChaseSet()
    {
        if (WolfAnimator.GetBool("isChase"))
        {
            GuardianAnimator.SetBool("isChase", true);

        }
    }
}
