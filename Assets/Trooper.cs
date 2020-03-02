﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trooper : EnemyMind
{
    GameObject target;
    public NavMeshAgent agent;
    bool close;
    bool locked = false;
    RaycastHit hit;
    public GameObject bullet;
    private Animator anim;
    public float lead = 1;
    public int bullets;
    public float bulletSpeed;
    public bool confused = false;
    public GameObject point;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        active = false;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.speed == 0)
        { anim.SetBool("Idle", true); }
        
        if (!confused)
        {
            var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        }


        if (Mathf.Abs(target.transform.position.y - transform.position.y) > 10)
        {
            confused = true;
            }

        if (confused && Mathf.Abs(target.transform.position.y - transform.position.y) < 5)
        {
            StartCoroutine(Delay());
        }
        if (active && (Mathf.Abs(target.transform.position.y - transform.position.y) < 5) && !locked)
        {
            if (!confused)
            {
                agent.SetDestination(target.transform.position);
                anim.SetBool("Idle", false);
            }
            else
            {
                agent.SetDestination(transform.position);
                anim.SetBool("Idle", true);
            }

            close = CheckClose();
            if (close && !confused)
            {
                agent.SetDestination(transform.position);

                StartCoroutine(Firing());





            }
            else
                locked = false;
           

        }
    }

    void Fire()
    {
        float step =   90 / bullets;
        float pos = -45;
        for (int i = 0; i < bullets; i++)
        {
           
            Vector3 start = point.transform.position;
            start.y = 0.6f; //typical height of the player - half height
            var active_bullet = Instantiate(bullet, start, Quaternion.identity);
            active_bullet.GetComponent<Rigidbody>().velocity = (Quaternion.AngleAxis(pos, Vector3.up) *  (-transform.position+target.transform.position).normalized * 20);
            pos += step;

        }
    }


    bool CheckClose()
    {


        Vector3 origin = transform.position;
        origin.y = 1;
        var rayDirection = target.transform.position - transform.position;
        rayDirection.y = 0;


        if (Physics.Raycast(origin, rayDirection, out hit, 5f))
        {

            if (hit.transform.gameObject == target)
            {

                //Vector3 distance = t1.position - origin.position;
                //float length = Mathf.Abs(distance.magnitude);
                locked = true;
                return true;
            }
        }
       

        return false;
    }
    IEnumerator Delay()
    { yield return new WaitForSeconds(1);
        confused = false;
      
    }
    
        IEnumerator Firing()
    {

        anim.SetBool("Idle", true);
        yield return new WaitForSeconds(.5F);
       
        Fire();
      
        anim.SetBool("Idle", false);




        locked = false;


    }
}