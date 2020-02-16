using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spray : StateMachineBehaviour
{
    public float spray_range = 12f;

    Transform player;
    Rigidbody boss_rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss_rb = animator.GetComponent<Rigidbody>();
        if (Vector3.Distance(player.position, boss_rb.position) > spray_range)
        {
            animator.SetTrigger("Exit_Spray");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Exit_Spray");
    }

}
