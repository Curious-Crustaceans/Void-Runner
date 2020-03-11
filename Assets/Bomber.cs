using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomber : EnemyMind
{
    public GameObject point;
    GameObject target;
    public NavMeshAgent agent;
    Animator anim;
    bool rotateToPlayer = false;
    bool rotateToDirection = false;
    Vector2 direction;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        active = false;
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(cycle());

    }

    // Update is called once per frame
    void Update()
    {
        if(rotateToDirection)
        { 
            
          var rotation = Quaternion.LookRotation(transform.position + new Vector3(direction.x, 0, direction.y) - transform.position);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);

        }
        if (rotateToPlayer)
        {

            var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);

        }

        


    }

    IEnumerator cycle()

    {
        while (true)
        {
            direction = Random.insideUnitCircle * 5;
            rotateToDirection = true;
            yield return new WaitForSeconds(.5f);
            rotateToDirection = false;
            anim.SetBool("Moving", true);
            


            yield return new WaitForSeconds(2f);
            anim.SetBool("Moving", false);
           
            
            yield return new WaitForSeconds(1f);
            rotateToPlayer = true;
            yield return new WaitForSeconds(.5f);
            rotateToPlayer = false;
            anim.SetTrigger("Attack1Trigger");
            yield return new WaitForSeconds(.5f);
            Instantiate(bullet, point.transform.position, Quaternion.identity);
           
            yield return new WaitForSeconds(1f);
        }
    }
}
