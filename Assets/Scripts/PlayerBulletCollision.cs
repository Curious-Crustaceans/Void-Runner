using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
	public float bulletDMG;
    GameObject player;
	
    // Start is called before the first frame update
    void Start(){
    	player = GameObject.Find("Player");
        
    }
    

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {  
        if (other.tag != "Player" && other.tag != "transparent")
            Destroy(gameObject);

        if (other.tag == "Enemy")
        	{
        		other.gameObject.GetComponent<EnemyDMG>().TakeDMG(bulletDMG);
        	}   
    }

}
