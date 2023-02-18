using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour
{
    public bool isAlive;
    public Animator wolfAnimator;
    

    private void Start()
    {
        isAlive = true;
        
    }

    public void deadFinished ()
    {
        wolfAnimator.SetBool("isEating",true);
        wolfAnimator.SetBool("isPatroll",false);
        wolfAnimator.SetBool("isChase",false);
    }



}
