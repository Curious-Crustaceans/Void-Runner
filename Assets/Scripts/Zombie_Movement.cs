using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Movement : MonoBehaviour
{
    public float ZombieDamage;
    public NavMeshAgent agent;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(player.transform.position.y - transform.position.y) < 10 && Vector3.Distance(player.transform.position, transform.position) <= 26)
        {
            agent.SetDestination(player.transform.position);
        }
        else
            agent.SetDestination(transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerDMG>().TakeDMG(ZombieDamage);
            
        }
    }
    }
