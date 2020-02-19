using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float spray_range = 12f;
    bool run = false;
    bool flop = false;
    Transform player;
    Rigidbody boss_rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss_rb = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(player.position, boss_rb.position) <= 12)
        { run = true; }
        if (run && Vector3.Distance(player.position, boss_rb.position) <= 20)
        {
            Vector3 target = new Vector3(player.position.x, boss_rb.position.y, player.position.z);
            Vector3 newPos = Vector3.MoveTowards(boss_rb.position, target, speed * Time.fixedDeltaTime);
            boss_rb.MovePosition(newPos);

            if (Vector3.Distance(player.position, boss_rb.position) <= spray_range)
            {
                animator.SetTrigger("Spray");

            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Spray");
    }
    
}
