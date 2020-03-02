using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Boss_Attack : StateMachineBehaviour
{
    public float speed = 10f;

    Transform player;
    Rigidbody boss_rb;
    Charge_Handler ch;
    int attacks;
    bool collided;
    bool exit_color = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss_rb = animator.GetComponent<Rigidbody>();
        ch = GameObject.Find("Sphere").GetComponent<Charge_Handler>();
        attacks = ch.attacks;
        if (attacks < 3)
        {
            Vector3 target = new Vector3(player.position.x, boss_rb.position.y, player.position.z);
            Vector3 dir = target - boss_rb.position;
            dir = dir.normalized;
            boss_rb.velocity = dir * speed; 
            ch.IncAtt();
        }
        else
        {
            animator.SetTrigger("Exit_Color");
            ch.Reset();
            exit_color = true;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        collided = ch.collided;
        if(collided){
            boss_rb.velocity = new Vector3(0,0,0);
            animator.SetTrigger("Spray");
            ch.ResetCollider();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (exit_color)
        {
            animator.ResetTrigger("Exit_Color");
            //animator.ResetTrigger("Spray");
        }
        else
        {
            animator.ResetTrigger("Spray");
            //animator.ResetTrigger("Exit_Color");
        }
    }

}
