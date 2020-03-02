using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Spray : StateMachineBehaviour
{
    public int bullets = 10;
    public float spray_range = 12f;
    public GameObject bullet;
    public float bullet_speed = 10f;
    public float recoil_time = 0.5f;

    float lastFired = 0;
    Transform player;
    Rigidbody boss_rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss_rb = animator.GetComponent<Rigidbody>();
        Fire();
        animator.SetTrigger("Exit_Spray");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Exit_Spray");
    }


    void Fire()
    {
        float step = 2 * Mathf.PI / bullets;
        float pos = step;
        for (int i = 0; i < bullets; i++)
        {
            Vector3 direction = new Vector3(Mathf.Cos(pos), 0, Mathf.Sin(pos));
            Vector3 start = boss_rb.position + 2.5f * direction;
            start.y = 0.6f; //typical height of the player - half height
            var active_bullet = Instantiate(bullet, start, Quaternion.identity);
            active_bullet.GetComponent<Rigidbody>().velocity = direction * bullet_speed;
            pos += step;
        }
    }
}

