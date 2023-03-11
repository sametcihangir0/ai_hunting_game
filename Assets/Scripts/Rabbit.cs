using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour
{
    public bool isAlive;
    public Animator wolfAnimator;
    public int HP = 60;
    public Animator RabbitAnimator;
    public NavMeshAgent agent;
    

    private void Start()
    {
        isAlive = true;
        
    }

    public void deadFinished ()
    {
        isAlive = false;
        wolfAnimator.SetBool("isPatroll",false);
        wolfAnimator.SetBool("isChase",false);
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            isAlive = false;
            RabbitAnimator.SetBool("isDead", true);
            RabbitAnimator.SetBool("isPatroll", false);
        }
        else
        {
            
        }
    }



}
