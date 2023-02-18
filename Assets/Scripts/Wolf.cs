using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public Animator RabbitAnimator;
    public Rabbit rabbit;

    private void Start()
    {
            
    }

    public void set()
    {
        RabbitAnimator.SetBool("isDead", true);
        RabbitAnimator.SetBool("isPatroll", false);
        rabbit.isAlive = false;
    }
}
