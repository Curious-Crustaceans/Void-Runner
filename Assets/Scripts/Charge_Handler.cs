using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Handler : EnemyMind
{
    public int attacks = 0;
    public bool collided;
    PlayerDMG playerScript;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        collided = false;
        playerScript = GameObject.Find("Player").GetComponent<PlayerDMG>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            anim.SetBool("Start", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "transparent"){
            collided = true;
        }
        if(other.gameObject.tag == "Player"){
            playerScript.TakeDMG(2);
        }
    }

    public void IncAtt(){
        attacks++;
    }

    public void Reset()
    {
        attacks = 0;
    }

    public void ResetCollider(){
        collided = false;
    }
}
