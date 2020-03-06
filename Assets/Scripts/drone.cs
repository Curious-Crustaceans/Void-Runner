using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class drone : EnemyMind
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
       
        anim.SetFloat("velocity", agent.velocity.magnitude);

       
                if (active && (Mathf.Abs(target.transform.position.y - transform.position.y) < 5))
                {
                    agent.SetDestination(target.transform.position);
                    close = CheckClose();
                    if (close)
                    {

                        if (!locked)
                            StartCoroutine(Firing());





                    }
                    
               
        }
    }

    void Fire()
    {
        float step = 2 * Mathf.PI / bullets;
        float pos = step;
        for (int i = 0; i < bullets; i++)
        {
            Vector3 direction = new Vector3(Mathf.Cos(pos), 0, Mathf.Sin(pos));
            Vector3 start = transform.position + agent.velocity.normalized;
            start.y = 0.6f; //typical height of the player - half height
            var active_bullet = Instantiate(bullet, start, Quaternion.identity);
            active_bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed; ;
            pos += step;

        }
    }
    

    bool CheckClose()
    {


        Vector3 origin = transform.position;
        origin.y = 1;
        var rayDirection = target.transform.position - transform.position;
        rayDirection.y = 0;


        if (Physics.Raycast(origin, rayDirection, out hit, 8f))
        {

            if (hit.transform.gameObject == target)
            {

                //Vector3 distance = t1.position - origin.position;
                //float length = Mathf.Abs(distance.magnitude);
                return true;
            }
        }
        

        return false;
    }

    IEnumerator Firing()
    {
        locked = true;
        
       
              
                Vector3 direction = -transform.position + target.transform.position;
                direction.y = 0;
                Vector3 start = transform.position;
                start.y = 1.2f;
                direction = direction.normalized * 30;
                Fire();
                agent.speed = 8;
        yield return new WaitForSeconds(Random.Range(2, 4));
        locked = false;



    }
}
