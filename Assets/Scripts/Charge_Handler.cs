using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Handler : MonoBehaviour
{
    public int attacks = 0;
    public bool collided;
    PlayerDMG playerScript;

    // Start is called before the first frame update
    void Start()
    {
        collided = false;
        playerScript = GameObject.Find("Player").GetComponent<PlayerDMG>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "transparent"){
            collided = true;
        }
        if(other.gameObject.tag == "Player"){
            playerScript.TakeDMG(5);
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
