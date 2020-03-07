using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HomingBullet : MonoBehaviour
{
    Vector3 force;
    //public NavMeshAgent agent;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        gameObject.GetComponent<Rigidbody>().velocity = (((target.transform.position - transform.position).normalized * 15));
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(target.transform.position.y - transform.position.y) < 5)
        {
            force = (target.transform.position - transform.position).normalized;
            force.y = 0;
            //agent.SetDestination(target.transform.position);
           
        }
        gameObject.GetComponent<Rigidbody>().AddForce((force * 15 - gameObject.GetComponent<Rigidbody>().velocity) * 5f);

    }
}
